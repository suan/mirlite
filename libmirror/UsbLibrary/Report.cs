namespace Mirror.UsbLibrary
{
	/// <summary>
	/// Base class for report types. Simply wraps a byte buffer.
	/// </summary>
	public abstract class Report
	{
		#region Member variables
		/// <summary>Buffer for raw report bytes</summary>
		private byte[] arrayBuffer;

	    public HIDDevice Device { get; set; }
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="device">Constructing device</param>
		protected Report(HIDDevice device)
		{
			// Do nothing
		    Device = device;
		}

		/// <summary>
		/// Sets the raw byte array.
		/// </summary>
		/// <param name="arrBytes">Raw report bytes</param>
		protected void SetBuffer(byte[] arrBytes)
		{
			Buffer = arrBytes;
			BufferLength = arrayBuffer.Length;
		}

		/// <summary>
		/// Accessor for the raw byte buffer
		/// </summary>
		public byte[] Buffer
		{
			get{return arrayBuffer;}
            set{arrayBuffer = value; }
		}

	    /// <summary>
	    /// Accessor for the buffer length
	    /// </summary>
	    public int BufferLength { get; private set; }
	}
}
