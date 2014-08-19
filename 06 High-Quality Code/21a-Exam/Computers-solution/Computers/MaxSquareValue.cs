namespace Computers
{
    using System;
    using Computers.Interfaces;

    public class MaxSquareValue : IMaxSquareValue
    {
        public const int MaxValueFor32BitCpu = 500;
        public const int MaxValueFor64BitCpu = 1000;
        public const int MaxValueFor128BitCpu = 2000;

        public int GetMaxValue(int numberOfBits)
        {
            if (numberOfBits == 32)
            {
                return MaxValueFor32BitCpu;
            }
            else if (numberOfBits == 64)
            {
                return MaxValueFor64BitCpu;
            }
            else if (numberOfBits == 128)
            {
                return MaxValueFor128BitCpu;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Unknown CPU number of bits");
            }
        }
    }
}
