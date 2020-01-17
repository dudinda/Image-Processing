using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.RandomExtensions;

namespace ImageProcessing.Common.Utility.DecimalMath
{
    public static class DecimalMathIntegration
    {
        /// <summary>
        /// Integrate a real valued function f(x)
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
            var b = interval.x2;
            var a = interval.x1;

            checked
            {
                var h = (b - a) / N;
                var res = (f(a) + f(b)) / 2.0M;

                for (var k = 1; k < N; ++k)
                {
                    res += f(a + k * h);
                }

                return h * res;
            }
        }

        private static decimal MonteCarlo(Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
            var b = interval.x2;
            var a = interval.x1;

            var generator = new Random(DateTime.UtcNow.Second);
            var result = 0.0M;

            var coef = (b - a) / N;

            checked
            {
                for (var k = 0; k < N; ++k)
                {
                    result += f(generator.NextDecimal(a, b));
                }

                return coef * result;
            }
        }

    }
}
