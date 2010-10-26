namespace Mirror
{
    public static class EventTypeParser
    {
        public static EventType Parse( byte[] eventTypeBytes )
        {
            ushort cmd = eventTypeBytes[1];
            cmd <<= 8;
            cmd |= eventTypeBytes[2];

            return (EventType) cmd;
        }
    }
}