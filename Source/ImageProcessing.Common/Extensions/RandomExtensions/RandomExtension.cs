using System;

namespace ImageProcessing.Common.Extensions.RandomExtensions
{
    public static class RandomExtension
    {
        public static int NextInt32(this Random random)
        {
            var firstBits = random.Next(0, 1 << 4) << 28;
            var lastBits = random.Next(0, 1 << 28);

            return firstBits | lastBits;
        }

        public static decimal NextDecimal(this Random random)
        {
            var sample = 1M;

            while (sample >= 1)
            {
                var a = NextInt32(random);
                var b = NextInt32(random);
                var c = random.Next(0x204FCE5E);

                sample = new decimal(a, b, c, false, 28);
            }

            return sample;
        }

        public static decimal NextDecimal(this Random random, decimal max)
        {
            return NextDecimal(random, decimal.Zero, max);
        }

        public static decimal NextDecimal(this Random random, decimal min, decimal max)
        {
            var nextDecimalSample = NextDecimal(random);
            return max * nextDecimalSample + min * (1 - nextDecimalSample);
        }
    }
}
