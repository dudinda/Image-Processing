using System;

using ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.Real;

using static ImageProcessing.Utility.DecimalMath.Complex.DecimalMathComplex;
using static ImageProcessing.Utility.DecimalMath.Real.DecimalMathReal;

namespace ImageProcessing.Utility.DecimalMath.Special
{
    public static class DecimalMathSpecial
    {   
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
                       / Fmad(k, Fmad(1, k, 2), 1);

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
                total = -total * x * x * Fmad(2, k, -1)
                       / Fmad(k, Fmad(k, Fmad(4, k, 10), 8), 2);

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
                total = -total * x * x * Fmad(2, k, -1)
                       / Fmad(k, Fmad(k, Fmad(8, k, 8), 2), 0);

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
                p = Fmad(p, w, 3.43273939e-07M);
                p = Fmad(p, w, -3.5233877e-06M);
                p = Fmad(p, w, -4.39150654e-06M);
                p = Fmad(p, w, 0.00021858087M);
                p = Fmad(p, w, -0.00125372503M);
                p = Fmad(p, w, -0.00417768164M);
                p = Fmad(p, w, 0.246640727M);
                p = Fmad(p, w, 1.50140941M);
            }
            else
            {
                w = Sqrt(w) - 3.000000M;
                p = -0.000200214257M;
                p = Fmad(p, w, 0.000100950558M);
                p = Fmad(p, w, 0.00134934322M);
                p = Fmad(p, w, -0.00367342844M);
                p = Fmad(p, w, 0.00573950773M);
                p = Fmad(p, w, -0.0076224613M);
                p = Fmad(p, w, 0.00943887047M);
                p = Fmad(p, w, 1.00167406M);
                p = Fmad(p, w, 2.83297682M);
            }

            return p * x;
        }

        /*
        private static int g = 7;
        private static decimal[] p =
            {0.99999999999980993M, 676.5203681218851M,    -1259.1392167224028M,
             771.32342877765313M, -176.61502916214059M,    12.507343278686905M,
            -0.13857109526572012M, 9.9843695780195716e-6M, 1.5056327351493116e-7M};

        public (decimal x, decimal y) Gamma((decimal x, decimal y) z)
        {
            if (z.x < 0.5M)
            {
                return Div((PI, 0),  Mul(Sin(Mul(z, PI)), Gamma(Sub((1, 0), z))));
            }
            else
            {
                z = (z.x - 1, z.y);

                var (re, im) = (p[0], 0M);

                for (var i = 1; i < g + 2; ++i)
                {
                    (re, im) = Add((re, im), Div((p[i], 0), (Add(z, (decimal)i))));
                }

                var (tRe, tIm) = Add(z, g + 0.5M);

                return PrincipalSqrt(2 * Math.PI) * (Complex.Pow(t, z + 0.5)) * Complex.Exp(-t) * x;
            }
        }
        */
    }
}
