using Real = ImageProcessing.Utility.DecimalMath.RealAxis.DecimalMathReal;

namespace ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.RealAxis
{
    /// <summary>
    /// Extension methods for <see cref="DecimalMathReal">.
    /// </summary>
    public static class DecimalMathRealRealExtension
    {
        /// <inheritdoc cref="Real.Abs(decimal)"/>
        public static decimal Abs(this decimal value)
            => Real.Abs(value);

        /// <inheritdoc cref="Real.Sign(decimal)"/>
        public static decimal Sign(this decimal value)
            => Real.Sign(value);

        /// <inheritdoc cref="Real.Floor(decimal)"/>
        public static decimal Floor(this decimal value)
            => Real.Floor(value);

        /// <inheritdoc cref="Real.Ceil(decimal)"/>
        public static decimal Ceil(this decimal value)
            => Real.Ceil(value);

        /// <inheritdoc cref="Real.Mod(decimal, decimal)"/>
        public static decimal Mod(this decimal value, decimal mod)
            => Real.Mod(value, mod);

        /// <inheritdoc cref="Real.Sqrt(decimal, decimal)"/>
        public static decimal Sqrt(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Sqrt(value);

        /// <inheritdoc cref="Real.Log(decimal, decimal, decimal)"/>
        public static decimal Log(
            this decimal value,
            decimal lbase     = Real.E,
            decimal precision = Real.Epsilon)
            => Real.Log(value, lbase, precision);

        /// <inheritdoc cref="Real.Pow(decimal, decimal, decimal)"/>
        public static decimal Pow(
            this decimal value,
            decimal power,
            decimal precision = Real.Epsilon)
            => Real.Pow(value, power, precision);

        /// <inheritdoc cref="Real.Exp(decimal, decimal)"/>
        public static decimal Exp(
            this decimal power,
            decimal precision = Real.Epsilon)
            => Real.Exp(power, precision);

        /// <inheritdoc cref="Real.Tan(decimal, decimal)"/>
        public static decimal Tan(
            this decimal value
            , decimal precision = Real.Epsilon)
            => Real.Tan(value, precision);

        /// <inheritdoc cref="Real.Cos(decimal, decimal)"/>
        public static decimal Cos(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Cos(value, precision);

        /// <inheritdoc cref="Real.Sin(decimal, decimal)"/>
        public static decimal Sin(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Sin(value, precision);

        /// <inheritdoc cref="Real.Cot(decimal, decimal)"/>
        public static decimal Cot(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Cot(value, precision);

        /// <inheritdoc cref="Real.Cosh(decimal, decimal)"/>
        public static decimal Cosh(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Cosh(value, precision);

        /// <inheritdoc cref="Real.Sinh(decimal, decimal)"/>
        public static decimal Sinh(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Sinh(value, precision);

        /// <inheritdoc cref="Real.Tanh(decimal, decimal)"/>
        public static decimal Tanh(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Tanh(value, precision);

        /// <inheritdoc cref="Real.Coth(decimal, decimal)"/>
        public static decimal Coth(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Coth(value, precision);

        /// <inheritdoc cref="Real.Arcosh(decimal, decimal)"/>
        public static decimal Arcosh(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Arcosh(value, precision);

        /// <inheritdoc cref="Real.Arsinh(decimal, decimal)"/>
        public static decimal Arsinh(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Arsinh(value, precision);

        /// <inheritdoc cref="Real.Artanh(decimal, decimal)"/>
        public static decimal Artanh(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Artanh(value, precision);

        /// <inheritdoc cref="Real.Arcoth(decimal, decimal)"/>
        public static decimal Arcoth(
            this decimal value,
            decimal precision = Real.Epsilon)
            => Real.Arcoth(value, precision);

        /// <inheritdoc cref="Real.Arctan(decimal)"/>
        public static decimal Arctan(this decimal value)
           => Real.Arctan(value);

        /// <inheritdoc cref="Real.Arccot(decimal)"/>
        public static decimal Arccot(this decimal value)
            => Real.Arccot(value);

        /// <inheritdoc cref="Real.Arcsin(decimal)"/>
        public static decimal Arcsin(this decimal value)
            => Real.Arcsin(value);

        /// <inheritdoc cref="Real.Arccos(decimal)"/>
        public static decimal Arccos(this decimal value)
            => Real.Arccos(value);
    }
}
