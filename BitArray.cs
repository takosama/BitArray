using System;

namespace BitArray
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray bitArray = new BitArray(16);
            bitArray.SetBit(7);
            bitArray.SetBit(8);

            bitArray.ResetBit(7);
            bitArray.ResetBit(8);


            bitArray.ReverseBit(0);
            bitArray.ReverseBit(15);

            bitArray.GetBit(0); //true;
            bitArray.GetBit(1); //false;
        }
    }

    class BitArray
    {
        public int Length { get; private set; }
        byte[] _arr = null;
        public BitArray(int length)
        {
            if (length % 8 != 0)
                throw new Exception();
            this._arr = new byte[length / 8];
            this.Length = length;
        }

        public void  ReverseBit(int pos)
        {
            int index = pos / 8;
            pos %= 8;
            pos = 7 - pos;
             this._arr[index] ^= (byte)(1 << pos);
        }

        public bool GetBit(int pos)
        {
            int index = pos / 8;
            pos %= 8;
            pos = 7 - pos;
            return (this._arr[index] & (byte)(1 << pos)) != 0;
        }


        public void SetBit(int pos)
        {
            int index = pos / 8;
            pos %= 8;
            pos = 7 - pos;

            this._arr[index] |= (byte)(1 << pos);
        }

        public void ResetBit(int pos)
        {
            int index = pos / 8;
            pos %= 8;
            pos = 7 - pos;

            this._arr[index] &= (byte)~(1 << pos);
        }
    }

}
