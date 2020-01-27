using System;

using ImageProcessing.Common.Extensions.DecimalMathExtensions;

using static ImageProcessing.Common.Utility.DecimalMath.DecimalMath;

namespace ImageProcessing.Common.Utility.DecimalMath
{
    public static class DecimalMathSpecial
    {
        public static decimal Li(decimal x)
        {
            return Ei(Log(x));
        }

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

        public static decimal ErfInv(decimal x)
        {
            if(x.Abs() >= 1)
            {
                throw new ArgumentException("NaN");
            }

            decimal  p;
            var w = -DecimalMath.Log((1.0M - x) * (1.0M + x));

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

    }
}
