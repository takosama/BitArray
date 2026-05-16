using System;

namespace BitArrayLib
{
    public class BitArray
    {
        public int Length { get; }
        private readonly byte[] _arr;

        public BitArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            Length = length;
            _arr = new byte[(length + 7) >> 3];
        }

        public bool this[int pos]
        {
            get => GetBit(pos);
            set { if (value) SetBit(pos); else ResetBit(pos); }
        }

        public void ToggleBit(int pos)
        {
            var (index, mask) = GetIndexAndMask(pos);
            _arr[index] ^= mask;
        }

        [Obsolete("Use ToggleBit instead.")]
        public void ReverseBit(int pos) => ToggleBit(pos);

        public bool GetBit(int pos)
        {
            var (index, mask) = GetIndexAndMask(pos);
            return (_arr[index] & mask) != 0;
        }

        public void SetBit(int pos)
        {
            var (index, mask) = GetIndexAndMask(pos);
            _arr[index] |= mask;
        }

        public void ResetBit(int pos)
        {
            var (index, mask) = GetIndexAndMask(pos);
            _arr[index] &= (byte)~mask;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder(Length);
            for (int i = 0; i < Length; i++)
                sb.Append(GetBit(i) ? '1' : '0');
            return sb.ToString();
        }

        private (int Index, byte Mask) GetIndexAndMask(int pos)
        {
            if ((uint)pos >= (uint)Length)
                throw new ArgumentOutOfRangeException(nameof(pos));

            int index = pos >> 3;
            byte mask = (byte)(1 << (7 - (pos & 7)));
            return (index, mask);
        }
    }
}
