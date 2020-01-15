using System;
using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.DecimalMathExtensions;
using ImageProcessing.Common.Utility.DecimalMath;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace ImageProcessing.Tests.Utility
{
    [TestFixture]
    public class DecimalMathTests
    {
        [Test]
        [TestCase(-2.63)]
        [TestCase(-351.000001)]
        [TestCase(-0.00000001)]
        [TestCase(-0.230001)]
        public void FloorFunctionNegativeTest(double value)
        {
            var target = DecimalMath.Floor(Convert.ToDecimal(value));
            var cmpVal = Convert.ToDecimal(Math.Floor(value));

            Assert.AreEqual(target, cmpVal);
        }

        [Test]
        [TestCase(2.63)]
        [TestCase(351.000001)]
        [TestCase(0.00000001)]
        [TestCase(0.230001)]
        public void FloorFunctionPositiveTest(double value)
        {
            var target = DecimalMath.Floor(Convert.ToDecimal(value));
            var cmpVal = Convert.ToDecimal(Math.Floor(value));

            Assert.AreEqual(target, cmpVal);
        }

        [Test]
        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(1005)]
        [TestCase(0)]
        [TestCase(-1524)]
        public void FloorFunctionIdentityTest(decimal value)
        {
            var target = DecimalMath.Floor(Convert.ToDecimal(value));
            var cmpVal = Convert.ToDecimal(Math.Floor(value));

            Assert.AreEqual(target, cmpVal);
        }

        [Test]
        [TestCase(2.63)]
        [TestCase(351.000001)]
        [TestCase(0.00000001)]
        [TestCase(0.230001)]
        public void CeilFunctionNegativeTest(decimal value)
        {
            Assert.AreEqual(value.Ceil(), -2);
        }

        [Test]
        [TestCase(2.63)]
        public void CeilFunctionPositiveTest(decimal value)
        {
            Assert.AreEqual(value.Ceil(), 3);
        }

        [Test]
        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(1005)]
        [TestCase(0)]
        [TestCase(-1524)]
        public void CeilFunctionIdentityTest(decimal value)
        {
            Assert.AreEqual(value.Ceil(), value);
        }

        [Test]
        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(2.12524)]
        [TestCase(-2.1243)]
        [TestCase(0)]
        [TestCase(1)]
        public void ExponentTest(double value)
        {
            var target = DecimalMath.Exp(Convert.ToDecimal(value));
            var cmpVal = Convert.ToDecimal(Math.Exp(value));

            Assert.That((target - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [Test]
        [TestCase(3 * Math.PI / 2)]
        [TestCase(Math.PI / 2)]
        [TestCase(Math.PI)]
        [TestCase(2 * Math.PI)]
        [TestCase(Math.PI / 3)]
        [TestCase(Math.PI / 4)]
        [TestCase(Math.PI / 6)]
        public void CosineTableValuesTest(double value)
        {
            var target = DecimalMath.Cos(Convert.ToDecimal(value));
            var cmpVal = Convert.ToDecimal(Math.Cos(value));

            Assert.That((target - cmpVal).Abs(), Is.LessThan(0.0000001M));       
        }

        [Test]
        public void ModuloTest()
        {
            var pi = DecimalMath.PI;

            Assert.AreEqual((pi / 2 + 3 * pi).Mod(pi), pi / 2);
            Assert.AreEqual((pi / 2 - 3 * pi).Mod(pi), pi / 2);
            Assert.AreEqual((25M).Mod(5M), 0.0M);
            Assert.AreEqual((-1M).Mod(3M), 2.0M);
            Assert.AreEqual((-1.27M).Mod(1M), 0.73M);
            Assert.AreEqual((2.000256M).Mod(1M), 0.000256M);
            Assert.AreEqual((3.0M / 2.0M).Mod(1.0M / 2.0M), 0);
        }

        [Test]
        [TestCase(0, 1)]
        public void ThrowIfIntegralDoesntConvergeTrapezoidalMethod(int a, int b)
        {
            var interval = (Convert.ToDecimal(a), Convert.ToDecimal(b));

            Assert.That(() => DecimalMath.Integrate(Integration.Trapezoidal, (x) => 1 / x, interval, 10000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => DecimalMath.Integrate(Integration.Trapezoidal, (x) => 1 / (1 - x), interval, 10000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => DecimalMath.Integrate(Integration.Trapezoidal, (x) => 1 / (x * x - 1), interval, 10000), Throws.TypeOf<ArithmeticException>());
        }

        [Test]
        [TestCase(3 * Math.PI / 2)]
        [TestCase(Math.PI / 2)]
        [TestCase(Math.PI)]
        [TestCase(2 * Math.PI)]
        [TestCase(Math.PI / 3)]
        [TestCase(Math.PI / 4)]
        [TestCase(Math.PI / 6)]
        public void SineTableValuesTest(double value)
        {
            var target = DecimalMath.Sin(Convert.ToDecimal(value));
            var cmpVal = Convert.ToDecimal(Math.Sin(value));

            Assert.That((target - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }


        [Test]
        [TestCase(1.25, 5)]
        [TestCase(567, 123)]
        [TestCase(0.245, 0.001)]
        [TestCase(Math.E * Math.E, Math.E)]
        [TestCase(2512, 0.5)]
        public void LogSmallNumbersTest(double value, double lbase)
        {
            var target = DecimalMath.Log(Convert.ToDecimal(value), Convert.ToDecimal(lbase));
            var cmpVal = Convert.ToDecimal(Math.Log(value, lbase));

            Assert.That((target - cmpVal).Abs(), Is.LessThan(0.001M));
        }


        [Test]
        [TestCase(0)]
        [TestCase(0.0000000001)]
        [TestCase(-100)]
        [TestCase(Math.PI * Math.E)]   
        [TestCase(-0.0000000001)]
        [TestCase(-25)]
        [TestCase(-189)]
        [TestCase(100)]
        public void AtanAndAcotSmallNumbersTest(double value)
        {
            var target = DecimalMath.Atan(Convert.ToDecimal(value));
            var cmpVal = Convert.ToDecimal(Math.Atan(value));

            Assert.That((target - cmpVal).Abs(), Is.LessThan(0.0001M));

            target = DecimalMath.Acot(Convert.ToDecimal(value));
            cmpVal = Convert.ToDecimal(Math.Sign(value) * Math.PI / 2 - Math.Atan(value));

            Assert.That((target - cmpVal).Abs(), Is.LessThan(0.0001M));
        }


    }
}
