using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Mirror.UsbLibrary
{
    public delegate void DeviceRemovedEventHandler(object sender, DeviceRemovedEventArgs e);

    public class DeviceRemovedEventArgs : EventArgs
    {
        /// <summary>
        /// Set this to true if device removed event has been handled to prevent exception.
        /// </summary>
        public bool IsHandled { get; set; }
        /// <summary>
        /// Gets device that was removed.
        /// </summary>
        public HIDDevice Device { get; protected set; }
        /// <summary>
        /// Initializes new instance of DeviceRemovedEventArgs.
        /// </summary>
        /// <param name="device"></param>
        public DeviceRemovedEventArgs(HIDDevice device)
        {
            Device = device;
        }
    }

    /// <summary>
	/// Abstract HID device : Derive your new device controller class from this
	/// </summary>
    public abstract class HIDDevice : Win32Usb, IDisposable
    {
		#region Privates variables
		/// <summary>Filestream we can use to read/write from</summary>
        private FileStream file;
		/// <summary>Length of input report : device gives us this</summary>
		private int inputReportLength;
		/// <summary>Length if output report : device gives us this</summary>
		private int outputReportLength;
		/// <summary>Handle to the device</summary>
		private IntPtr handle;
		#endregion

        #region IDisposable Members
		/// <summary>
		/// Dispose method
		/// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
		/// <summary>
		/// Disposer called by both dispose and finalise
		/// </summary>
		/// <param name="bDisposing">True if disposing</param>
        protected virtual void Dispose(bool bDisposing)
        {
            try
            {
                if (bDisposing)	// if we are disposing, need to close the managed resources
                {
                    if (file != null)
                    {
                        file.Close();
                        file = null;
                    }
                }
                if (handle != IntPtr.Zero)	// Dispose and finalize, get rid of unmanaged resources
                {

                    CloseHandle(handle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion
        /// <summary>
        /// Gets boolean indicating wheter device is in use. 
        /// </summary>
        public static bool IsInUse( string devicePath ) 
        {

            var ptr = CreateFile(devicePath, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING,
                                        FILE_FLAG_OVERLAPPED, IntPtr.Zero);
            if (ptr == InvalidHandleValue) return true;
            if (ptr != IntPtr.Zero)	// Dispose and finalize, get rid of unmanaged resources
            {
                CloseHandle(ptr);
            }
            return false;
        }
		#region Privates/protected
		/// <summary>
		/// Initialises the device. This must be called before events start triggering. If device is allready initialized does nothing.
		/// </summary>
		/// <exception cref="HIDDeviceException">Is thrown if something unexpected happend during initialization</exception>
		/// <exception cref="DeviceAllreadyInUseException">Is thrown if device is allready in use somewhere else.</exception>
		public virtual void EnsureIsInitialized()
		{
            if (IsInitialized) return;
            // Create the file from the device path
            handle = CreateFile(DevicePath, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, IntPtr.Zero);

            if ( handle != InvalidHandleValue)	// if the open worked...
			{
				IntPtr lpData;
				if (HidD_GetPreparsedData(handle, out lpData))	// get windows to read the device data into an internal buffer
				{
                    try
                    {
                        HidCaps oCaps;
                        HidP_GetCaps(lpData, out oCaps);	// extract the device capabilities from the internal buffer
                        inputReportLength = oCaps.InputReportByteLength;	// get the input...
                        outputReportLength = oCaps.OutputReportByteLength;	// ... and output report lengths

                        file = new FileStream(new SafeFileHandle(handle, false), FileAccess.Read | FileAccess.Write, inputReportLength, true);
                        IsInitialized = true;                        
                        BeginAsyncRead();	// kick off the first asynchronous read         
                    }
                    catch (Exception)
                    {
                        throw HIDDeviceException.GenerateWithWinError("Failed to get the detailed data from the hid.");
                    }
					finally
					{
						HidD_FreePreparsedData(ref lpData);	// before we quit the funtion, we must free the internal buffer reserved in GetPreparsedData
					}
				}
				else	// GetPreparsedData failed? Chuck an exception
				{
					throw HIDDeviceException.GenerateWithWinError("GetPreparsedData failed");
				}
			}
			else	// File open failed? Chuck an exception
			{
				handle = IntPtr.Zero;
			    throw new DeviceAllreadyInUseException("Device you tried to initilized is allready in use.");
			}
		}
		/// <summary>
		/// Kicks off an asynchronous read which completes when data is read or when the device
		/// is disconnected. Uses a callback.
		/// </summary>
        private void BeginAsyncRead()
        {
            if (!IsInitialized) throw new DeviceNotInitilizedException();
            if (file == null) return; // If file is null then this object is allready disposed.
            var arrInputReport = new byte[inputReportLength];
            // put the buff we used to receive the stuff as the async state then we can get at it when the read completes
            file.BeginRead(arrInputReport, 0, inputReportLength, ReadCompleted, arrInputReport);
        }
		/// <summary>
		/// Callback for above. Care with this as it will be called on the background thread from the async read
		/// </summary>
		/// <param name="iResult">Async result parameter</param>
        protected void ReadCompleted(IAsyncResult iResult)
        {
            var arrBuff = (byte[])iResult.AsyncState;	// retrieve the read buffer
            try
            {
                if (file == null) return; // file is null. This means that object is eigther disposed or not initilized.
                file.EndRead(iResult);	// call end read : this throws any exceptions that happened during the read
                try
                {
					var inputReport = CreateInputReport();	// Create the input report for the device
					inputReport.SetData(arrBuff);	// and set the data portion - this processes the data received into a more easily understood format depending upon the report type
                    HandleDataReceived(inputReport);	// pass the new input report on to the higher level handler
                }
                finally
                {
                    BeginAsyncRead();	// when all that is done, kick off another read for the next report
                }                
            }
            catch(IOException)	// if we got an IO exception, the device was removed
            {
                HandleDeviceRemoved();
            }
        }
		/// <summary>
		/// Write an output report to the device.
		/// </summary>
		/// <param name="outputReport">Output report to write</param>
        protected void Write(OutputReport outputReport)
        {
            if (!IsInitialized) throw new DeviceNotInitilizedException();
            try
            {
                file.Write(outputReport.Buffer, 0, outputReport.BufferLength);
            }
            catch (IOException)
            {
                // The device was removed!
                throw new HIDDeviceException("Probaly the device was removed");
            }
			catch(Exception exx)
			{
                Console.WriteLine(exx.ToString());	
			}
        }
		/// <summary>
		/// virtual handler for any action to be taken when data is received. Override to use.
		/// </summary>
		/// <param name="inputReport">The input report that was received</param>
		protected virtual void HandleDataReceived(InputReport inputReport)
		{
		}
		/// <summary>
		/// Handler for any action to be taken when a device is removed. Triggers DeviceRemoved event and
		/// throws DeviceRemovedException if no-one handles the exception.
		/// 
		/// Handlers should dispose HIDDevice object correctly.
		/// </summary>
		/// <exception cref="DeviceRemovedException">Is thrown when device is removed and no-one handled it.</exception>
		protected void HandleDeviceRemoved()
		{
		    var args = new DeviceRemovedEventArgs(this);
            if (DeviceRemoved != null)
            {
                DeviceRemoved(this, args);
            }
            if( !args.IsHandled )
            {
                Dispose();
                throw new DeviceRemovedException();
            }
		}
		/// <summary>
		/// Helper method to return the device path given a DeviceInterfaceData structure and an InfoSet handle.
		/// Used in 'FindDevice' so check that method out to see how to get an InfoSet handle and a DeviceInterfaceData.
		/// </summary>
		/// <param name="hInfoSet">Handle to the InfoSet</param>
		/// <param name="oInterface">DeviceInterfaceData structure</param>
		/// <returns>The device path or null if there was some problem</returns>
		private static string GetDevicePath(IntPtr hInfoSet, ref DeviceInterfaceData oInterface)
		{
			uint nRequiredSize = 0;
			// Get the device interface details
			if (!SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, IntPtr.Zero, 0, ref nRequiredSize, IntPtr.Zero))
			{
				var oDetail = new DeviceInterfaceDetailData();
                oDetail.Size = IntPtr.Size == 8 ? 8 : 5;
				if (SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, ref oDetail, nRequiredSize, ref nRequiredSize, IntPtr.Zero))
				{
                    return oDetail.DevicePath;
				}
			}
			return null;
		}
		#endregion

		#region Public static
		/// <summary>
		/// Gets first devices of given type.
		/// </summary>
		/// <returns>Device or null if not found.</returns>
        public static DeviceDescription<TDevice> FindDevice<TDevice>() where TDevice : HIDDevice
        {
            var devices = FindDevices<TDevice>();
            return devices.FirstOrDefault();
        }
        /// <summary>
		/// Finds devices of type.
		/// </summary>
		/// <typeparam name="TDevice">Type of device to look for.</typeparam>
		/// <returns>Enumeration of devices.</returns>
		public static IEnumerable<DeviceDescription<TDevice>> FindDevices<TDevice>() where  TDevice : HIDDevice 
        {
            var devices = new List<DeviceDescription<TDevice>>();
            //Creating instance to get Vendor and product id's.

            var instance = (TDevice) Activator.CreateInstance(typeof (TDevice), new[] {""} );

            var strSearch = string.Format("vid_{0:x4}&pid_{1:x4}", instance.VendorId, instance.ProductId); // first, build the path search string
            var gHid = HIDGuid;
            //HidD_GetHidGuid(out gHid);	// next, get the GUID from Windows that it uses to represent the HID USB interface
            var hInfoSet = SetupDiGetClassDevs(ref gHid, null, IntPtr.Zero, DIGCF_DEVICEINTERFACE | DIGCF_PRESENT);	// this gets a list of all HID devices currently connected to the computer (InfoSet)
            try
            {
                var oInterface = new DeviceInterfaceData();	// build up a device interface data block
                oInterface.Size = Marshal.SizeOf(oInterface);
                // Now iterate through the InfoSet memory block assigned within Windows in the call to SetupDiGetClassDevs
                // to get device details for each device connected
                var nIndex = 0;
                while (SetupDiEnumDeviceInterfaces(hInfoSet, 0, ref gHid, (uint)nIndex, ref oInterface))	// this gets the device interface information for a device at index 'nIndex' in the memory block
                {
                    string strDevicePath = GetDevicePath(hInfoSet, ref oInterface);	// get the device path (see helper method 'GetDevicePath')
                    if (strDevicePath.IndexOf(strSearch) >= 0)	// do a string search, if we find the VID/PID string then we found our device!
                    {
                        // Creating instance and adding device path as constructor parameter.
                        var oNewDevice = (DeviceDescription<TDevice>)Activator.CreateInstance(typeof(DeviceDescription<TDevice>), new[] { strDevicePath });
                        devices.Add(oNewDevice);
                    }
                    nIndex++;	// if we get here, we didn't find our device. So move on to the next one.
                }
            }
            catch(Exception ex)
            {
                throw HIDDeviceException.GenerateError(ex.ToString());
            }
            finally
            {
				// Before we go, we have to free up the InfoSet memory reserved by SetupDiGetClassDevs
                SetupDiDestroyDeviceInfoList(hInfoSet);
            }
            return devices;
        }
		#endregion

		#region Publics
		/// <summary>
		/// Event handler called when device has been removed
		/// </summary>
		public event DeviceRemovedEventHandler DeviceRemoved;
		/// <summary>
		/// Accessor for output report length
		/// </summary>
		public int OutputReportLength
		{
			get
			{
				return outputReportLength;
			}
		}
		/// <summary>
		/// Accessor for input report length
		/// </summary>
		public int InputReportLength
		{
			get
			{
				return inputReportLength;
			}
		}
		/// <summary>
		/// Virtual method to create an input report for this device. Override to use.
		/// </summary>
		/// <returns>A shiny new input report</returns>
		protected virtual InputReport CreateInputReport()
		{
			return null;
		}
        /// <summary>
        /// Gets VID of this device type.
        /// </summary>
        public abstract ushort VendorId { get; }
        /// <summary>
        /// Gets PID of this device type.
        /// </summary>
        public abstract ushort ProductId { get; }
        /// <summary>
        /// Gets physical device path.
        /// </summary>
        public string DevicePath { get; private set; }

	    /// <summary>
	    /// Gets boolean indicating wheter this instance has been initilized. Before mirror is initialized it cannot be used.
	    /// </summary>
	    public bool IsInitialized { get; protected set; }

	    /// <summary>
	    /// Initializes new instance of HIDDevice.
	    /// </summary>
	    /// <param name="devicePath">Device path. Cannot be null.</param>
        protected HIDDevice( string devicePath )
	    {
            if (devicePath == null) throw new ArgumentNullException("devicePath");
	        DevicePath = devicePath;
	    }
        public override string ToString()
        {
            return DevicePath;
        }
	    #endregion
    }

    public class DeviceRemovedException : Exception
    {
        public DeviceRemovedException() : base("Device has been removed.")
        {
            
        }
    }

    public class DeviceAllreadyInUseException : HIDDeviceException
    {
        public DeviceAllreadyInUseException(string strMessage) : base(strMessage)
        {
        }
    }

    public class DeviceNotInitilizedException : Exception
    {
        public DeviceNotInitilizedException()
            : base("Device is not initialized. You must call EnsureIsInitialized before you can ")
        {
        }
    }
}
