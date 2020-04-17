using ImageProcessing.Utility.DecimalMath.Complex;

namespace ImageProcessing.Utility.DecimalMath.Code.Structs
{
    internal struct ComplexOperator
    {
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
            => new ComplexOperator(DecimalMathComplex.Add(z1.Z, z2.Z));

        public static ComplexOperator operator +(
            ComplexOperator z, decimal c)
            => new ComplexOperator(DecimalMathComplex.Add(z.Z, c));

        public static ComplexOperator operator +(
            ComplexOperator z1, (decimal, decimal) z2)
            => new ComplexOperator(DecimalMathComplex.Add(z1.Z, z2));

        public static ComplexOperator operator +(
           (decimal, decimal) z1, ComplexOperator z2)
           => new ComplexOperator(DecimalMathComplex.Add(z1, z2.Z));

        public static ComplexOperator operator +(
          decimal c, ComplexOperator z)
          => new ComplexOperator(DecimalMathComplex.Add(c, z.Z));

        public static ComplexOperator operator -(
            ComplexOperator z1, ComplexOperator z2)
            => new ComplexOperator(DecimalMathComplex.Sub(z1.Z, z2.Z));

        public static ComplexOperator operator -(
            ComplexOperator z, decimal c)
            => new ComplexOperator(DecimalMathComplex.Sub(z.Z, c));

        public static ComplexOperator operator -(
          decimal c, ComplexOperator z)
          => new ComplexOperator(DecimalMathComplex.Sub(c, z.Z));

        public static ComplexOperator operator -(
            ComplexOperator z1, (decimal, decimal) z2)
            => new ComplexOperator(DecimalMathComplex.Sub(z1.Z, z2));

        public static ComplexOperator operator -(
            (decimal, decimal) z1, ComplexOperator z2)
            => new ComplexOperator(DecimalMathComplex.Sub(z1, z2.Z));

        public static ComplexOperator operator *(
            ComplexOperator z1, ComplexOperator z2)
            => new ComplexOperator(DecimalMathComplex.Mul(z1.Z, z2.Z));

        public static ComplexOperator operator *(
            ComplexOperator z, decimal c)
            => new ComplexOperator(DecimalMathComplex.Mul(z.Z, c));

        public static ComplexOperator operator *(
            decimal c, ComplexOperator z)
            => new ComplexOperator(DecimalMathComplex.Mul(c, z.Z));

        public static ComplexOperator operator *(
           (decimal, decimal) z1, ComplexOperator z2)
           => new ComplexOperator(DecimalMathComplex.Mul(z1, z2.Z));

        public static ComplexOperator operator *(
          ComplexOperator z1, (decimal, decimal) z2)
          => new ComplexOperator(DecimalMathComplex.Mul(z1.Z, z2));

        public static ComplexOperator operator /(
            ComplexOperator z1, ComplexOperator z2)
            => new ComplexOperator(DecimalMathComplex.Div(z1.Z, z2.Z));

        public static ComplexOperator operator /(
            ComplexOperator z, decimal c)
            => new ComplexOperator(DecimalMathComplex.Div(z.Z, c));

        public static ComplexOperator operator /(
            decimal c, ComplexOperator z)
            => new ComplexOperator(DecimalMathComplex.Div(c, z.Z));

        public static ComplexOperator operator /(
           (decimal, decimal) z1, ComplexOperator z2)
           => new ComplexOperator(DecimalMathComplex.Div(z1, z2.Z));

        public static ComplexOperator operator /(
           ComplexOperator z1, (decimal, decimal) z2)
           => new ComplexOperator(DecimalMathComplex.Div(z1.Z, z2));

        public static ComplexOperator operator ^(
            decimal c, ComplexOperator z)
            => new ComplexOperator(DecimalMathComplex.Pow(c, z.Z));

        public static ComplexOperator operator ^(
            ComplexOperator z, decimal c)
            => new ComplexOperator(DecimalMathComplex.Pow(z.Z, c));

        public static ComplexOperator operator ^(
            ComplexOperator z1, ComplexOperator z2)
            => new ComplexOperator(DecimalMathComplex.Pow(z1.Z, z2.Z));

        public static ComplexOperator operator ^(
            ComplexOperator z1, (decimal, decimal) z2)
            => new ComplexOperator(DecimalMathComplex.Pow(z1.Z, z2));

        public static ComplexOperator operator ^(
            (decimal, decimal) z1, ComplexOperator z2)
            => new ComplexOperator(DecimalMathComplex.Pow(z1, z2.Z));


        public static explicit operator ComplexOperator(decimal c)
            => new ComplexOperator(c);

        public static explicit operator ComplexOperator((decimal, decimal) z)
            => new ComplexOperator(z);

        public static implicit operator (decimal, decimal)(ComplexOperator z)
            => z.Z;
    }
}
