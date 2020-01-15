using System;
using System.Collections.Generic;
using System.Text;
using ImageProcessing.Common.Enums;

namespace ImageProcessing.Common.Utility.DecimalMath
{
    public static class DecimalMath
    {
        public const decimal E = 2.71828182845905M;
        public const decimal Epsilon = 1.0E-20M;
        public const decimal PI = 3.14159265358979323846M;



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
        /// Repsresent log(x) = integral series[1/(t + 1)]dt from 0 to x - 1 / log(base)
         /// </summary>
        public static decimal Log(decimal x, decimal lbase = E, decimal precision = Epsilon)
        {
            if(x < 0)
            {
                throw new ArgumentException("The value must be a positive real number");
            }

            if(lbase <= 0 || lbase == 1)
            {
                throw new ArgumentException("A logarithm base must be in (0, 1) U (1, +inf)");
            }
   
            if (Abs(E - lbase) > precision)
            {
                return Integrate(Integration.Trapezoidal, (t) => 1M / t, (1M, x)) / Log(lbase);
            }

            return Integrate(Integration.Trapezoidal, (t) => 1M / t, (1M, x));
    

        }

        public static decimal Atan(decimal x, decimal precision = Epsilon)
        {
            return Integrate(Integration.Trapezoidal, (t) => 1M / (1 + t * t), (0.0M, x), 40000);
        }

        public static decimal Acot(decimal x, decimal precision = Epsilon)
        {
            var sign = Sign(x);

            if(Abs(x) < Abs(precision) && x != 0) {
                return sign * PI / 2.0M;
            }

            if (x == 0.0M) return PI / 2.0M;

            return sign * PI / 2.0M -  Atan(x, precision);
        }

        /// <summary>
        /// Integrate a real valued function f(x)
        /// </summary>
        /// <param name="f">A function of real variable</param>
        /// <param name="b">The end of an interval</param>
        /// <param name="a">The start of an interval</param>
        /// <param name="steps">Number of iterations</param>
        public static decimal Integrate(Integration method, Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 20000)
        {
            try
            {
                if (interval.x1 == interval.x2) return 0.0M;

               switch(method)
                {
                    case Integration.Trapezoidal:
                        return Trapezoidal(f, interval, N);

                    default: throw new NotImplementedException();
                }
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
        private static decimal Trapezoidal(Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 20000)
        {
            var b = interval.x2;
            var a = interval.x1;

            var h = (b - a) / N;
            var res = (f(a) + f(b)) / 2.0M;

            for (var k = 1; k < N; ++k)
            {
                res += f(a + k * h);
            }

            return h * res;
        }
    }
}
