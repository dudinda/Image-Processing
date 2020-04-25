using System;

using ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.RealAxis;
using ImageProcessing.Utility.DecimalMath.Code.Structs;

using static ImageProcessing.Utility.DecimalMath.ComplexPlane.DecimalMathComplex;
using static ImageProcessing.Utility.DecimalMath.RealAxis.DecimalMathReal;

namespace ImageProcessing.Utility.DecimalMath.SpecialFunctions
{
    public static class DecimalMathSpecial
    {
        #region Gamma constants
        private const int g = 7;

        private static decimal[] p =
        {
             0.99999999999980993M, 676.5203681218851M,     -1259.1392167224028M,
             771.32342877765313M,  -176.61502916214059M,   12.507343278686905M,
            -0.13857109526572012M, 9.9843695780195716e-6M, 1.5056327351493116e-7M
        };
        #endregion

        #region Cordic constans

        private const decimal K = 0.6072529351031M;

        private static decimal[] _angles = new decimal[]
        {
            0.785398163M, 0.463647608M, 0.244978663M, 0.124354992M,
            0.062418807M, 0.03123983M,  0.015623726M, 0.00781234M,
            0.003906228M, 0.001953121M, 0.000976559M, 0.000488278M,
            0.000244137M, 0.000122067M, 0.000061031M, 0.000030514M,
            0.000015255M, 0.000007626M, 0.000003815M, 0.000001904M
        };

        #endregion


        /// <summary>
        /// Evaluate Li(x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal Li(decimal x)
        {
            return Ei(Log(x));
        }

        /// <summary>
        /// Evaluate Ei(x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal Ei(decimal x)
        {
            var result = Euler + Log(Abs(x));
            var total = x;

            result += total;

            for (var k = 0; Abs(total) > Epsilon; ++k)
            {
                total = total * x * k
                       / (k * (k + 2) + 1);

                result += total;
            }

            return result;
        }

        /// <summary>
        /// Evaluate Ci(x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal Ci(decimal x)
        {
            var result = Euler + Log(x);
            var total = -x * x / 4;

            result += total;

            for (var k = 1; Abs(total) > Epsilon; ++k)
            {
                total = -total * x * x * (2 * k + -1)
                       / (k * (k * (4 * k + 10) + 8) + 2);

                result += total;
            }

            return result;
        }

        /// <summary>
        /// Evaluate Si(x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>

        public static decimal Si(decimal x)
        {
            var total = x;
            var result = total;

            for (var k = 1; Abs(total) > Epsilon; ++k)
            {
                total = -total * x * x * (2 * k + -1)
                       / (k * (k * (8 * k + 8) + 2));

                result += total;
            }

            return result;
        }

        /// <summary>
        /// Evaluate ErfInv(x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal ErfInv(decimal x)
        {
            if(x.Abs() >= 1)
            {
                throw new ArgumentException("NaN");
            }

            decimal  p;
            var w = -Log((1.0M - x) * (1.0M + x));

            if (w < 5.000000M)
            {
                w = w - 2.500000M;
                p = 2.81022636e-08M;
                p = (p * w + 3.43273939e-07M);
                p = (p * w + -3.5233877e-06M);
                p = (p * w + -4.39150654e-06M);
                p = (p * w + 0.00021858087M);
                p = (p * w + -0.00125372503M);
                p = (p * w + -0.00417768164M);
                p = (p * w + 0.246640727M);
                p = (p * w + 1.50140941M);
            }
            else
            {
                w = Sqrt(w) - 3.000000M;
                p = -0.000200214257M;
                p = (p * w + 0.000100950558M);
                p = (p * w + 0.00134934322M);
                p = (p * w + -0.00367342844M);
                p = (p * w + 0.00573950773M);
                p = (p * w + -0.0076224613M);
                p = (p * w + 0.00943887047M);
                p = (p * w + 1.00167406M);
                p = (p * w + 2.83297682M);
            }

            return p * x;
        }

        /// <summary>
        /// Evaluate Γ(1 + z).
        /// </summary>
        /// <param name="z">x + iy</param>
        /// <returns>Γ(1 + z)</returns>
        public static (decimal Re, decimal Im) Gamma((decimal x, decimal y) z)
        {
            if(z.x < 0)
            {
                throw new ArgumentException("NaN");
            }

            var w = (ComplexOperator)z;

            if (z.x < 0.5M)
            {
                return PI / (ComplexOperator)Sin(w * PI) *  Gamma(w - 1);

            }
            else
            {
                w -= 1;

                var x = (ComplexOperator)p[0];

                for (var i = 1; i < g + 2; ++i)
                {
                    x += p[i] / (w + i);
                }

                var t = w + g + 0.5M;

               return Sqrt(2M * PI) * ( t ^ (w + 0.5M) ) * Exp(-t) * x;
            }
        }

        /// <summary>
        /// Evaluate B(z1, z2).
        /// </summary>
        /// <param name="z1">x + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>B(z1, z2)</returns>
        public static (decimal Re, decimal Im) Beta(
            (decimal x, decimal y) z1,
            (decimal x, decimal y) z2)
        {
            var a = (ComplexOperator)z1;
            var b = (ComplexOperator)z2;

            return (ComplexOperator)Gamma(a - 1) * Gamma(b - 1) / Gamma(a + b - 1);
        }

        /// <summary>
        /// Evaluate Binom(z1, z2).
        /// </summary>
        /// <param name="z1">x + iy</param>
        /// <param name="z2">x' + iy'</param>
        /// <returns>Binom(z1, z2)</returns>
        public static (decimal Re, decimal Im) Binom(
            (decimal x, decimal y) z1,
            (decimal x, decimal y) z2)
        {
            var n = (ComplexOperator)z1;
            var k = (ComplexOperator)z2;

            return Reciprocal((n + 1) * Beta(n - k + 1, k + 1));
        }
    }
}
