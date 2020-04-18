using System;
using System.Collections.Generic;

using ImageProcessing.Utility.DecimalMath.Code.Structs;

using Real = ImageProcessing.Utility.DecimalMath.RealAxis.DecimalMathReal;

namespace ImageProcessing.Utility.DecimalMath.ComplexPlane
{
    public static class DecimalMathComplex
    {
        /// <summary>
        /// Evaluate Re(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Re(z)</returns>
        public static decimal Re((decimal x, decimal y) z)
            => z.x;
      
        /// <summary>
        /// Evaluate Im(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Im(z)</returns>
        public static decimal Im((decimal x, decimal y) z)
            => z.y;
        
        /// <summary>
        /// Evaluate conjugate of z.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>conj(z)</returns>
        public static (decimal x, decimal y) Conj((decimal x, decimal y) z)
            => (z.x, -z.y);

        /// <summary>
        /// Evaluate 1 / z.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public static (decimal x, decimal y) Reciprocal((decimal x, decimal y) z)
            => 1.0M / (ComplexOperator)z;

        /// <summary>
        /// Evaluate |z|.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>|z|</returns>
        public static decimal Abs((decimal x, decimal y) z)
            => Real.Hypot(z.x, z.y);

        /// <summary>
        /// Evaluate z + c.
        /// </summary>
        /// <param name="z">x  + iy</param>
        /// <param name="c">const</param>
        /// <returns>z + c</returns>
        public static (decimal x, decimal y) Add((decimal x, decimal y) z, decimal c)
            => (ComplexOperator)z + c;

        /// <summary>
        /// Evaluate c + z.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>c + z</returns>
        public static (decimal x, decimal y) Add(decimal c, (decimal x, decimal y) z)
            => (ComplexOperator)c + z;

        /// <summary>
        /// Evaluate z + z'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z + z'</returns>
        public static (decimal x, decimal y) Add((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 + z2;

        /// <summary>
        /// Evaluate z - z'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z - z'</returns>
        public static (decimal x, decimal y) Sub((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 - z2;

        /// <summary>
        /// Evaluate z - c.
        /// </summary>
        /// <param name="z">x  + iy</param>
        /// <param name="c">const</param>
        /// <returns>z - c</returns>
        public static (decimal x, decimal y) Sub((decimal x, decimal y) z, decimal c)
            => (ComplexOperator)z - c;

        /// <summary>
        /// Evaluate c - z.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>c - z</returns>
        public static (decimal x, decimal y) Sub(decimal c, (decimal x, decimal y) z)
            => (ComplexOperator)c - z;

        /// <summary>
        /// Evaluate zz'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>zz'</returns>
        public static (decimal x, decimal y) Mul((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 * z2;

        /// <summary>
        /// Evaluate Cz.
        /// </summary>
        /// <param name="z">x  + iy</param>
        /// <param name="c">const</param>
        /// <returns>Cz</returns>
        public static (decimal x, decimal y) Mul((decimal x, decimal y) z, decimal c)
            => (ComplexOperator)z * c;

        /// <summary>
        /// Evaluate zC.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>zC</returns>
        public static (decimal x, decimal y) Mul(decimal c, (decimal x, decimal y) z)
            => (ComplexOperator)c * z;

        /// <summary>
        /// Evaluate z/z'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z/z'</returns>
        public static (decimal x, decimal y) Div((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 / (ComplexOperator)z2;

        /// <summary>
        /// Evaluate c/z.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>c/z</returns>
        public static (decimal x, decimal y) Div(decimal c, (decimal x, decimal y) z2)
            => (ComplexOperator)c / z2;

        /// <summary>
        /// Evaluate z/c.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="z2">const</param>
        /// <returns>z/c</returns>
        public static (decimal x, decimal y) Div((decimal x, decimal y) z, decimal c)
            => (ComplexOperator)z / c;
        
        /// <summary>
        /// Evaluate cos(z) as cos(x)cosh(y) - isin(x)sinh(y).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>cos(z)</returns>
        public static (decimal x, decimal y) Cos((decimal x, decimal y) z)
            => (Real.Cos(z.x) * Real.Cosh(z.y),
               -Real.Sin(z.x) * Real.Sinh(z.y));
        
        /// <summary>
        /// Evaluate tan(z) as sin(2x) + isinh(2y) over cos(2x) + cosh(2y).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>tan(z)</returns>
        public static (decimal x, decimal y) Tan((decimal x, decimal y) z)
            => (ComplexOperator)(Real.Sin(2 * z.x), Real.Sinh(2 * z.y)) /
                                 Real.Cos(2 * z.x) + Real.Cosh(2 * z.y);

        /// <summary>
        /// Evaluate sin(z) as sin(x)cosh(y) + icos(x)sinh(y).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>sin(z)</returns>
        public static (decimal x, decimal y) Sin((decimal x, decimal y) z)
            => (Real.Sin(z.x) * Real.Cosh(z.y),
                Real.Cos(z.x) * Real.Sinh(z.y));
        
        /// <summary>
        /// Evaluate Arg(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Arg(z)</returns>
        public static decimal Arg((decimal x, decimal y) z)
        {
            if(z.x > 0 && z.y != 0)
            {
                return 2 * Real.Arctan(z.y / (Abs(z) + z.x));
            }

            if(z.x < 0 && z.y == 0 )
            {
                return Real.PI;
            }

            throw new ArgumentException("NaN");
        }

        /// <summary>
        /// Transform z to polar form.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>(r, phi)</returns>
        public static (decimal r, decimal phi) Polar((decimal x, decimal y) z)
            => (Abs(z), Arg(z));

        /// <summary>
        /// Transfrom polar form to cartesian representation.
        /// </summary>
        /// <param name="z">r*exp(phi*i)</param>
        /// <returns>x + iy</returns>
        public static (decimal x, decimal y) FromPolar((decimal r, decimal phi) z)
            => (ComplexOperator)z.r * Real.CosSin(z.phi);

        /// <summary>
        /// Evaluate exp(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>exp(z)</returns>
        public static (decimal x, decimal y) Exp((decimal x, decimal y) z)
            => (ComplexOperator)Real.Exp(Re(z)) * Real.CosSin(Im(z));

        /// <summary>
        /// Evaluate log(z) as log(r) + iarg(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="lbase"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static (decimal x, decimal y) Log(
            (decimal x, decimal y) z,
             decimal lbase     = Real.E,
             decimal precision = Real.Epsilon)
            => (Real.Log(Abs(z), lbase, precision), Arg(z));

        /// <summary>
        /// Evaluate z ** k, where k is in N.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="power"></param>
        /// <returns>z ** k</returns>
        public static (decimal x, decimal y) Pow((decimal x, decimal y) z, decimal k)
            => (ComplexOperator)z ^ (k, 0);

        /// <summary>
        /// Evaluate k ** z, where k is in N.
        /// </summary>
        /// <param name="k">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>z ** k</returns>
        public static (decimal x, decimal y) Pow(decimal k, (decimal x, decimal y) z)
            => (ComplexOperator)(k, 0) ^ z;
        
        /// <summary>
        /// Evaluate z ** z'.
        /// </summary>
        /// <param name="z1">x + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z ** k</returns>
        public static (decimal x, decimal y) Pow((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 ^ z2;

        /// <summary>
        /// Evaluate principal square root of z.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>sqrt(z)</returns>
        public static (decimal x, decimal y) PrincipalSqrt((decimal x, decimal y) z)
            => FromPolar((Real.Sqrt(Abs(z)), Polar(z).phi / 2));
       
        /// <summary>
        /// Evaluate z ** 1/k.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="k">Root</param>
        /// <returns>z ** 1/k</returns>
        public static (decimal x, decimal y)[] KRoots((decimal x, decimal y) z, int k)
        {
            var list = new List<(decimal x, decimal y)>();
            var (r, phi) = Polar(z);

            var root = Real.Pow(r, 1 / k);

            for(var n = 0; n < k; ++n)
            {
                list.Add(
                    (ComplexOperator)root * Real.CosSin((2 * Real.PI * n + phi) / k)
                );
            }

            return list.ToArray();
        }
    }
}
