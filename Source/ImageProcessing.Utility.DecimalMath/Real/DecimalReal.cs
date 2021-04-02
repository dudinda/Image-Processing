using System;

namespace ImageProcessing.Utility.DecimalMath.Real
{
    /// <summary>
    /// The class contains functions of a real variable,
    /// where each argument is represented as the <see cref="decimal"> value.
    /// </summary>
    public class DecimalReal
    {
        public const decimal E       = 2.71828182845905M;
        public const decimal Epsilon = 1.0E-26M;
        public const decimal PI      = 3.14159265358979323846M;
        public const decimal PiOver2 = 1.57079632679489661923M;
        public const decimal Euler   = 0.57721566490153286060M;
        public const decimal Sqrt2   = 1.41421356237309504880M;
        public const decimal Ln2     = 0.69314718055994530941M;

        /// <summary>
        /// Taylor series of exp(x) throws overflow exception
        /// during the loop when x > 65.370524. 
        /// </summary>
        private const decimal ExpOverflow       = 65.370524M;

        /// <summary>
        /// x ** 2 throws overflow exception
        /// when x > 281474976710656.
        /// </summary>
        private const decimal SquareOfXOverflow = 281474976710656M;

        /// <summary>
        /// Evaluate sgn(x).
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>sgn(x)</returns>
        public int Sign(decimal x)
        {
            if (x == 0.0M) { return 0; }
     
            return x > 0.0M ? 1 : -1;
        }
     
        /// <summary>
        /// Evaluate max{x, y}.
        /// </summary>
        /// <param name="x">The left-hand value</param>
        /// <param name="y">The right-hand value</param>
        /// <returns>max{x, y}</returns>
        public decimal Max(decimal x, decimal y)
            => x >= y ? x : y;
        
        /// <summary>
        /// Evaluate min{x, y}.
        /// </summary>
        /// <param name="x">The left-hand value</param>
        /// <param name="y">The right-hand value</param>
        /// <returns>min{x, y}</returns>
        public decimal Min(decimal x, decimal y)
            => x <= y ? x : y;
        
        /// <summary>
        /// Evaluate hypot(x, y).
        /// </summary>
        /// <param name="x">The left-hand value</param>
        /// <param name="y">The right-hand value</param>
        /// <returns>hypot(x, y)</returns>
        public decimal Hypot(decimal x, decimal y)
        {
            if (x > y)
            {
                var d = y / x;
                return Abs(x) * Sqrt(1.0M + d * d);
            }

            if (x < y)
            {
                var d = x / y;
                return Abs(y) * Sqrt(d * d + 1.0M);
            }

            if (x == 0.0M && y == 0.0M)
            {
                return 0.0M;
            }

            //x = y
            return Abs(x) * Sqrt2;
        }

        /// <summary>
        /// Evaluate |x|.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>|x|</returns>
        public decimal Abs(decimal x)
            => x >= 0.0M ? x : -x;
        
        /// <summary>
        /// Evaluate ceil(x).
        /// </summary>
        /// <param name="x">An argument of a function</param>
        /// <returns>ceil(x)</returns>
        [Obsolete("Use Decimal.Ceiling(x) instead.")]
        public decimal Ceil(decimal x)
            => -Floor(-x);

        /// <summary>
        /// Evaluate floor(x).
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>floor(x)</returns>
        [Obsolete("Use Decimal.Floor(x) instead.")]
        public decimal Floor(decimal x)
        {
            if (x == 0.0M) { return x; }
           
            var result = x - decimal.Remainder(x, 1.0M);

            if (x < 0.0M)
            {
                if(result == x) { return result; }

                return result - 1.0M;
            }

            return result;
        }

        /// <summary>
        /// Evaluate {x}.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>{x}</returns>
        [Obsolete("Use Decimal.Remainder(x, 1.0M) instead.")]
        public decimal Frac(decimal x)
            => x % 1.0M;

        /// <summary>
        /// Evaluate x mod b as x - b floor(x/b).
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="mod"></param>
        /// <returns>x mod b</returns>
        public decimal Mod(decimal x, decimal mod)
            => x - mod * Math.Floor(x / mod);

        #region Log and exp functions

        /// <summary>
        /// Evaluate sqrt(x) digit - by - digit.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>sqrt(x)</returns>
        public decimal Sqrt(decimal x, decimal precision = Epsilon)
        {
            if (x < 0M)
            {
                throw new ArgumentException(nameof(x));
            }

            if(x == 1.0M || x == 0M) { return x; }

            var current = (decimal)Math.Sqrt((double)x);
            decimal previous;

            do
            {
                previous = current;

                current = (previous + x / previous) * 0.5M;
            }
            while (Math.Abs(previous - current) > Epsilon);

            return current;
        }

        /// <summary>
        /// Evaluate x ** power with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="power">A power</param>
        /// <param name="precision">A error</param>
        /// <returns>x ** power</returns>
        public decimal Pow(decimal x, decimal power, decimal precision = Epsilon)
        {
            if (x < 0.0M)
            {
                throw new ArgumentException("The value must be a positive real number");
            }

            // 0 ** 0 = 1
            if(x == 0.0M && power == 0.0M)
            {
                return 1.0M;
            }

            return Exp(power * Log(x, precision: precision));
        }

        /// <summary>
        /// Evaluate exp(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>exp(x)</returns>
        public decimal Exp(decimal x, decimal precision = Epsilon)
        {
            if (x > ExpOverflow)
            {
                throw new OverflowException(nameof(x));
            }

            if (x == 0.0M)
            {
                return 1.0M;
            }

            var total = 1.0M;
            var result = total;

            var k = 1.0M;

            do
            {
                total = total * x / k;
                result += total;
                ++k;
            } while (Abs(total) > precision);

            return result;
        }
    
        /// <summary>
        /// Evaluate log(x) based on Arithmetic-Geometric Mean (Borchardt's algorithm).
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>log(x)</returns>
        public decimal Log(decimal x, decimal lbase = E, decimal precision = Epsilon)
        {
            if(x < 0.0M)
            {
                throw new ArgumentException("The value must be a positive real number");
            }

            if(x == 0.0M)
            {
                throw new ArgumentException("-inf");
            }

            if(lbase <= 0.0M || lbase == 1.0M)
            {
                throw new ArgumentException("A logarithm base must be in (0, 1) U (1, +inf)");
            }

            if(x == 1.0M) { return 0.0M; }
   
            if (Abs(E - lbase) > precision)
            {
                return Log(x) / Log(lbase);
            }

            var a0 = (1.0M + x) * 0.5M;
            var b0 = Sqrt(x, precision);

            var eps = a0 - b0;

            while (Abs(eps) > precision)
            {
                a0 = (a0 + b0) * 0.5M;
                b0 = Sqrt(a0 * b0, precision);

                if(eps == (eps = a0 - b0)) { break; }
            }

            return 2.0M * (x - 1.0M) / (a0 + b0);
        }

        #endregion
       
        #region Trigonometric functions

        /// <summary>
        /// Evaluate sin(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>sin(x)</returns>
        public decimal Sin(decimal x, decimal precision = Epsilon)
        {
            if(x == 0.0M) { return 0; }

            x = Mod(x, 2.0M * PI);

            var total = x;
            var result = total;

            var k = 0.0M;

            do
            {
                total = -total * x * x / (k * (4M * k + 10M) + 6M);
                result += total;
                ++k;
            } while (Abs(total) > precision);

            return result;
        }

        /// <summary>
        /// Evaluate cos(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>cos(x)</returns>
        public decimal Cos(decimal x, decimal precision = Epsilon)
        {
            x = Mod(x, 2.0M * PI);

            var total = 1.0M;
            var result = total;

            var k = 0.0M;

            do
            {
                total = total * -x * x / (k * (4M * k + 6M) + 2M);
                result += total;
                ++k;
            } while (Abs(total) > precision);

            return result;
        }

        /// <summary>
        /// Evaluate cot(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>cot(x)</returns>
        public decimal Cot(decimal x, decimal precision = Epsilon)
        {
            var sign = Sign(x);

            x = Mod(x, PI);

            if(Abs(x - PiOver2) < Epsilon)
            {
                return 0;
            }

            //x infinitely small to -+PI
            if (x < precision)
            {
                switch (sign)
                {
                    case -1: throw new ArgumentException("-inf");
                    case  1: throw new ArgumentException("+inf");
                }
            }

            return Cos(x) / Sin(x);
        }

        
        /// <summary>
        /// Evaluate tan(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>tan(x)</returns>
        public decimal Tan(decimal x, decimal precision = Epsilon)
        {
            var sign = Sign(x);

            x = Mod(x, PI);

            var error = Abs(x - PiOver2);

            //x infinitely small to -+PI over 2
            if (error < precision)
            {
                switch (sign)
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
        /// Evaluate atan(x).
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>atan(x)</returns>
        public decimal Arctan(decimal x)
        {
            if (x == 0.0M)
            {
                return 0.0M;
            } 

            if (x > 0.0M)
            {
                return ArctanReduce(x);
            }

            return -ArctanReduce(-x);
        }

        /// <summary>
        /// Evaluate arccot(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>arccot(x)</returns>
        public decimal Arccot(decimal x)
        {
            if (x == 0.0M)
            {
                return PiOver2;
            }

            return Sign(x) * PiOver2 - Arctan(x);
        }
        
        /// <summary>
        /// Evaluate arcsin(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>arcsin(x)</returns>
        public decimal Arcsin(decimal x)
        {
            if (Abs(x) > 1.0M)
            {
                throw new ArgumentException("NaN");
            }

            return Arctan(x / Sqrt(1.0M - x * x));
        }

        /// <summary>
        /// Evaluate arccos(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>arccos(x)</returns>
        public decimal Arccos(decimal x)
            => PiOver2 - Arcsin(x);
        
        /// <summary>
        /// Approximate atan(x) in the range [0, 0.66].
        /// </summary>
        /// <param name="x">An argument of the function</param>
        private decimal ArctanImpl(decimal x)
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

            z = z * ((((p0 * z + p1) * z + p2) * z + p3) * z + p4) /
                    (((((z + q0) * z + q1) * z + q2) * z + q3) * z + q4);

            return (x * z + x);

        }

        /// <summary>
        /// Reduce a positive argument to the [0, 0.66].
        /// </summary>
        /// <param name="x">An argument of a function to be reduced</param>
        private decimal ArctanReduce(decimal x)
        {

            var bits = 6.123233995736765886130e-17M; // pi/2 = PIO2 + bits

            var tan3PiOver8 = 2.41421356237309504880M;     // tan(3*pi/8)

            if (x <= 0.66M)
            {
                return ArctanImpl(x);
            }

            if (x > tan3PiOver8)
            {
                return PiOver2 - ArctanImpl(1.0M / x) + bits;
            }

            return PI * 0.25M + ArctanImpl((x - 1.0M) / (x + 1.0M)) + 0.5M * bits;
        }

        #endregion

        #region Hyberbolic functions

        /// <summary>
        /// Evaluate cosh(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>cosh(x)</returns>
        public decimal Cosh(decimal x, decimal precision = Epsilon)
        {
            var exp = Exp(Abs(x), precision);

            return (exp + 1.0M / exp) * 0.5M;
        }

        /// <summary>
        /// Evaluate sinh(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>sinh(x)</returns>
        public decimal Sinh(decimal x, decimal precision = Epsilon)
        {
            var sign = Sign(x);

            var result = Exp(Abs(x), precision);

            return sign * (result - 1.0M / result) * 0.5M;
        }

        /// <summary>
        /// Evaluate tanh(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>tanh(x)</returns>
        public decimal Tanh(decimal x, decimal precision = Epsilon)
            => Sinh(x, precision) / Cosh(x, precision);
        
        /// <summary>
        /// Evaluate coth(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <param name="precision">A error</param>
        /// <returns>coth(x)</returns>
        public decimal Coth(decimal x, decimal precision = Epsilon)
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
        /// Evaluate arcosh(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>arcosh(x)</returns>
        public decimal Arcosh(decimal x, decimal precision = Epsilon)
        {
            if (x > SquareOfXOverflow)
            {
                throw new OverflowException(nameof(x));
            }

            if (x < 1.0M)
            {
                throw new ArgumentException("NaN");
            }
            
            return Log(x + Sqrt(x * x - 1.0M, precision), precision: precision);
        }

        /// <summary>
        /// Evaluate arsinh(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>arcsinh(x)</returns>
        public decimal Arsinh(decimal x, decimal precision = Epsilon)
        {
            if (x > SquareOfXOverflow)
            {
                throw new OverflowException(nameof(x));
            }

            return Log(x + Sqrt(x * x + 1.0M), precision: precision); 
        }

        /// <summary>
        /// Evaluate artanh(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>artanh(x)</returns>
        public decimal Artanh(decimal x, decimal precision = Epsilon)
        {
            if (Abs(x) >= 1.0M)
            {
                throw new ArgumentException("NaN");
            }

            return 0.5M * Log((1.0M + x) / (1.0M - x), precision: precision);
        }

        /// <summary>
        /// Evaluate arcoth(x) with a specified precision.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>arcoth(x)</returns>
        public decimal Arcoth(decimal x, decimal precision = Epsilon)
        {
            if (Abs(x) <= 1.0M)
            {
                throw new ArgumentException("NaN");
            }

            return 0.5M * Log((x + 1.0M) / (x - 1.0M), precision: precision);
        }

        /// <summary>
        /// Evaluate cos(x) and sin(x) simultaneously.
        /// </summary>
        /// <param name="x">An argument of the function</param>
        /// <returns>cos(x), sin(x)</returns>
        public (decimal sin, decimal cos) CosSin(decimal x)
            => (Cos(x), Sin(x));
        
        #endregion
    }
}
