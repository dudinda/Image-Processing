
using ImageProcessing.Utility.DecimalMath.Complex;
using ImageProcessing.Utility.DecimalMath.Real;

namespace ImageProcessing.Utility.DecimalMath.Complex
{
    internal sealed class ComplexOperator
    {
        private static readonly DecimalComplex _complex  = new DecimalComplex();
        private static readonly DecimalReal _real = new DecimalReal();

        internal (decimal Re, decimal Im) Z { get; }

        internal ComplexOperator((decimal re, decimal im) z)
            => Z = z;
        
        internal ComplexOperator(decimal c)
            => Z = (c, 0);

        internal ComplexOperator(ComplexOperator z)
           => Z = z.Z;

        public static ComplexOperator operator -(
           ComplexOperator z)
           => new ComplexOperator((-z.Z.Re, -z.Z.Im));

        public static ComplexOperator operator +(
            ComplexOperator z1, ComplexOperator z2)
            => new ComplexOperator(
                (z1.Z.Re + z2.Z.Re, z1.Z.Im + z2.Z.Im)
            );

        public static ComplexOperator operator +(
            ComplexOperator z, decimal c)
            => z + (ComplexOperator)c;

        public static ComplexOperator operator +(
            ComplexOperator z1, (decimal, decimal) z2)
            => z1 + (ComplexOperator)z2;

        public static ComplexOperator operator +(
           (decimal, decimal) z1, ComplexOperator z2)
           => (ComplexOperator)z1 + z2;

        public static ComplexOperator operator +(
          decimal c, ComplexOperator z)
          => (ComplexOperator)c + z;

        public static ComplexOperator operator -(
            ComplexOperator z1, ComplexOperator z2)
            => new ComplexOperator(
                (z1.Z.Re - z2.Z.Re, z1.Z.Im - z2.Z.Im)
            );

        public static ComplexOperator operator -(
            ComplexOperator z, decimal c)
            => z - (ComplexOperator)c;

        public static ComplexOperator operator -(
            decimal c, ComplexOperator z)
            => (ComplexOperator)c - z;

        public static ComplexOperator operator -(
            ComplexOperator z1, (decimal, decimal) z2)
            => z1 - (ComplexOperator)z2;

        public static ComplexOperator operator -(
            (decimal, decimal) z1, ComplexOperator z2)
            => (ComplexOperator)z1 - z2;

        public static ComplexOperator operator *(
         decimal c, ComplexOperator z)
         => new ComplexOperator(c) * z;

        public static ComplexOperator operator *(
          ComplexOperator z, decimal c)
          => z * new ComplexOperator(c);

        public static ComplexOperator operator *(
            ComplexOperator z1, (decimal, decimal) z2)
            => z1 * new ComplexOperator(z2);

        public static ComplexOperator operator *(
           (decimal, decimal) z1, ComplexOperator z2)
           => new ComplexOperator(z1) * z2;

        public static ComplexOperator operator *(
            ComplexOperator z1, ComplexOperator z2)
            => new ComplexOperator(
                ((z1.Z.Re * z2.Z.Re - z1.Z.Im * z2.Z.Im,
                  z1.Z.Re * z2.Z.Im + z1.Z.Im * z2.Z.Re))
            );
        
        public static ComplexOperator operator /(
            ComplexOperator z1, ComplexOperator z2)
        {
            var a = z1.Z.Re;
            var b = z1.Z.Im;
            var c = z2.Z.Re;
            var d = z2.Z.Im;

            if (_real.Abs(d) < _real.Abs(c))
            {
                var r = d / c;
                var den = c + d * r;
                var e = (a + b * r) / den;
                var f = (b - a * r) / den;

                return (ComplexOperator)(e, f);
            }
            else
            {
                var r = c / d;
                var den = c * r + d;
                var e = (a * r + b) / den;
                var f = (b * r - a) / den;

                return (ComplexOperator)(e, f);
            }
        }

        public static ComplexOperator operator /(
            ComplexOperator z, decimal c)
            => z / (ComplexOperator)c;

        public static ComplexOperator operator /(
            decimal c, ComplexOperator z)
            => (ComplexOperator)c / z;

        public static ComplexOperator operator /(
           (decimal, decimal) z1, ComplexOperator z2)
           => (ComplexOperator)z1 / z2;

        public static ComplexOperator operator /(
            ComplexOperator z1, (decimal, decimal) z2)
            => z1 / (ComplexOperator)z2;

        public static ComplexOperator operator ^(
            decimal c, ComplexOperator z)
            => new ComplexOperator(_complex.Pow(c, z.Z));

        public static ComplexOperator operator ^(
            ComplexOperator z, decimal c)
            => new ComplexOperator(_complex.Pow(z.Z, c));

        public static ComplexOperator operator ^(
            ComplexOperator z1, ComplexOperator z2)
        {
            var (r, phi) = _complex.Polar(z1);

            //evaluate as exp(log(r)(x' + iy') + i*phi(x' + iy'))

            var re = _real.Log(r) * z2;
            var im = phi * z2;

            return (ComplexOperator)_complex.Exp(re + im);
        }

        public static ComplexOperator operator ^(
            ComplexOperator z1, (decimal, decimal) z2)
            => z1 ^ (ComplexOperator)z2;

        public static ComplexOperator operator ^(
            (decimal, decimal) z1, ComplexOperator z2)
            => (ComplexOperator)z1 ^ z2;

        public static explicit operator ComplexOperator(decimal c)
            => new ComplexOperator(c);

        public static explicit operator ComplexOperator((decimal, decimal) z)
            => new ComplexOperator(z);

        public static implicit operator (decimal, decimal)(ComplexOperator z)
            => z.Z;
    }
}
