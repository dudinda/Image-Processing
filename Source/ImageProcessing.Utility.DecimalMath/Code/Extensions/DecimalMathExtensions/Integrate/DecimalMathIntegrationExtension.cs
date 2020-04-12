using System;

using ImageProcessing.Utility.DecimalMath.Code.Enums;
using ImageProcessing.Utility.DecimalMath.Numerical;

namespace ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.Integrate
{
    public static class DecimalMathIntegrationExtension
    {
        public static decimal Integrate(this Integration method, Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
            switch(method)
            {
                case Integration.Trapezoidal:
                    return DecimalMathIntegration.Integrate(method, f, interval, N);
                case Integration.MonteCarlo:
                    return DecimalMathIntegration.Integrate(method, f, interval, N);

                default: throw new NotImplementedException();
            }
        }
    }
}
