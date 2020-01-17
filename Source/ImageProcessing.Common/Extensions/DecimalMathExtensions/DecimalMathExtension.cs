using System;
using System.Collections.Generic;
using System.Text;
using ImageProcessing.Common.Utility.DecimalMath;

namespace ImageProcessing.Common.Extensions.DecimalMathExtensions
{
    public static class DecimalMathExtension
    {      
        public static decimal Abs(this decimal value)
            => DecimalMath.Abs(value);

        public static decimal Sign(this decimal value)
            => DecimalMath.Sign(value);

        public static decimal Floor(this decimal value)
            => DecimalMath.Floor(value);

        public static decimal Ceil(this decimal value)
            => DecimalMath.Ceil(value);

        public static decimal Mod(this decimal value, decimal mod)
            => DecimalMath.Mod(value, mod);

        public static decimal Sqrt(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Sqrt(value, precision);

        public static decimal Log(this decimal value, decimal lbase = DecimalMath.E, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Log(value, lbase, precision);

        public static decimal Pow(this decimal value, decimal power)
            => DecimalMath.Pow(value, power);

        public static decimal Exp(this decimal power, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Exp(power, precision);
        
        public static decimal Tan(this decimal value, decimal precision = DecimalMath.Epsilon)
         => DecimalMath.Tan(value, precision);

        public static decimal Cos(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Cos(value, precision);

        public static decimal Sin(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Sin(value, precision);

        public static decimal Cot(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Cot(value, precision);

        public static decimal Arctan(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Arctan(value);

        public static decimal Arccot(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Arccot(value);

        public static decimal Arcsin(this decimal value)
            => DecimalMath.Arcsin(value);

        public static decimal Arccos(this decimal value)
            => DecimalMath.Arccos(value);

        public static decimal Cosh(this decimal value, decimal precision = DecimalMath.Epsilon)
       => DecimalMath.Cosh(value, precision);

        public static decimal Sinh(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Sinh(value, precision);

        public static decimal Tanh(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Tanh(value, precision);

        public static decimal Coth(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Coth(value, precision);

        public static decimal Arcosh(this decimal value, decimal precision = DecimalMath.Epsilon)
       => DecimalMath.Arcosh(value, precision);

        public static decimal Arsinh(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Arsinh(value, precision);

        public static decimal Artanh(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Artanh(value, precision);

        public static decimal Arcoth(this decimal value, decimal precision = DecimalMath.Epsilon)
            => DecimalMath.Arcoth(value, precision);

    }
}
