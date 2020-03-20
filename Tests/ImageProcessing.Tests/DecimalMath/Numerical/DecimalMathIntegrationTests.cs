using System;

using ImageProcessing.DecimalMath.Code.Enums;
using ImageProcessing.DecimalMath.Numerical;
using ImageProcessing.DecimalMath.Real;

using NUnit.Framework;


using static ImageProcessing.DecimalMath.Numerical.DecimalMathIntegration;
using static ImageProcessing.DecimalMath.Real.DecimalMathReal;

namespace ImageProcessing.Tests.DecimalMath.Numerical
{
    [TestFixture]
    public class DecimalMathIntegrationTests
    {

        [TestCase(0, 1)]
        public void ThrowIfIntegralDoesntConvergeTrapezoidalMethod(int a, int b)
        {
            var interval = (Convert.ToDecimal(a), Convert.ToDecimal(b));

            Assert.That(() => Integrate(Integration.Trapezoidal, (x) => 1 / x, interval, 20000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => Integrate(Integration.Trapezoidal, (x) => 1 / (1 - x), interval, 20000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => Integrate(Integration.Trapezoidal, (x) => 1 / (x * x - 1), interval, 20000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => Integrate(Integration.Trapezoidal, (x) => 1 / (x * x - 0.5M), interval, 20000), Throws.TypeOf<ArithmeticException>());
        }

        [TestCase(5, 10)]
        public void TrapezoidalMethodIntegralEvaluationResult(int a, int b)
        {
            var integrateResult = Integrate(Integration.Trapezoidal, (x) => Log(x), (a, b), 50000);

            Assert.That(Abs(integrateResult - 9.97866M), Is.LessThan(0.000001M));
        }
    }
}
