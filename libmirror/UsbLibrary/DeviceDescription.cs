using System;

namespace Mirror.UsbLibrary
{
    public class DeviceDescription<TDevice> where TDevice : HIDDevice
    {
        /// <summary>
        /// Gets or sets path to device.
        /// </summary>
        public string DevicePath { get; protected set; }
        /// <summary>
        /// Creates new instance of device.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DeviceAllreadyInUseException" >Is thrown if device is allready in use somewhere else.</exception>
        public TDevice Create()
        {
            var instance = (TDevice) Activator.CreateInstance(typeof (TDevice), new[] {DevicePath});
            instance.EnsureIsInitialized();
            return instance;
        }
        /// <summary>
        /// Gets boolean indicating wheter device is in use.
        /// </summary>
        public bool IsInUse
        {
            get { return HIDDevice.IsInUse(DevicePath); }
        }
        /// <summary>
        /// Returns device path.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DevicePath;
        }
        /// <summary>
        /// Initializes new instance of device description.
        /// </summary>
        /// <param name="devicePath">Path to device. Cannot be null or empty.</param>
        public DeviceDescription(string devicePath)
        {
            if( string.IsNullOrEmpty( devicePath ) ) throw new ArgumentNullException( "devicePath");
            DevicePath = devicePath;
        }
    }
}