using System;
using System.Collections.Generic;

namespace LuaCsharp
{
    public class ByteStringBuilder
    {
        private LinkedList<byte[]> BuffList;
        private int TotalLength;

        public ByteStringBuilder()
        {
            BuffList = new LinkedList<byte[]>();
            TotalLength = 0;
        }

        public override string ToString()
        {
            if (TotalLength <= 0) {
                return String.Empty;
            }
                

            char[] result = new char[TotalLength];
            int i = 0;
            LinkedListNode<byte[]> node = BuffList.First;
            while (node != null) {
                byte[] buff = node.Value;
                for (int j = 0; j < buff.Length; ++j) {
                    result[i++] = (char)buff[j];
                }
                node = node.Next;
            }
            return new string(result);
        }

        public ByteStringBuilder Append(byte[] bytes, int start, int length)
        {
            byte[] buf = new byte[length];
            Array.Copy(bytes, start, buf, 0, length);
            BuffList.AddLast(buf);
            TotalLength += length;
            return this;
        }
    }
}

