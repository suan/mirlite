using System;
using System.Text;
using Mirror.UsbLibrary;

namespace Mirror
{
    public class InputEvent : InputReport
    {
        public InputEvent(HIDDevice mirrorDevice) : base( mirrorDevice )
        {
        }
        /// <summary>
        /// Gets the event type.
        /// </summary>
        public EventType EventType { get; protected set; }
        /// <summary>
        /// Gets the data.
        /// </summary>
        public byte[] Data { get; protected set; }
        /// <summary>
        /// Gets the message id.
        /// </summary>
        public ushort MessageId { get; protected set; }
        /// <summary>
        /// Gets length of data itself.
        /// </summary>
        public int DataLength { get; protected set; }
        public override void ProcessData()
        {
            EventType = EventTypeParser.Parse(Buffer);
            MessageId = BitConverter.ToUInt16(Buffer, 3);
            DataLength = Buffer[5];
            Data = new byte[DataLength];
            for (var i = 0; i < DataLength; i++)
            {
                Data[i] = Buffer[i + 6];
            }
        }
        /// <summary>
        /// Parses version number string from data. Versio number consists of 48 bits where 12 bits is always assigned to 
        /// each number; major, minor, version and build.
        /// 
        /// This convention is based on screenshot at http://2.bp.blogspot.com/_NcFT1bJ_drE/SPRnEuvht3I/AAAAAAAABek/GIx05u3bGz8/s1600-h/MirrorFactoryTestTool.jpg 
        /// each part of version number is based on three bits.
        /// </summary>
        /// <returns></returns>
        public string ToVersionNumberString()
        {
            var builder = new StringBuilder();

            var number = new byte[2];
            number[0] = Data[0];
            number[1] = (byte) (Data[1] & 0xf0);
            var major = BitConverter.ToUInt16(number, 0);

            number[0] = (byte) (Data[1] & 0xf);
            number[1] = Data[2];
            var minor = BitConverter.ToUInt16(number, 0);

            number[0] = Data[3];
            number[1] = (byte)(Data[4] & 0xf0);
            var build = BitConverter.ToUInt16(number, 0);

            number[0] = (byte)(Data[4] & 0xf);
            number[1] = Data[5];
            var revision = BitConverter.ToUInt16(number, 0);

            builder.Append(major);
            builder.Append('.');
            builder.Append(minor);
            builder.Append('.');
            builder.Append(build);
            builder.Append('.');
            builder.Append(revision);
            return builder.ToString();
        }
    }
}