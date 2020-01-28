using System;

namespace ImageProcessing.DecimalMath.Real
{
    /// <summary>
    /// The class contains functions of a real variable,
    /// where each argument is represented as <see cref="decimal">
    /// </summary>
    public static class DecimalMathReal
    {
        public const decimal E = 2.71828182845905M;
        public const decimal Epsilon = 1.0E-26M;
        public const decimal PI = 3.14159265358979323846M;
        public const decimal Euler = 0.57721566490153286060M;

        /// <summary>
        /// Evaluate sgn(x)
        /// </summary>
        /// <param name="x">An argument of the function</param>
        public static decimal Sign(decimal x)
        {
            if (x == 0) return 0;

            return x > 0 ? 1 : -1;
        }
     
        /// <summary>
        /// Evaluate max{x, y}
        /// </summary>
        /// <param name="x">The left-hand value</param>
        /// <param name="y">The right-hand value</param>
        public static decimal Max(decimal x, decimal y)
        {
            return x > y ? x : y;
        }

        /// <summary>
        /// Evaluate min{x, y}
        /// </summary>
        /// <param name="x">The left-hand value</param>
        /// <param name="y">The right-hand value</param>
        public static decimal Min(decimal x, decimal y)
        {
            return x < y ? x : y;
        }

        /// <summary>
        /// Evaluate hypot(x, y)
        /// </summary>
        /// <param name="x">The left-hand value</param>
        /// <param name="y">The right-hand value</param>
        public static decimal Hypot(decimal x, decimal y)
        {

            if (x > y)
            {
                return Abs(x) * Sqrt(1 + (y / x) * (y / x));
            }

            if (x < y)
            {
                return Abs(y) * Sqrt((x / y) * (x / y) + 1);
            }

            checked
            {
                //x = y
                return Abs(x) * Sqrt(2);
            }
        }

        /// <summary>
        /// Evaluate |x|
        /// </summary>
        /// <param name="x">An argument of the function</param>
        public static decimal Abs(decimal x)
        {
            return x >= 0 ? x : -x;
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
        /// <param name="x">An argument of the function</param>
        public static decimal Floor(decimal x)
        {
            var result = x - (x % 1);

            if (result == x)
            {
                return x;
            }

            if (x < 0)
            {
                return result - 1;
            }

            return result;
        }

        /// <summary>
        /// Evaluate x mod b as x - b floor(x/b)
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static decimal Mod(decimal x, decimal mod)
        {
            checked
            {
                return x - mod * Floor(x / mod);
            }
        }

        #region Log and exp functions

        /// <summary>
        /// Evaluate sqrt(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        public static decimal Sqrt(decimal value, decimal precision = Epsilon)
        {
            if (value < 0)
            {
                throw new ArgumentException("The value must be positive real.");
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
        /// Evaluate x ** power with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
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
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        public static decimal Exp(decimal x, decimal precision = Epsilon)
        {
            var total = 1.0M;
            var result = total;

            checked
            {
                for (var k = 1; Abs(total) > precision; ++k)
                {
                    total = total * x / k;
                    result += total;
                }
            }

            return result;
        }
    
        /// <summary>
        /// Evaluate log(x) based on Arithmetic-Geometric Mean (Borchardt's algorithm) 
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        public static decimal Log(decimal x, decimal lbase = E, decimal precision = Epsilon)
        {
            if(x < 0)
            {
                throw new ArgumentException("The value must be a positive real number");
            }

            if(x == 0)
            {
                throw new ArgumentException("-inf");
            }

            if(lbase <= 0 || lbase == 1)
            {
                throw new ArgumentException("A logarithm base must be in (0, 1) U (1, +inf)");
            }

            if(x == 1.0M)
            {
                return 0;
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

        #endregion
       
        #region Trigonometric functions

        /// <summary>
        /// Evaluate sin(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        public static decimal Sin(decimal x, decimal precision = Epsilon)
        {
            x = Mod(x, 2.0M * PI);

            var total = x;
            var result = total;

            for (var k = 0; Abs(total) > precision; ++k)
            {
                total = -total * x * x / Fmad(k, Fmad(4, k, 10), 6);
                result += total;
            }

            return result;
        }

        /// <summary>
        /// Evaluate cos(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        public static decimal Cos(decimal x, decimal precision = Epsilon)
        {
            x = Mod(x, 2.0M * PI);

            var total = 1.0M;
            var result = total;

            for (var k = 0; Abs(total) > precision; ++k)
            {
                total = total * -x * x / Fmad(k, Fmad(4, k, 6), 2);
                result += total;
            }

            return result;
        }

        /// <summary>
        /// Evaluate cot(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        public static decimal Cot(decimal x, decimal precision = Epsilon)
        {
            return 1.0M / Tan(x, precision);
        }

        /// <summary>
        /// Evaluate tan(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        public static decimal Tan(decimal x, decimal precision = Epsilon)
        {
            x = Mod(x, PI);

            var error = Abs(Abs(x) - PI / 2.0M);

            //x infinitely small to -+PI over 2
            if (error < precision)
            {
                switch (Sign(x))
                {
                    case -1: throw new ArgumentException("-inf");
                    case  1: throw new ArgumentException("+inf");
                }
            }

            return Sin(x) / Cos(x);
        }

        #endregion

        #region Inverse trigonometric functions

        /// <summary>
        /// Evaluate atan(x)
        /// </summary>
        /// <param name="x">An argument of the function</param>

        public static decimal Arctan(decimal x)
        {
            if (x == 0) return 0;

            if (x > 0) return ArctanReduce(x);

            return -ArctanReduce(-x);
        }

        /// <summary>
        /// Evaluate arccot(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        public static decimal Arccot(decimal x)
        {
            return Sign(x) * PI / 2.0M - Arctan(x);
        }

        /// <summary>
        /// Evaluate arcsin(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        public static decimal Arcsin(decimal x)
        {
            if (Abs(x) > 1)
            {
                throw new ArgumentException("NaN");
            }

            return Arctan(x / Sqrt(1.0M - x * x));
        }

        /// <summary>
        /// Evaluate arccos(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        public static decimal Arccos(decimal x)
        {
            return PI / 2.0M - Arcsin(x);
        }

        /// <summary>
        /// Approximate atan(x) in the range [0, 0.66]
        /// </summary>
        /// <param name="x">An argument of the function</param>
        private static decimal ArctanImpl(decimal x)
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
        private static decimal ArctanReduce(decimal x)
        {

            var bits = 6.123233995736765886130e-17M; // pi/2 = PIO2 + bits

            var tan3PiOver8 = 2.41421356237309504880M;     // tan(3*pi/8)

            if (x <= 0.66M)
            {
                return ArctanImpl(x);
            }

            if (x > tan3PiOver8)
            {
                return PI / 2.0M - ArctanImpl(1.0M / x) + bits;
            }

            return PI / 4.0M + ArctanImpl((x - 1.0M) / (x + 1.0M)) + 0.5M * bits;
        }

        #endregion

        #region Hyberbolic functions

        /// <summary>
        /// Evaluate cosh(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
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
        /// <param name="x">An argument of the function</param>
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
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        public static decimal Tanh(decimal x, decimal precision = Epsilon)
        {
            return Sinh(x, precision) / Cosh(x, precision);
        }

        /// <summary>
        /// Evaluate coth(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        public static decimal Coth(decimal x, decimal precision = Epsilon)
        {
            //x infinitely small to 0
            if (Abs(x) < precision)
            {
                switch (Sign(x))
                {
                    case -1: throw new ArgumentException("-inf");
                    case  1: throw new ArgumentException("+inf");
                }
            }

            return 1.0M / Tanh(x, precision);
        }

        #endregion

        #region Inverse hyperbolic functions

        /// <summary>
        /// Evaluate arcosh(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        public static decimal Arcosh(decimal x, decimal precision = Epsilon)
        {
            if (x < 1)
            {
                throw new ArgumentException("NaN");
            }

            return Log(x + Sqrt(x * x - 1, precision), precision: precision);
        }

        /// <summary>
        /// Evaluate arsinh(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        public static decimal Arsinh(decimal x, decimal precision = Epsilon)
        {
            return Log(x + Sqrt(x * x + 1, precision), precision: precision);
        }

        /// <summary>
        /// Evaluate artanh(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        public static decimal Artanh(decimal x, decimal precision = Epsilon)
        {
            if (Abs(x) >= 1)
            {
                throw new ArgumentException("NaN");
            }

            return 0.5M * Log((1.0M + x) / (1.0M - x), precision: precision);
        }

        /// <summary>
        /// Evaluate arcoth(x) with a specified precision
        /// </summary>
        /// <param name="x">An argument of the function</param>
        public static decimal Arcoth(decimal x, decimal precision = Epsilon)
        {
            if (Abs(x) <= 1)
            {
                throw new ArgumentException("NaN");
            }

            return 0.5M * Log((x + 1.0M) / (x - 1.0M), precision: precision);
        }

        #endregion
    }
}
