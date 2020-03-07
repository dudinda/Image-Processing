using System;
using System.Collections.Generic;

using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.DecimalMath.Complex
{
    public static class DecimalMathComplex
    {
        /// <summary>
        /// Evaluate Re(z)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Re(z)</returns>
        public static decimal Re((decimal x, decimal y) z)
        {
            return z.x;
        } 

        /// <summary>
        /// Evaluate Im(z)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Im(z)</returns>
        public static decimal Im((decimal x, decimal y) z)
        {
            return z.y;
        }

        /// <summary>
        /// Evaluate conjugate of z
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>conj(z)</returns>
        public static (decimal x, decimal y) Conj((decimal x, decimal y) z)
        {
            return (Re(z), -Im(z));
        }

        /// <summary>
        /// Evaluate |z|
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>|z|</returns>
        public static decimal Abs((decimal x, decimal y) z)
        {
            return DecimalMathReal.Hypot(Re(z), Im(z));
        }

        /// <summary>
        /// Evaluate z + z'
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z + z'</returns>
        public static (decimal x, decimal y) Add((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            checked
            {
                return (Re(z1) + Re(z2), Im(z1) + Im(z2));
            }
        }

        /// <summary>
        /// Evaluate z - z'
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z - z'</returns>
        public static (decimal x, decimal y) Sub((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            checked
            {
                return (Re(z1) - Re(z2), Im(z1) - Re(z2));
            }
        }

        /// <summary>
        /// Evaluate zz'
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>zz'</returns>
        public static (decimal x, decimal y) Mul((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            checked
            {
                return ((Re(z1) * Re(z2) - Im(z1) * Im(z2), Re(z1) * Im(z2) + Im(z1) * Re(z2)));
            }
        }

        /// <summary>
        /// Evaluate z/z'
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z/z'</returns>
        public static (decimal x, decimal y) Div((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            var numerator = Mul(z1, Conj(z2));

            checked
            {
                var denominator = Re(z2) * Re(z2) + Im(z2) * Im(z2);

                return (Re(numerator) / denominator, Im(numerator) / denominator);
            }
        }
        
        /// <summary>
        /// Evaluate cos(z) as cos(x)cosh(y) - isin(x)sinh(y)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>cos(z)</returns>
        public static (decimal x, decimal y) Cos((decimal x, decimal y) z)
        {
            return (DecimalMathReal.Cos(Re(z)) * DecimalMathReal.Cosh(Im(z)), -DecimalMathReal.Sin(Re(z)) * DecimalMathReal.Sinh(Im(z)));
        }

        /// <summary>
        /// Evaluate tan(z) as sin(2x) + isinh(2y) over cos(2x) + cosh(2y)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static (decimal x, decimal y) Tan((decimal x, decimal y) z)
        {
            var denominator = DecimalMathReal.Cos(2 * Re(z)) + DecimalMathReal.Cosh(2 * Im(z));

            return (DecimalMathReal.Sin(2 * Re(z)) / denominator, DecimalMathReal.Sinh(2 * Im(z)) / denominator);
        }

        /// <summary>
        /// Evaluate sin(z) as sin(x)cosh(y) + icos(x)sinh(y)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>sin(z)</returns>
        public static (decimal x, decimal y) Sin((decimal x, decimal y) z)
        {
            return (DecimalMathReal.Sin(Re(z)) * DecimalMathReal.Cosh(Im(z)), DecimalMathReal.Cos(Re(z)) * DecimalMathReal.Sinh(Im(z)));
        }

        /// <summary>
        /// Evaluate Arg(z)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static decimal Arg((decimal x, decimal y) z)
        {
            if(Re(z) > 0 && Im(z) != 0)
            {
                return 2 * DecimalMathReal.Arctan(Im(z) / (Abs(z) + Re(z)));
            }

            if(Re(z) < 0 && Im(z) == 0 )
            {
                return DecimalMathReal.PI;
            }

            throw new ArgumentException("NaN");
        }

        /// <summary>
        /// Transform z to polar form
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>(r, phi)</returns>
        public static (decimal r, decimal phi) Polar((decimal x, decimal y) z)
        {
            return (Abs(z), Arg(z));
        }

        /// <summary>
        /// Transfrom polar form to cartesian representation.
        /// </summary>
        /// <param name="z">r, phi</param>
        /// <returns>x + iy</returns>
        public static (decimal x, decimal y) FromPolar((decimal r, decimal phi) z)
        {
            var (sin, cos) = DecimalMathReal.SinCos(z.phi);

            return (sin * z.r, cos * z.r);
        }

        /// <summary>
        /// Evaluate exp(z)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>exp(z)</returns>
        public static (decimal x, decimal y) Exp((decimal x, decimal y) z)
        {
            var r          = DecimalMathReal.Exp(Re(z));
            var (sin, cos) = DecimalMathReal.SinCos(Im(z));

            return (sin * r, cos * r);
            
        }

        /// <summary>
        /// Evaluate log(z) as log(r) + iarg(z)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="lbase"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static (decimal x, decimal y) Log((decimal x, decimal y) z, decimal lbase = DecimalMathReal.E, decimal precision = DecimalMathReal.Epsilon)
        {
            return (DecimalMathReal.Log(Abs(z), lbase, precision), Arg(z));
        }


        /// <summary>
        /// Evaluate z ** 1/k
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="k">Root</param>
        /// <returns>z ** 1/k</returns>
        public static (decimal x, decimal y)[] KRoots((decimal x, decimal y) z, int k)
        {
            var list = new List<(decimal x, decimal y)>();
            var (r, phi) = Polar(z);

            var rootOfR = DecimalMathReal.Pow(r, 1 / k);

            for(var n = 0; n < k; ++n)
            {
                var (cos, sin) = DecimalMathReal.SinCos(2 * DecimalMathReal.PI * n / k);

                list.Add((rootOfR * cos, rootOfR * sin));
            }

            return list.ToArray();
        }


    }
}
