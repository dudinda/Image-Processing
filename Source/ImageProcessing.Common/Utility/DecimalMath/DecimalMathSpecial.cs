using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Common.Utility.DecimalMath
{
    public static class DecimalMathSpecial
    {
        public static decimal ErfInv(decimal x)
        {
            decimal  p;
            var w = -DecimalMath.Log((1.0M - x) * (1.0M + x));

            if (w < 5.000000M)
            {
                w = w - 2.500000M;
                p = 2.81022636e-08M;
                p = DecimalMath.Fmad(p, w, 3.43273939e-07M);
                p = DecimalMath.Fmad(p, w, -3.5233877e-06M);
                p = DecimalMath.Fmad(p, w, -4.39150654e-06M);
                p = DecimalMath.Fmad(p, w, 0.00021858087M);
                p = DecimalMath.Fmad(p, w, -0.00125372503M);
                p = DecimalMath.Fmad(p, w, -0.00417768164M);
                p = DecimalMath.Fmad(p, w, 0.246640727M);
                p = DecimalMath.Fmad(p, w, 1.50140941M);
            }
            else
            {
                w = DecimalMath.Sqrt(w) - 3.000000M;
                p = -0.000200214257M;
                p = DecimalMath.Fmad(p, w, 0.000100950558M);
                p = DecimalMath.Fmad(p, w, 0.00134934322M);
                p = DecimalMath.Fmad(p, w, -0.00367342844M);
                p = DecimalMath.Fmad(p, w, 0.00573950773M);
                p = DecimalMath.Fmad(p, w, -0.0076224613M);
                p = DecimalMath.Fmad(p, w, 0.00943887047M);
                p = DecimalMath.Fmad(p, w, 1.00167406M);
                p = DecimalMath.Fmad(p, w, 2.83297682M);
            }

            return p * x;
        }

    }
}
