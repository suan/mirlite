using System.Threading;

namespace Mirror
{
    internal class ResponseSync
    {
        public ushort MessageId { get; protected set; }
        public InputEvent Response { get; protected set; }
        public ManualResetEvent ResetEvent { get; set; }
        public ResponseSync(ushort messageId)
        {
            MessageId = messageId;
            ResetEvent = new ManualResetEvent(false);
        }

        public void OnDataReceived(object sender, MirrorEventReceivedArgs args)
        {
            if( args.Event.MessageId == MessageId )
            {
                Response = args.Event;
                ResetEvent.Set();
            }
        }
    }
}