using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

using ImageProcessing.DecimalMath.Code.Enums;
using ImageProcessing.DecimalMath.Code.Extension.RandomExtensions;

namespace ImageProcessing.DecimalMath.Numerical
{
    public static class DecimalMathIntegration
    {
        /// <summary>
        /// Integrate a real valued function f(x).
        /// </summary>
        /// <param name="f">A function of a real variable</param>
        /// <param name="b">The end of an interval</param>
        /// <param name="a">The start of an interval</param>
        /// <param name="steps">A number of iterations</param>
        public static decimal Integrate(Integration method, Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
            try
            {
                if (interval.x1 == interval.x2) return 0.0M;

                switch (method)
                {
                    case Integration.Trapezoidal:
                        return Trapezoidal(f, interval, N);
                    case Integration.MonteCarlo:
                        return MonteCarlo(f, interval, N);

                    default: throw new NotImplementedException();
                }
            }
            catch
            {
                throw new ArithmeticException("The function has a singularity point at [a, b]");
            }
        }

        private static decimal Trapezoidal(Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
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

        private static decimal MonteCarlo(Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
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
