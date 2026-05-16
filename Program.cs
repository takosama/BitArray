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
}
