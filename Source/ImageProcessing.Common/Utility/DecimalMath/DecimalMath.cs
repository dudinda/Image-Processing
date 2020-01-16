using System;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.Common.Utility.DecimalMath
{
    /// <summary>
    /// The class contains functions of a real variable,
    /// where each argument is represented as <c>decimal</c>
    /// </summary>
    public static class DecimalMath
    {
        public const decimal E = 2.71828182845905M;
        public const decimal Epsilon = 1.0E-20M;
        public const decimal PI = 3.14159265358979323846M;

        /// <summary>
        /// Evaluate sqrt(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        ///         /// <param name="precision">An error</param>
        public static decimal Sqrt(decimal value, decimal precision = Epsilon)
        {
            if (value < 0)
            {
                throw new ArgumentException("The value must be real.");
            }

            var x = value;
            var y = 1M;

            while (Abs(x - y) > precision)
            {
                x = (x + y) / 2;
                y = value / x;
            }

            return x;
        }

        /// <summary>
        /// Evaluate sgn(x)
        /// </summary>
        /// <param name="x">The argument</param>
        public static decimal Sign(decimal x)
        {
            if (x == 0) return 0;

            return x > 0 ? 1 : -1;
        }


        /// <summary>
        /// Evaluate |x|
        /// </summary>
        /// <param name="x">The argument</param>
        public static decimal Abs(decimal x)
        {
            return x >= 0 ? x : -x;
        }

        /// <summary>
        /// Evaluate x ** power with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="power">The power</param>
        /// <param name="precision">An error</param>
        public static decimal Pow(decimal value, decimal power, decimal precision = Epsilon)
        {
            if(value < 0)
            {
                throw new ArgumentException("The value must be a positive real number");
            }

            var expPower = power * Log(value, precision: precision);

            return Exp(expPower);
        }

        /// <summary>
        /// Evaluate exp(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
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

        /// <summary>
        /// Evaluate sin(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
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

        /// <summary>
        /// Evaluate cos(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
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

        /// <summary>
        /// Evaluate cosh(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
        public static decimal Cosh(decimal x, decimal precision = Epsilon)
        {
            return (Exp(x, precision) + Exp(-x, precision)) / 2.0M;
        }

        /// <summary>
        /// Evaluate sinh(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
        public static decimal Sinh(decimal x, decimal precision = Epsilon)
        {
            return (Exp(x, precision) - Exp(-x, precision)) / 2.0M;
        }

        /// <summary>
        /// Evaluate tanh(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
        public static decimal Tanh(decimal x, decimal precision = Epsilon)
        {
            return Sinh(x, precision) / Cosh(x, precision);
        }

        /// <summary>
        /// Evaluate coth(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
        public static decimal Coth(decimal x, decimal precision = Epsilon)
        {
            return 1.0M / Tanh(x, precision);
        }

        /// <summary>
        /// Evaluate cot(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
        public static decimal Cot(decimal x, decimal precision = Epsilon)
        {
            return 1.0M / Tan(x, precision);
        }

        /// <summary>
        /// Evaluate tan(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
        public static decimal Tan(decimal x, decimal precision = Epsilon)
        {
            x = Mod(x, PI);

            return Sin(x) / Cos(x);
        }

        /// <summary>
        /// Evaluate log(x) based on Borchardt's algorithm 
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
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

            var a0 = (1.0M + x) / 2.0M;
            var b0 = Sqrt(x);

                
            while (Abs(a0 - b0) > precision)
            {
                a0 = (a0 + b0) / 2.0M;
                b0 = Sqrt(a0 * b0);
            }

            return 2 * (x - 1) / (a0 + b0);
        }

        /// <summary>
        /// Evaluate atan(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
        public static decimal Atan(decimal x, decimal precision = Epsilon)
        {
            if (x == 0) return 0;
                 
            return Integrate(Integration.Trapezoidal, (t) => 1M / (1 + t * t), (0.0M, x), 40000);
        }

        /// <summary>
        /// Evaluate arcctg(x) with a specified precision
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="precision">An error</param>
        public static decimal Acot(decimal x, decimal precision = Epsilon)
        {
            var sign = Sign(x);

            //the infinite small x near 0
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
        /// <param name="steps">The number of iterations</param>
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

        /// <summary>
        /// Evaluate ceil(x) 
        /// </summary>
        /// <param name="x">The argument</param>
        public static decimal Ceil(decimal x)
        {
            if(x % 1 != 0)
            {
                return Floor(x) + 1;
            }

            return x;
        }

        /// <summary>
        /// Evaluate floor(x) 
        /// </summary>
        /// <param name="x">The argument</param>
        public static decimal Floor(decimal x)
        {
            var result = x - (x % 1);

            if(result == x)
            {
                return x;
            }

            if(x < 0)
            {
                return result - 1;
            }

            return result;
        }

        public static int NextInt32(Random random)
        {
            var firstBits = random.Next(0, 1 << 4) << 28;
            var lastBits  = random.Next(0, 1 << 28);

            return firstBits | lastBits;
        }

        public static decimal NextDecimal(Random random)
        {
            var sample = 1m;
           
            while (sample >= 1)
            {
                var a = NextInt32(random);
                var b = NextInt32(random);
                var c = random.Next(0x204FCE5E);

                sample = new Decimal(a, b, c, false, 28);
            }

            return sample;
        }

        public static decimal NextDecimal(Random random, decimal a, decimal b)
        {
            var nextDecimalSample = NextDecimal(random);
            return b * nextDecimalSample + a * (1 - nextDecimalSample);
        }
      
        /// <summary>
        /// Evaluate atan(x)
        /// </summary>
        /// <param name="x">The argument</param>

        public static decimal Atan(decimal x)
        {
            if (x == 0) return 0;

            if (x > 0) return AtanImpl(x);

            return -AtanImpl(-x);
        }

        /// <summary>
        /// Fused multiply - add
        /// </summary>
        public static decimal Fmad(decimal x, decimal y, decimal z)
        {
            return (x * y) + z;
        }

        /// <summary>
        /// Evaluate x mod b as x - b floor(x/b)
        /// </summary>
        /// <param name="x">The argument</param>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static decimal Mod(decimal x, decimal mod)
        {
            return x - mod * Floor(x / mod);
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

       private static decimal MonteCarlo(Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
            var b = interval.x2;
            var a = interval.x1;

            var generator = new Random(DateTime.UtcNow.Second);
            var result = 0.0M;
            var coef = (b - a) / N;

            for(var k = 0; k < N; ++k)
            {
                result += f(NextDecimal(generator, a, b));
            }

            return coef * result;
        }

        /// <summary>
        /// Approximate Atan in the range [0, 0.66]
        /// </summary>
        /// <param name="x">The argument</param>
        private static decimal AtanImpl(decimal x)
        {
            var P0 = -8.750608600031904122785e-01M;
            var P1 = -1.615753718733365076637e+01M;
            var P2 = -7.500855792314704667340e+01M;
            var P3 = -1.228866684490136173410e+02M;
            var P4 = -6.485021904942025371773e+01M;

            var Q0 = +2.485846490142306297962e+01M;
            var Q1 = +1.650270098316988542046e+02M;
            var Q2 = +4.328810604912902668951e+02M;
            var Q3 = +4.853903996359136964868e+02M;
            var Q4 = +1.945506571482613964425e+02M;

            var z = x * x;

            z = z * Fmad(Fmad(Fmad(Fmad(P0, z, P1), z, P2), z, P3), z, P4) /
                    Fmad(Fmad(Fmad(Fmad(z + Q0, z, Q1), z, Q2), z, Q3), z, Q4);

            return Fmad(x, z, x);

        }

        /// <summary>
        /// Reduce a positive argument to the [0, 0.66] 
        /// </summary>
        /// <param name="x">The argument</param>
        private static decimal AtanReduce(decimal x)
        {

            var bits = 6.123233995736765886130e-17M; // pi/2 = PIO2 + Morebits

            var tan3PiOver8 = 2.41421356237309504880M;     // tan(3*pi/8)

            if (x <= 0.66M)
            {
                return Atan(x);
            }

            if (x > tan3PiOver8)
            {
                return PI - Atan(1.0M / x) + bits;
            }

            return PI / 4.0M + Atan((x - 1.0M) / (x + 1.0M)) + 0.5M * bits;
        }
    }
}
