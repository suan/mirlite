using System;

namespace Mirror
{
    public class MirrorEventSentArgs : EventArgs
    {
        public MirrorEventSentArgs(OutputEvent e)
        {
            Event = e;
        }

        public OutputEvent Event { get; set; }
    }
}