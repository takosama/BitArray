using System;

namespace BitArray
{
    class BitArray
    {
        public int Length { get; private set; }
        private readonly byte[] _arr;

        public BitArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            _arr = new byte[(length + 7) >> 3];
            Length = length;
        }

        public void ReverseBit(int pos)
        {
            GetIndexAndMask(pos, out int index, out byte mask);
            _arr[index] ^= mask;
        }

        public bool GetBit(int pos)
        {
            GetIndexAndMask(pos, out int index, out byte mask);
            return (_arr[index] & mask) != 0;
        }

        public void SetBit(int pos)
        {
            GetIndexAndMask(pos, out int index, out byte mask);
            _arr[index] |= mask;
        }

        public void ResetBit(int pos)
        {
            GetIndexAndMask(pos, out int index, out byte mask);
            _arr[index] &= (byte)~mask;
        }

        private void GetIndexAndMask(int pos, out int index, out byte mask)
        {
            if ((uint)pos >= (uint)Length)
                throw new ArgumentOutOfRangeException(nameof(pos));

            index = pos >> 3;
            int bit = 7 - (pos & 7);
            mask = (byte)(1 << bit);
        }
    }
}
