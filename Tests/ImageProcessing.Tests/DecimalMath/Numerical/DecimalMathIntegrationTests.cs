using System;

using ImageProcessing.DecimalMath.Code.Enums;
using ImageProcessing.DecimalMath.Numerical;

using NUnit.Framework;

namespace ImageProcessing.Tests.DecimalMath.Numerical
{
    [TestFixture]
    public class DecimalMathIntegrationTests
    {

        [TestCase(0, 1)]
        public void ThrowIfIntegralDoesntConvergeTrapezoidalMethod(int a, int b)
        {
            var interval = (Convert.ToDecimal(a), Convert.ToDecimal(b));

            Assert.That(() => DecimalMathIntegration.Integrate(Integration.Trapezoidal, (x) => 1 / x, interval, 10000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => DecimalMathIntegration.Integrate(Integration.Trapezoidal, (x) => 1 / (1 - x), interval, 10000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => DecimalMathIntegration.Integrate(Integration.Trapezoidal, (x) => 1 / (x * x - 1), interval, 10000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => DecimalMathIntegration.Integrate(Integration.Trapezoidal, (x) => 1 / (x * x - 1.0M / 2.0M), interval, 10000), Throws.TypeOf<ArithmeticException>());
        }
    }
}
