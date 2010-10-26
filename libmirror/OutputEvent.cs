using System;
using Mirror.UsbLibrary;

namespace Mirror
{
    public class OutputEvent : OutputReport
    {
        public OutputEvent(EventType eventType, ushort messageId, HIDDevice mirrorDevice, byte[] data) : base(mirrorDevice)
        {
            EventType = eventType;
            MessageId = messageId;
            var eventBytes =  BitConverter.GetBytes((Int32)EventType);
            var messageIdBytes = BitConverter.GetBytes(MessageId);
            Buffer[1] = eventBytes[1];
            Buffer[2] = eventBytes[0];
            Buffer[3] = messageIdBytes[0];
            Buffer[4] = messageIdBytes[1];
            if (data != null)
            {
                Buffer[5] = (byte) data.Length;
                data.CopyTo(Buffer, 6);
            }
        }

        public EventType EventType { get; set; }
        public ushort MessageId { get; set; }
    }
}