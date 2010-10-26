using System;
using System.Text;

namespace Mirror
{
    public class TagEventArgs
    {
        
        /// <summary>
        /// Gets long representation of tag's value.
        /// </summary>
        public ulong TagId { get; protected set; }
        /// <summary>
        /// Gets hex string formed in away that every two chars correspond to byte read from tag.
        /// </summary>
        public string HexString { get; protected set; }
        /// <summary>
        /// Gets raw bytes in tag.
        /// </summary>
        public byte[] Bytes { get; protected set; }
        /// <summary>
        /// Initializes new instance of tag shown event args
        /// </summary>
        /// <param name="data"></param>
        public TagEventArgs(byte[] data ) 
        {
            if (data.Length <= 4) TagId = BitConverter.ToUInt32(data, 0);
            else TagId = BitConverter.ToUInt64(data, 0);
            var builder = new StringBuilder();
            foreach (var b in data)
            {
                if (b < 16) builder.Append("0");
                builder.AppendFormat("{0:X}", b);
            }
            HexString = builder.ToString();

            Bytes = data;
        }
    }
}