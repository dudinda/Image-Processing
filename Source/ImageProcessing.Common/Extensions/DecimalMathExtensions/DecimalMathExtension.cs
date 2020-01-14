using System;
using System.Collections.Generic;
using System.Text;
using ImageProcessing.Common.Utility.DecimalMath;

namespace ImageProcessing.Common.Extensions.DecimalMathExtensions
{
    public static class DecimalMathExtension
    {
        public static decimal Sqrt(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Sqrt(value, precision);

        public static decimal Abs(this decimal value)
            => DecimalMath.Abs(value);

        public static decimal Pow(this decimal value, decimal power)
            => DecimalMath.Pow(value, power);

        public static decimal Exp(this decimal power, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Exp(power, precision);

        public static decimal Sign(this decimal value)
            => DecimalMath.Sign(value);

        public static decimal Floor(this decimal value)
            => DecimalMath.Floor(value);

        public static decimal Ceil(this decimal value)
            => DecimalMath.Ceil(value);

        public static decimal Log(this decimal value, decimal lbase = DecimalMath.E, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Log(value, lbase, precision);

        public static decimal Tan(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Tan(value, precision);

        public static decimal Cos(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Cos(value, precision);

        public static decimal Sin(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Sin(value, precision);

    }
}
