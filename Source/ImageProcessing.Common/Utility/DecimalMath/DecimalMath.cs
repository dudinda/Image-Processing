using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Common.Utility.DecimalMath
{
    public static class DecimalMath
    {
        public const decimal E = 2.718281828459M;
        public const decimal Epsilon = 1.0E-20M;
        public const decimal PI = 3.14159265359M;



        public static decimal Sqrt(decimal value, decimal precision = Epsilon)
        {
            if (value < 0)
            {
                throw new ArgumentException("The value must be real.");
            }

            var x = value;
            var y = 1M;

            while (x - y > precision)
            {
                x = (x + y) / 2;
                y = value / x;
            }

            return x;
        }

        public static decimal Sign(decimal value)
        {
            if (value == 0) return 0;

            return value > 0 ? 1 : -1;
        }

        public static decimal Abs(decimal value)
        {
            return value >= 0 ? value : -value;
        }

        public static decimal Pow(decimal value, decimal power)
        {
            if(value < 0)
            {
                throw new ArgumentException("The value must be a positive real number");
            }

            var expPower = power * Log(value);

            return Exp(expPower);
        }

        public static decimal Exp(decimal x, decimal precision = Epsilon)
        {
            var total = 1.0M;
            var result = total;

            for (var k = 1; Abs(total) > Epsilon; ++k)
            {
                total = total * x / k;
                result += total;
            }

            return result;
        }

        public static decimal Sin(decimal x, decimal precision = Epsilon)
        {
            var total = 1.0M;
            var result = total;

            for (var k = 1; Abs(total) > Epsilon; ++k)
            {
                total = total *  - x * x / ((2 * k + 2) * (2 * k + 3));
                result += total;
            }

            return result;
        }

        public static decimal Cos(decimal x, decimal precision = Epsilon)
        {
            var total = 1.0M;
            var result = total;

            for (var k = 1; Abs(total) > Epsilon; ++k)
            {
                total = total * -x * x / ((2 * k + 1) * (2 * k + 2));
                result += total;
            }

            return result;
        }

        public static decimal Cosh(decimal x, decimal precision = Epsilon)
        {
            return (Exp(x, precision) + Exp(-x, precision)) / 2.0M;
        }

        public static decimal Sinh(decimal x, decimal precision = Epsilon)
        {
            return (Exp(x, precision) - Exp(-x, precision)) / 2.0M;
        }

        public static decimal Tanh(decimal x, decimal precision = Epsilon)
        {
            return Sinh(x, precision) / Cosh(x, precision);
        }

        public static decimal Coth(decimal x, decimal precision = Epsilon)
        {
            return 1.0M / Tanh(x, precision);
        }

        public static decimal Cot(decimal x, decimal precision = Epsilon)
        {
            return 1.0M / Tan(x, precision);
        }



        public static decimal Tan(decimal x, decimal precision = Epsilon)
        {
            x = Mod(x, PI);

            return Sin(x) / Cos(x);
        }

        /// <summary>
        /// Repsresent log(x) = log(base) * integral dt/t from 1 to x
        /// </summary>
        public static decimal Log(decimal value, decimal lbase = E, decimal precision = Epsilon)
        {
            if(value < 0)
            {
                throw new ArgumentException("The value must be a positive real number");
            }

            if(lbase <= 0 || lbase == 1)
            {
                throw new ArgumentException("A logarithm base must be in (0, 1) U (1, +inf)");
            }

            if (Abs(E - lbase) > precision)
            {
                return Log(lbase, E) * Integrate((x) => 1M / x, (1M, value), 10000);
            }

            return Integrate((x) => 1M / x, (1M, value), 10000);

        }

        /// <summary>
        /// Integrate function f(x) from a to b using trapezoidal rule
        /// </summary>
        /// <param name="f"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        public static decimal Integrate(Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N)
        {
            try
            {
                var b = interval.x2;
                var a = interval.x1;

                var h = (b - a) / N;
                var res = (f(a) + f(b)) / 2;

                for (int i = 1; i < N; i++)
                {
                    res += f(a + i * h);
                }

                return h * res;
            }
            catch
            {
                throw new ArithmeticException("The function has a singularity point at [a, b]");
            }
        }

        public static decimal Ceil(decimal value)
        {
            if(value % 1 != 0)
            {
                return Floor(value) + 1;
            }

            return value;
        }


        public static decimal Floor(decimal value)
        {
            var result = value - (value % 1);

            if(result == value)
            {
                return value;
            }

            if(value < 0)
            {
                return result - 1;
            }

            return result;
        }

        public static decimal Mod(decimal value, decimal mod)
        {
            return value - mod * Floor(value / mod);
        }
    }
}
