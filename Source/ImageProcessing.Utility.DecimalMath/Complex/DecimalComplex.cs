using System;
using System.Collections.Generic;

using ImageProcessing.Utility.DecimalMath.Real;

namespace ImageProcessing.Utility.DecimalMath.Complex
{
    public class DecimalComplex
    {
        private readonly static DecimalReal _real = new DecimalReal();

        /// <summary>
        /// Evaluate Re(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Re(z)</returns>
        public decimal Re((decimal x, decimal y) z)
            => z.x;
      
        /// <summary>
        /// Evaluate Im(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Im(z)</returns>
        public decimal Im((decimal x, decimal y) z)
            => z.y;
        
        /// <summary>
        /// Evaluate conjugate of z.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>conj(z)</returns>
        public (decimal Re, decimal Im) Conj((decimal x, decimal y) z)
            => (z.x, -z.y);

        /// <summary>
        /// Evaluate 1 / z.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns></returns>
        public (decimal Re, decimal Im) Reciprocal((decimal x, decimal y) z)
            => 1.0M / (ComplexOperator)z;

        /// <summary>
        /// Evaluate |z|.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>|z|</returns>
        public decimal Abs((decimal x, decimal y) z)
            => _real.Hypot(z.x, z.y);

        /// <summary>
        /// Evaluate z + c.
        /// </summary>
        /// <param name="z">x  + iy</param>
        /// <param name="c">const</param>
        /// <returns>z + c</returns>
        public (decimal Re, decimal Im) Add((decimal x, decimal y) z, decimal c)
            => (ComplexOperator)z + c;

        /// <summary>
        /// Evaluate c + z.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>c + z</returns>
        public (decimal Re, decimal Im) Add(decimal c, (decimal x, decimal y) z)
            => (ComplexOperator)c + z;

        /// <summary>
        /// Evaluate z + z'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z + z'</returns>
        public (decimal Re, decimal Im) Add((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 + z2;

        /// <summary>
        /// Evaluate z - z'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z - z'</returns>
        public (decimal Re, decimal Im) Sub((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 - z2;

        /// <summary>
        /// Evaluate z - c.
        /// </summary>
        /// <param name="z">x  + iy</param>
        /// <param name="c">const</param>
        /// <returns>z - c</returns>
        public (decimal Re, decimal Im) Sub((decimal x, decimal y) z, decimal c)
            => (ComplexOperator)z - c;

        /// <summary>
        /// Evaluate c - z.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>c - z</returns>
        public (decimal Re, decimal Im) Sub(decimal c, (decimal x, decimal y) z)
            => (ComplexOperator)c - z;

        /// <summary>
        /// Evaluate zz'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>zz'</returns>
        public (decimal Re, decimal Im) Mul((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 * z2;

        /// <summary>
        /// Evaluate zС.
        /// </summary>
        /// <param name="z">x  + iy</param>
        /// <param name="c">const</param>
        /// <returns>zC</returns>
        public (decimal Re, decimal Im) Mul((decimal x, decimal y) z, decimal c)
            => (ComplexOperator)z * c;

        /// <summary>
        /// Evaluate zC.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>zC</returns>
        public (decimal Re, decimal Im) Mul(decimal c, (decimal x, decimal y) z)
            => (ComplexOperator)c * z;

        /// <summary>
        /// Evaluate z/z'.
        /// </summary>
        /// <param name="z1">x  + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z/z'</returns>
        public (decimal Re, decimal Im) Div((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 / (ComplexOperator)z2;

        /// <summary>
        /// Evaluate c/z.
        /// </summary>
        /// <param name="c">const</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>c/z</returns>
        public (decimal Re, decimal Im) Div(decimal c, (decimal x, decimal y) z2)
            => (ComplexOperator)c / z2;

        /// <summary>
        /// Evaluate z/c.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="z2">const</param>
        /// <returns>z/c</returns>
        public (decimal Re, decimal Im) Div((decimal x, decimal y) z, decimal c)
            => (ComplexOperator)z / c;
        
        /// <summary>
        /// Evaluate cos(z) as cos(x)cosh(y) - isin(x)sinh(y).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>cos(z)</returns>
        public (decimal Re, decimal Im) Cos((decimal x, decimal y) z)
            => (_real.Cos(z.x) * _real.Cosh(z.y),
               -_real.Sin(z.x) * _real.Sinh(z.y));
        
        /// <summary>
        /// Evaluate tan(z) as sin(2x) + isinh(2y) over cos(2x) + cosh(2y).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>tan(z)</returns>
        public (decimal Re, decimal Im) Tan((decimal x, decimal y) z)
            => (ComplexOperator)(_real.Sin(2.0M * z.x), _real.Sinh(2.0M * z.y)) /
                                 _real.Cos(2.0M * z.x) + _real.Cosh(2.0M * z.y);

        /// <summary>
        /// Evaluate sin(z) as sin(x)cosh(y) + icos(x)sinh(y).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>sin(z)</returns>
        public (decimal Re, decimal Im) Sin((decimal x, decimal y) z)
            => (_real.Sin(z.x) * _real.Cosh(z.y),
                _real.Cos(z.x) * _real.Sinh(z.y));
        
        /// <summary>
        /// Evaluate Arg(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Arg(z)</returns>
        public decimal Arg((decimal x, decimal y) z)
        {
            if(z.x > 0.0M && z.y != 0.0M)
            {
                return 2.0M * _real.Arctan(z.y / (Abs(z) + z.x));
            }

            if(z.x < 0.0M && z.y == 0.0M)
            {
                return DecimalReal.PI;
            }

            throw new ArgumentException("NaN");
        }

        /// <summary>
        /// Transform z to polar form.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>(r, phi)</returns>
        public (decimal r, decimal phi) Polar((decimal x, decimal y) z)
            => (Abs(z), Arg(z));

        /// <summary>
        /// Transfrom polar form to cartesian representation.
        /// </summary>
        /// <param name="z">r*exp(phi*i)</param>
        /// <returns>x + iy</returns>
        public (decimal Re, decimal Im) FromPolar((decimal r, decimal phi) z)
            => (ComplexOperator)z.r * _real.CosSin(z.phi);

        /// <summary>
        /// Evaluate exp(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>exp(z)</returns>
        public (decimal Re, decimal Im) Exp((decimal x, decimal y) z)
            => (ComplexOperator)_real.Exp(z.x) * _real.CosSin(z.y);

        /// <summary>
        /// Evaluate log(z) as log(r) + iarg(z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="lbase"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public (decimal Re, decimal Im) Log(
            (decimal x, decimal y) z,
             decimal lbase     = DecimalReal.E,
             decimal precision = DecimalReal.Epsilon)
            => (_real.Log(Abs(z), lbase, precision), Arg(z));

        /// <summary>
        /// Evaluate z ** k, where k is in N.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="power"></param>
        /// <returns>z ** k</returns>
        public (decimal Re, decimal Im) Pow((decimal x, decimal y) z, decimal k)
            => (ComplexOperator)z ^ (k, 0.0M);

        /// <summary>
        /// Evaluate k ** z, where k is in N.
        /// </summary>
        /// <param name="k">const</param>
        /// <param name="z">x + iy</param>
        /// <returns>z ** k</returns>
        public (decimal Re, decimal Im) Pow(decimal k, (decimal x, decimal y) z)
            => (ComplexOperator)(k, 0.0M) ^ z;
        
        /// <summary>
        /// Evaluate z ** z'.
        /// </summary>
        /// <param name="z1">x + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>z ** k</returns>
        public (decimal Re, decimal Im) Pow((decimal x, decimal y) z1, (decimal x, decimal y) z2)
            => (ComplexOperator)z1 ^ z2;

        /// <summary>
        /// Evaluate principal square root of z.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>sqrt(z)</returns>
        public (decimal Re, decimal Im) PrincipalSqrt((decimal x, decimal y) z)
            => FromPolar(((decimal)Math.Sqrt((double)Abs(z)), Polar(z).phi / 2.0M));
       
        /// <summary>
        /// Evaluate z ** 1/k.
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <param name="k">Root</param>
        /// <returns>z ** 1/k</returns>
        public (decimal Re, decimal Im)[] KRoots((decimal x, decimal y) z, int k)
        {
            var list = new List<(decimal x, decimal y)>();
            var (r, phi) = Polar(z);

            var root = _real.Pow(r, 1.0M / k);

            for(var n = 0; n < k; ++n)
            {
                list.Add( (ComplexOperator)root * _real.CosSin((2.0M * DecimalReal.PI * n + phi) / k) );
            }

            return list.ToArray();
        }
    }
}
