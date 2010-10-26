using System.Text;
using Mirror.UsbLibrary;

namespace Mirror
{
    /// <summary>
    /// Represents single VioletMirror. 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <exception cref="DeviceRemovedException">Might get thrown from any method if mirror is disconnected before this object is disposed.</exception>
    public class VioletMirror : HIDDevice 
    {
        /// <summary>
        /// Holds message count that is used as message identifier.
        /// </summary>
        private ushort currentMessageId; 
        /// <summary>
        /// This is generic data received event handler. This is invoked every time other than zeros are received from port.
        /// </summary>
        public event DataRecievedEventHandler DataRecieved;
        /// <summary>
        /// This event is triggered when tag is shown for mirror.
        /// </summary>
        public event TagShownEventHandler TagShown;
        /// <summary>
        /// This event is triggered when tag is taken away from mirror.
        /// </summary>
        public event TagHidEventHandler TagHid;
        /// <summary>
        /// This event is triggered when mirrors orientation changes. This is also triggered when GetOrientation is called.
        /// </summary>
        public event OrientationChangedEventHandler OrientationChanged;
        /// <summary>
        /// Gets or sets how long to wait response by blocking current thread. In milliseconds. 
        /// Defaults to 1000.
        /// </summary>
        public int ResponseTimeout { get; set; }

        private string id;
        /// <summary>
        /// Gets cached identifier of mirror. Is null if mirrror is not initialized.
        /// </summary>
        public string Id
        {
            get { return id ?? (id = GetMirrorId()); }
        }
        /// <summary>
        /// Initializes mirror.
        /// </summary>
		public override void EnsureIsInitialized() {
			base.EnsureIsInitialized();
			id = GetMirrorId();
		}
        protected override InputReport CreateInputReport()
        {
            return new InputEvent(this);
        }

        /// <summary>
        /// Gets VID of this device type.
        /// </summary>
        public override ushort VendorId
        {
            get { return 0x1da8; }
        }

        /// <summary>
        /// Gets PID of this device type.
        /// </summary>
        public override ushort ProductId
        {
            get { return 0x1301; }
        }

        protected OutputEvent CreateOutputReport(EventType eventType, byte[] data )
        {
            return new OutputEvent(eventType, GetNewMessageId() , this, data);
        }


        /// <summary>
        /// Gets new message identifier.
        /// </summary>
        /// <returns></returns>
        protected virtual ushort GetNewMessageId()
        {
            if (currentMessageId >= ushort.MaxValue) currentMessageId = 0;
            currentMessageId++;
            return currentMessageId; 
        }

        protected override void HandleDataReceived(InputReport inputReport)
        {
            var report = (InputEvent)inputReport;
            // Fire generic data received event
            if (DataRecieved != null)
            {
                
                if (report.EventType != EventType.Unspecified)
                {
                    var args = new MirrorEventReceivedArgs(report);
                    DataRecieved(this, args);
                }
            }
            // Fire specific events
            switch (report.EventType)
            {
                case EventType.ShowTag:
                    if (TagShown != null) TagShown(this, new TagEventArgs(report.Data));
                    break;
                case EventType.HideTag:
                    if (TagHid != null) TagHid(this, new TagEventArgs(report.Data));
                    break;
                case EventType.OrientationDown :
                    if( OrientationChanged != null )
                        OrientationChanged(this, new OrientationChangedEventArgs(Orientation.Down));
                    break;
                case EventType.OrientationUp :
                    if( OrientationChanged != null )
                        OrientationChanged(this, new OrientationChangedEventArgs(Orientation.Up));
                    break;
            }
        }

        protected virtual void SendData(EventType eventType, byte[] data)
        {
            var outputReport = CreateOutputReport( eventType,data );
            try
            {
                Write(outputReport); // write the output report
            }
            catch (HIDDeviceException)
            {
                // Device may have been removed!
            }
        }
        protected virtual InputEvent SendDataAndWaitResponse(EventType eventType, byte[] data)
        {
            var outputReport = CreateOutputReport(eventType,data);
            var sync = new ResponseSync(outputReport.MessageId);
            DataRecieved += sync.OnDataReceived; 
            Write(outputReport); // write the output report
            sync.ResetEvent.WaitOne(ResponseTimeout);
            return sync.Response;
        }

        protected override void Dispose(bool bDisposing)
        {
            if (bDisposing)
            {
                DataRecieved = null;
            }
            base.Dispose(bDisposing);
        }
        /// <summary>
        /// Gets the orientation of mirror.
        /// </summary>
        /// <returns>Orientation</returns>
        public Orientation GetOrientation()
        {
            var response = SendDataAndWaitResponse(EventType.GetOrientation, null);
            if (response.EventType == EventType.OrientationUp) return Orientation.Up;
            
            return Orientation.Down;
        }
        #region Choreography
        /// <summary>
        /// Sets choreo off. This also shuts down lights. This works only if mirror is just initialized and 
        /// no tags are shown to it.
        /// ALL CHOREO RELATED STUFF IS HIGHLY EXPERIMENTAL AND PROPABLY WON'T WORK!
        /// </summary>
        public bool SetChoreoOff()
        {
            var response = SendDataAndWaitResponse(EventType.SetChoreoOff, new byte[] { 50,50,50,50 });
            return response.EventType == EventType.InvalidParameters;
        }
        /// <summary>
        /// Sets choreo on. Last choreo is also played.
        /// ALL CHOREO RELATED STUFF IS HIGHLY EXPERIMENTAL AND PROPABLY WON'T WORK!
        /// </summary>
        public bool PlayChoreo()
        {
            return SendDataAndWaitResponse(EventType.PlayChoreo, new byte[] { 0x04,0x64, 0x00,0xe8 }).EventType == EventType.InvalidParameters;
        }
        /// <summary>
        /// ALL CHOREO RELATED STUFF IS HIGHLY EXPERIMENTAL AND PROPABLY WON'T WORK!
        /// </summary>
        /// <returns></returns>
        public bool SetChoreoPowerOnly()
        {
            return SendDataAndWaitResponse(EventType.SetChoreoPowerOnly, new byte[] { 0xff, 0xff,0xff,0xff,0xff,0xff }).EventType == EventType.InvalidParameters;
        }
        /// <summary>
        /// Gets choreo info. Actual implementation of this method is still a bit mystery. 
        /// ALL CHOREO RELATED STUFF IS HIGHLY EXPERIMENTAL AND PROPABLY WON'T WORK!
        /// </summary>
        /// <returns></returns>
        public ChoreoInfo GetChoreoInfo()
        {
            var response = SendDataAndWaitResponse(EventType.GetChoreoInfo, new byte[] { 5, 5 });
            return new ChoreoInfo(response.Data);
        }
        /// <summary>
        /// ALL CHOREO RELATED STUFF IS HIGHLY EXPERIMENTAL AND PROPABLY WON'T WORK!
        /// </summary>
        public void UnknownChoreoCommand02()
        {
            var response = SendDataAndWaitResponse(EventType.UnknownChoreoCommand02, new byte[] { 1, 1, 1, 1 });
        }
        /// <summary>
        /// ALL CHOREO RELATED STUFF IS HIGHLY EXPERIMENTAL AND PROPABLY WON'T WORK!
        /// </summary>
        public void UnknownChoreoCommand05()
        {
            var response = SendDataAndWaitResponse(EventType.UnknownChoreoCommand05, new byte[] { 1, 1, 1, 1 });
        }
        /// <summary>
        /// ALL CHOREO RELATED STUFF IS HIGHLY EXPERIMENTAL AND PROPABLY WON'T WORK!
        /// </summary>
        public void UnknownChoreoCommand06()
        {
            var response = SendDataAndWaitResponse(EventType.UnknownChoreoCommand06, new byte[] { 1, 1, 1, 1 });
        }
        #endregion
        protected string GetMirrorId()
        {
            var response = SendDataAndWaitResponse(EventType.GetMirrorId, null);
            var builder = new StringBuilder();
            foreach (var b in response.Data)
            {
                builder.Append(string.Format("{0:X2}", b));
            }
            return builder.ToString();
        }
        /// <summary>
        /// Initializes new instance of VioletMirror. User MirrorFactory to get mirror.
        /// </summary>
        public VioletMirror( string devicePath ) :base( devicePath )
        {
            ResponseTimeout = 1000;
        }

        private string applicationVersion;
        private string bootloaderVersion;
        /// <summary>
        /// Gets application version.
        /// </summary>
        public string ApplicationVersion
        {
            get { return applicationVersion ?? (applicationVersion = GetApplicationVersion()); }
        }
        /// <summary>
        /// Gets bootloader version.
        /// </summary>
        public string BootloaderVersion
        {
            get { return bootloaderVersion ?? ( bootloaderVersion = GetBootloaderVersion()); }
        }
        private string GetApplicationVersion()
        {
            var response = SendDataAndWaitResponse(EventType.GetApplicationVersion, null);
            return response.ToVersionNumberString();
        }
        private string GetBootloaderVersion()
        {
            var response = SendDataAndWaitResponse(EventType.GetBootloaderVersion, null);
            return response.ToVersionNumberString();
        }

    }


    public delegate void OrientationChangedEventHandler(object sender, OrientationChangedEventArgs args);
    public delegate void TagHidEventHandler(object sender, TagEventArgs args);
    public delegate void TagShownEventHandler(object sender, TagEventArgs args);
    public delegate void DataRecievedEventHandler(object sender, MirrorEventReceivedArgs args);
}