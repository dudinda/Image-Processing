using System;

using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.DecimalMath.Complex
{
    public static class DecimalMathComplex
    {
        /// <summary>
        /// Evaluate Re(z)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static decimal Re((decimal x, decimal y) z)
        {
            return z.x;
        } 

        /// <summary>
        /// Evaluate Im(z)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static decimal Im((decimal x, decimal y) z)
        {
            return z.y;
        }

        /// <summary>
        /// Evaluate conjugate of z
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static (decimal x, decimal y) Conj((decimal x, decimal y) z)
        {
            return (z.x, -z.y);
        }

        /// <summary>
        /// Evaluate |z|
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static decimal Abs((decimal x, decimal y) z)
        {
            return DecimalMathReal.Hypot(z.x, z.y);
        }

        /// <summary>
        /// Evaluate z + z'
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns></returns>
        public static (decimal x, decimal y) Add((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            return (z1.x + z2.x, z1.y + z2.y);
        }

        /// <summary>
        /// Evaluate z - z'
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns></returns>
        public static (decimal x, decimal y) Sub((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            return (z1.x - z2.x, z1.y - z2.y);
        }

        /// <summary>
        /// Evaluate zz'
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns></returns>
        public static (decimal x, decimal y) Mul((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            return ((z1.x * z2.x - z1.y * z2.y, z1.x * z2.y + z1.y * z2.x));
        }

        /// <summary>
        /// Evaluate z/z'
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns></returns>
        public static (decimal x, decimal y) Div((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            var numerator = Mul(z1, Conj(z2));
            var denominator = z2.x * z2.x + z2.y * z2.y;

            return (numerator.x / denominator, numerator.y / denominator); 
        }
        


        /// <summary>
        /// Evaluate cos(z) as cos(x)cosh(y) - isin(x)sinh(y)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static (decimal x, decimal y) Cos((decimal x, decimal y) z)
        {
            return (DecimalMathReal.Cos(z.x) * DecimalMathReal.Cosh(z.y), -DecimalMathReal.Sin(z.x) * DecimalMathReal.Sinh(z.y));
        }

        /// <summary>
        /// Evaluate sin(z) as sin(x)cosh(y) + icos(x)sinh(y)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static (decimal x, decimal y) Sin((decimal x, decimal y) z)
        {
            return (DecimalMathReal.Sin(z.x) * DecimalMathReal.Cosh(z.y), DecimalMathReal.Cos(z.x) * DecimalMathReal.Sinh(z.y));
        }

        /// <summary>
        /// Evaluate Arg(z)
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static decimal Arg((decimal x, decimal y) z)
        {
            if(z.x > 0 && z.y != 0)
            {
                return 2 * DecimalMathReal.Arctan(z.y / (Abs(z) + z.x));
            }

            if(z.x < 0 && z.y == 0 )
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


    }
}
