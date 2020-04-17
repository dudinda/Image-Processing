using ImageProcessing.Utility.DecimalMath.Complex;

namespace ImageProcessing.Utility.DecimalMath.Code.Structs
{
    internal struct ComplexNum
    {
        internal (decimal Re, decimal Im) Z { get; set; }

        internal ComplexNum((decimal re, decimal im) z)
        {
            Z = z;
        }

        public static ComplexNum operator +(
            ComplexNum z1, ComplexNum z2)
            => new ComplexNum(DecimalMathComplex.Add(z1.Z, z2.Z));

        public static ComplexNum operator +(
            ComplexNum z1, decimal c)
            => new ComplexNum(DecimalMathComplex.Add(z1.Z, c));

        public static ComplexNum operator *(
            ComplexNum z1, ComplexNum z2)
            => new ComplexNum(DecimalMathComplex.Mul(z1.Z, z2.Z));

        public static ComplexNum operator *(
            ComplexNum z1, decimal c)
            => new ComplexNum(DecimalMathComplex.Mul(z1.Z, c));

        public static ComplexNum operator /(
            ComplexNum z1, ComplexNum z2)
            => new ComplexNum(DecimalMathComplex.Div(z1.Z, z2.Z));

        public static ComplexNum operator /(
            ComplexNum z, decimal c)
            => new ComplexNum(DecimalMathComplex.Div(z.Z, c));

        public static ComplexNum operator /(
            decimal c, ComplexNum z)
            => new ComplexNum(DecimalMathComplex.Div(c, z.Z));
    }
}
