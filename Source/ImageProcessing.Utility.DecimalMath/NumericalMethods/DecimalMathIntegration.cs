using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.Utility.DecimalMath.Code.Extension.RandomExtensions;

namespace ImageProcessing.Utility.DecimalMath.NumericalMethods
{
    public static class DecimalMathIntegration
    {
        public static decimal Trapezoidal(Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
            if (interval.x1 == interval.x2) return 0;

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            var bag = new ConcurrentBag<decimal>();

            var b = interval.x2;
            var a = interval.x1;

            var h = (b - a) / N;
            var res = (f(a) + f(b)) / 2.0M;

            //get N partial sums
            Parallel.For(1, N - 1, options, () => 0.0M,
                (y, state, partial) => partial += f(a + y * h)
            ,(x) => bag.Add(x));

            return h * (res + bag.Sum());
        }

        public static decimal MonteCarlo(Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
            if (interval.x1 == interval.x2) return 0;

            var b = interval.x2;
            var a = interval.x1;

            var generator = new Random(Guid.NewGuid().GetHashCode());

            var result = 0.0M;

            var coef = (b - a) / N;

            for (var k = 0; k < N; ++k)
            {
                result += f(generator.NextDecimal(a, b));
            }

            return coef * result;
        }
    }
}
