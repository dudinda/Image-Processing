using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DecimalMath.Code.Enums;
using ImageProcessing.DecimalMath.Integration;

namespace ImageProcessing.Common.Extensions.DecimalMathExtensions
{
    public static class DecimalMathIntegrationExtension
    {
        public static decimal Integration(this Integrate method, Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
            switch(method)
            {
                case Integrate.Trapezoidal:
                    return DecimalMathIntegration.Integration(method, f, interval, N);
                case Integrate.MonteCarlo:
                    return DecimalMathIntegration.Integration(method, f, interval, N);

                default: throw new NotImplementedException();
            }
        }
    }
}
