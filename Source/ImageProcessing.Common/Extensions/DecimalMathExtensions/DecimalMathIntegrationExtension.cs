using System;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.Common.Extensions.DecimalMathExtensions
{
    public static class DecimalMathIntegrationExtension
    {
        public static decimal Integrate(this Integration method, Func<decimal, decimal> f, (decimal x1, decimal x2) interval, int N = 40000)
        {
            switch(method)
            {
                case Integration.Trapezoidal:
                    return Integrate(method, f, interval, N);
                case Integration.MonteCarlo:
                    return Integrate(method, f, interval, N);

                default: throw new NotImplementedException();
            }
        }
    }
}
