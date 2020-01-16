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
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
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
        /// <param name="x">An argument of a function</param>
        public static decimal Sign(decimal x)
        {
            if (x == 0) return 0;

            return x > 0 ? 1 : -1;
        }


        /// <summary>
        /// Evaluate |x|
        /// </summary>
        /// <param name="x">An argument of a function</param>
        public static decimal Abs(decimal x)
        {
            return x >= 0 ? x : -x;
        }

        /// <summary>
        /// Evaluate x ** power with a specified precision
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="power">A power</param>
        /// <param name="precision">A error</param>
        public static decimal Pow(decimal value, decimal power, decimal precision = Epsilon)
        {
            if(value < 0)
            {
                throw new ArgumentException("The value must be a positive real number");
            }

            checked
            {
                return Exp(power * Log(value, precision: precision));
            }
        }

        /// <summary>
        /// Evaluate exp(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
        public static decimal Exp(decimal x, decimal precision = Epsilon)
        {
            var total = 1.0M;
            var result = total;

            checked
            {
                for (var k = 1; Abs(total) > Epsilon; ++k)
                {
                    total = total * x / k;
                    result += total;
                }
            }

            return result;
        }

        /// <summary>
        /// Evaluate sin(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
        public static decimal Sin(decimal x, decimal precision = Epsilon)
        {
            x = Mod(x, 2.0M * PI);

            var total = x;
            var result = total;

            for (var k = 0; Abs(total) > Epsilon; ++k)
            {
                total = -total *  x * x / ((2.0M * k + 2.0M) * (2.0M * k + 3.0M));
                result += total;
            }

            return result;
        }

        /// <summary>
        /// Evaluate cos(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
        public static decimal Cos(decimal x, decimal precision = Epsilon)
        {
            x = Mod(x, 2 * PI);

            var total = 1.0M;
            var result = total;

            for (var k = 0; Abs(total) > Epsilon; ++k)
            {
                total = total * -x * x / ((2 * k + 1) * (2 * k + 2));
                result += total;
            }

            return result;
        }

        /// <summary>
        /// Evaluate cosh(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
        public static decimal Cosh(decimal x, decimal precision = Epsilon)
        {
            checked
            {
                return (Exp(x, precision) + Exp(-x, precision)) / 2.0M;
            }
        }

        /// <summary>
        /// Evaluate sinh(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
        public static decimal Sinh(decimal x, decimal precision = Epsilon)
        {
            checked
            {
                return (Exp(x, precision) - Exp(-x, precision)) / 2.0M;
            }
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
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
        public static decimal Cot(decimal x, decimal precision = Epsilon)
        {
            return 1.0M / Tan(x, precision);
        }

        /// <summary>
        /// Evaluate tan(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
        public static decimal Tan(decimal x, decimal precision = Epsilon)
        {
            x = Mod(x, PI);

            var error = Abs(Abs(x) - PI / 2.0M);

            //x infinitely small to -+PI over 2
            if(error < precision )
            {
                switch(Sign(x))
                {
                    case -1: throw new ArgumentException("-inf");
                    case  1: throw new ArgumentException("+inf");
                }
            } 

            return Sin(x) / Cos(x);
        }

        /// <summary>
        /// Evaluate log(x) based on Borchardt's algorithm 
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
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
                return Log(x) / Log(lbase);
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
        /// Evaluate arcctg(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="precision">A error</param>
        public static decimal Acot(decimal x, decimal precision = Epsilon)
        {
            var sign = Sign(x);

            //x infinitely close to zero
            if(Abs(x) < Abs(precision) && x != 0) {
                return sign * PI / 2.0M;
            }

            if (x == 0.0M) return PI / 2.0M;

            return sign * PI / 2.0M -  Atan(x);
        }

       

        /// <summary>
        /// Evaluate ceil(x) 
        /// </summary>
        /// <param name="x">An argument of a function</param>
        public static decimal Ceil(decimal x)
        {
            checked
            {
                if (x % 1 != 0)
                {
                    return Floor(x) + 1;
                }
            }
            return x;
        }

        /// <summary>
        /// Evaluate floor(x) 
        /// </summary>
        /// <param name="x">An argument of a function</param>
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

                sample = new decimal(a, b, c, false, 28);
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
        /// <param name="x">An argument of a function</param>

        public static decimal Atan(decimal x)
        {
            if (x == 0) return 0;

            if (x > 0) return AtanReduce(x);

            return -AtanReduce(-x);
        }

        /// <summary>
        /// Fused multiply - add decimal
        /// </summary>
        public static decimal Fmad(decimal x, decimal y, decimal z)
        {
            checked
            {
                return (x * y) + z;
            }
        }

        /// <summary>
        /// Evaluate x mod b as x - b floor(x/b)
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static decimal Mod(decimal x, decimal mod)
        {
            checked
            {
                return x - mod * Floor(x / mod);
            }
        }

        /// <summary>
        /// Approximate Atan in the range [0, 0.66]
        /// </summary>
        /// <param name="x">An argument of a function</param>
        private static decimal AtanImpl(decimal x)
        {
            var p0 = -8.750608600031904122785e-01M;
            var p1 = -1.615753718733365076637e+01M;
            var p2 = -7.500855792314704667340e+01M;
            var p3 = -1.228866684490136173410e+02M;
            var p4 = -6.485021904942025371773e+01M;

            var q0 = +2.485846490142306297962e+01M;
            var q1 = +1.650270098316988542046e+02M;
            var q2 = +4.328810604912902668951e+02M;
            var q3 = +4.853903996359136964868e+02M;
            var q4 = +1.945506571482613964425e+02M;

            var z = x * x;

            z = z * Fmad(Fmad(Fmad(Fmad(p0, z, p1), z, p2), z, p3), z, p4) /
                    Fmad(Fmad(Fmad(Fmad(z + q0, z, q1), z, q2), z, q3), z, q4);

            return Fmad(x, z, x);

        }

        /// <summary>
        /// Reduce a positive argument to the [0, 0.66] 
        /// </summary>
        /// <param name="x">An argument of a function to be reduced</param>
        private static decimal AtanReduce(decimal x)
        {

            var bits = 6.123233995736765886130e-17M; // pi/2 = PIO2 + bits

            var tan3PiOver8 = 2.41421356237309504880M;     // tan(3*pi/8)

            if (x <= 0.66M)
            {
                return AtanImpl(x);
            }

            if (x > tan3PiOver8)
            {
                return PI / 2.0M - AtanImpl(1.0M / x) + bits;
            }

            return PI / 4.0M + AtanImpl((x - 1.0M) / (x + 1.0M)) + 0.5M * bits;
        }
    }
}
