using ImageProcessing.DecimalMath.Real;

namespace ImageProcessing.Common.Extensions.DecimalMathRealExtensions
{
    /// <summary>
    /// Extension methods for <see cref="DecimalMathReal"> class
    /// </summary>
    public static class DecimalMathRealRealExtension
    {      
        public static decimal Abs(this decimal value)
            => DecimalMathReal.Abs(value);

        public static decimal Sign(this decimal value)
            => DecimalMathReal.Sign(value);

        public static decimal Floor(this decimal value)
            => DecimalMathReal.Floor(value);

        public static decimal Ceil(this decimal value)
            => DecimalMathReal.Ceil(value);

        public static decimal Mod(this decimal value, decimal mod)
            => DecimalMathReal.Mod(value, mod);

        public static decimal Sqrt(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Sqrt(value, precision);

        public static decimal Log(this decimal value, decimal lbase = DecimalMathReal.E, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Log(value, lbase, precision);

        public static decimal Pow(this decimal value, decimal power, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Pow(value, power);

        public static decimal Exp(this decimal power, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Exp(power, precision);
        
        public static decimal Tan(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Tan(value, precision);

        public static decimal Cos(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Cos(value, precision);

        public static decimal Sin(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Sin(value, precision);

        public static decimal Cot(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Cot(value, precision);

        public static decimal Cosh(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Cosh(value, precision);

        public static decimal Sinh(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Sinh(value, precision);

        public static decimal Tanh(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Tanh(value, precision);

        public static decimal Coth(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Coth(value, precision);

        public static decimal Arcosh(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Arcosh(value, precision);

        public static decimal Arsinh(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Arsinh(value, precision);

        public static decimal Artanh(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Artanh(value, precision);

        public static decimal Arcoth(this decimal value, decimal precision = DecimalMathReal.Epsilon)
            => DecimalMathReal.Arcoth(value, precision);

        public static decimal Arctan(this decimal value)
           => DecimalMathReal.Arctan(value);

        public static decimal Arccot(this decimal value)
            => DecimalMathReal.Arccot(value);

        public static decimal Arcsin(this decimal value)
            => DecimalMathReal.Arcsin(value);

        public static decimal Arccos(this decimal value)
            => DecimalMathReal.Arccos(value);

    }
}
