namespace Mirror
{
    public class VioletEvent 
    {
        public EventType EventType { get; set; }
        public byte[] Data { get; set; }
        public ushort MessageId { get; set; }
    }
}