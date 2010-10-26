using System;

namespace Mirror
{
    public class MirrorEventReceivedArgs : EventArgs
    {
        public MirrorEventReceivedArgs(InputEvent e)
        {
            Event = e;
        }
        public InputEvent Event { get; set; }
        
    }
}