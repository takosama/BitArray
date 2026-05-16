using System;
using BitArrayLib;

namespace BitArrayLib
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitArray = new BitArray(16);

            bitArray.SetBit(7);
            bitArray.SetBit(8);
            Console.WriteLine($"After Set 7,8:     {bitArray}");  // 0000000110000000

            bitArray.ResetBit(7);
            bitArray.ResetBit(8);
            Console.WriteLine($"After Reset 7,8:   {bitArray}");  // 0000000000000000

            bitArray.ToggleBit(0);
            bitArray.ToggleBit(15);
            Console.WriteLine($"After Toggle 0,15: {bitArray}");  // 1000000000000001

            Console.WriteLine($"bit[0] = {bitArray.GetBit(0)}");  // True
            Console.WriteLine($"bit[1] = {bitArray.GetBit(1)}");  // False

            Console.WriteLine($"bitArray[0] = {bitArray[0]}");    // True
            bitArray[3] = true;
            Console.WriteLine($"After [3]=true:    {bitArray}");  // 1001000000000001
        }
    }
}
