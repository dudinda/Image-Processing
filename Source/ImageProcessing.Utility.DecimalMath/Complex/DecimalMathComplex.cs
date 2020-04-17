using System;
using System.Collections.Generic;

using ImageProcessing.Utility.DecimalMath.Code.Structs;
using ImageProcessing.Utility.DecimalMath.Real;

namespace ImageProcessing.Utility.DecimalMath.Complex
{
    public static class DecimalMathComplex
    {
        /// <summary>
        /// Evaluate Re(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Re(z)</returns>
        public static decimal Re((decimal x, decimal y) z)
        {
            return z.x;
        } 

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
        /// Evaluate |z|.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>|z|</returns>
        public static decimal Abs((decimal x, decimal y) z)
            => DecimalMathReal.Hypot(z.x, z.y);
        
        /// <summary>
        /// Evaluate z + c.
        /// </summary>
        /// <param name="z">x  + iy</param>
        /// <param name="c">const</param>
        /// <returns>z + c</returns>
        public static (decimal x, decimal y) Add((decimal x, decimal y) z, decimal c)
            => (z.x + c, z.y);

        /// <summary>
        /// Evaluate c + z.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>c + z</returns>
        public static (decimal x, decimal y) Add(decimal c, (decimal x, decimal y) z)
            => (z.x + c, z.y);

        /// <summary>
        /// Evaluate z + z'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z + z'</returns>
        public static (decimal x, decimal y) Add((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (z1.x + z2.x, z2.y + z2.y);
        
        /// <summary>
        /// Evaluate z - z'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z - z'</returns>
        public static (decimal x, decimal y) Sub((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (z1.x - z2.y, z1.x - z2.y);
        
        /// <summary>
        /// Evaluate z - c.
        /// </summary>
        /// <param name="z">x  + iy</param>
        /// <param name="c">const</param>
        /// <returns>z - c</returns>
        public static (decimal x, decimal y) Sub((decimal x, decimal y) z, decimal c)
            => (z.x - c, z.y);
        
        /// <summary>
        /// Evaluate c - z.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>c - z</returns>
        public static (decimal x, decimal y) Sub(decimal c, (decimal x, decimal y) z)
            => (c - z.x, -z.y);
        
        /// <summary>
        /// Evaluate zz'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>zz'</returns>
        public static (decimal x, decimal y) Mul((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => ((z1.x * z2.x - z1.y * z2.y, z1.x * z2.y + z1.y * z2.x));
        
        /// <summary>
        /// Evaluate Cz.
        /// </summary>
        /// <param name="z">x  + iy</param>
        /// <param name="c">const</param>
        /// <returns>Cz</returns>
        public static (decimal x, decimal y) Mul((decimal x, decimal y) z, decimal c)
            => (z.x * c, z.y * c);

        /// <summary>
        /// Evaluate zC.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>zC</returns>
        public static (decimal x, decimal y) Mul(decimal c, (decimal x, decimal y) z)
            => (z.x * c, z.y * c);

        /// <summary>
        /// Evaluate z/z'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z/z'</returns>
        public static (decimal x, decimal y) Div((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            var numerator = Mul(z1, Conj(z2));

            var denominator = z2.x * z2.x + z2.y * z2.y;

            return (numerator.x / denominator, numerator.y / denominator);
        }

        /// <summary>
        /// Evaluate c/z.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>c/z</returns>
        public static (decimal x, decimal y) Div(decimal c, (decimal x, decimal y) z2)
        {
            var numerator = Mul(Conj(z2), c);

            var denominator = z2.x * z2.x + z2.y * z2.y;

            return (numerator.x / denominator, numerator.y / denominator);
        }

        /// <summary>
        /// Evaluate z/c.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="z2">const</param>
        /// <returns>z/c</returns>
        public static (decimal x, decimal y) Div((decimal x, decimal y) z, decimal c)
            => (z.x / c, z.y / c);
        
        /// <summary>
        /// Evaluate cos(z) as cos(x)cosh(y) - isin(x)sinh(y).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>cos(z)</returns>
        public static (decimal x, decimal y) Cos((decimal x, decimal y) z)
            => (DecimalMathReal.Cos(z.x) * DecimalMathReal.Cosh(z.y), -DecimalMathReal.Sin(z.x) * DecimalMathReal.Sinh(z.y));
        
        /// <summary>
        /// Evaluate tan(z) as sin(2x) + isinh(2y) over cos(2x) + cosh(2y).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>tan(z)</returns>
        public static (decimal x, decimal y) Tan((decimal x, decimal y) z)
        {
            var denominator = DecimalMathReal.Cos(2 * z.x) + DecimalMathReal.Cosh(2 * z.y);

            return (DecimalMathReal.Sin(2 * z.x) / denominator, DecimalMathReal.Sinh(2 * z.y) / denominator);
        }

        /// <summary>
        /// Evaluate sin(z) as sin(x)cosh(y) + icos(x)sinh(y).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>sin(z)</returns>
        public static (decimal x, decimal y) Sin((decimal x, decimal y) z)
            => (DecimalMathReal.Sin(z.x) * DecimalMathReal.Cosh(z.y), DecimalMathReal.Cos(z.x) * DecimalMathReal.Sinh(z.y));
        
        /// <summary>
        /// Evaluate Arg(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Arg(z)</returns>
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
        {
            var (sin, cos) = DecimalMathReal.SinCos(z.phi);

            return (cos * z.r, sin * z.r);
        }

        /// <summary>
        /// Evaluate exp(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>exp(z)</returns>
        public static (decimal x, decimal y) Exp((decimal x, decimal y) z)
        {
            var r          = DecimalMathReal.Exp(z.x);
            var (sin, cos) = DecimalMathReal.SinCos(z.y);

            return (cos * r, sin * r);
            
        }

        /// <summary>
        /// Evaluate log(z) as log(r) + iarg(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="lbase"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static (decimal x, decimal y) Log(
            (decimal x, decimal y) z,
             decimal lbase = DecimalMathReal.E,
             decimal precision = DecimalMathReal.Epsilon)
            => (DecimalMathReal.Log(Abs(z), lbase, precision), Arg(z));

        /// <summary>
        /// Evaluate z ** k, where k is in N.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="power"></param>
        /// <returns>z ** k</returns>
        public static (decimal x, decimal y) Pow((decimal x, decimal y) z, int k)
            => Pow(z, (k, 0));

        /// <summary>
        /// Evaluate k ** z, where k is in N.
        /// </summary>
        /// <param name="k">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>z ** k</returns>
        public static (decimal x, decimal y) Pow(decimal k, (decimal x, decimal y) z)
            => Pow((k, 0), z);

        /// <summary>
        /// Evaluate z ** z'.
        /// </summary>
        /// <param name="z1">x + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z ** k</returns>
        public static (decimal x, decimal y) Pow((decimal x, decimal y) z1, (decimal x, decimal y) z2)
        {
            var (r, phi) = Polar(z1);

            //evaluate as exp(log(r)(x' + iy') + i*phi(x' + iy'))

            var re = new ComplexNum(Mul(DecimalMathReal.Log(r), z2));
            var im = new ComplexNum(Mul(phi, z2));

            return Exp((re + im).Z);
        }


        /// <summary>
        /// Evaluate principal square root of z.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>sqrt(z)</returns>
        public static (decimal x, decimal y) PrincipalSqrt((decimal x, decimal y) z)
        {
            if(Re(z) < 0)
            {
                z.x = -z.x;
            }

            if(Im(z) == 0)
            {
                return (DecimalMathReal.Sqrt(z.x), 0M);
            }

            var (r, phi) = Polar(z);

            var root = DecimalMathReal.Sqrt(r);

            var (sin, cos) = DecimalMathReal.SinCos(phi / 2);

            return (root * cos, root * sin);
        }

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

            var rootOfR = DecimalMathReal.Pow(r, 1 / k);

            for(var n = 0; n < k; ++n)
            {
                var (sin, cos) = DecimalMathReal.SinCos((2 * DecimalMathReal.PI * n + phi) / k);

                list.Add((rootOfR * cos, rootOfR * sin));
            }

            return list.ToArray();
        }
    }
}
