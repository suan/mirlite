using System;

namespace Mirror
{
    public class ChoreoInfo
    {
        public int Volume { get; protected set; }
        public int Heap { get; protected set; }

        public ChoreoInfo(byte[] data )
        {
            Volume = BitConverter.ToInt16(data, 0);
            Heap = BitConverter.ToInt16(data, 2);
        }

    }
}