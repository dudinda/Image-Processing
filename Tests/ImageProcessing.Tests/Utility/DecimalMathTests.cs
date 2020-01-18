using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.DecimalMathExtensions;
using ImageProcessing.Common.Utility.DecimalMath;

using NUnit.Framework;

namespace ImageProcessing.Tests.Utility
{
    [TestFixture]
    public class DecimalMathTests
    {
        [TestCase(-2.63)]
        [TestCase(-351.000001)]
        [TestCase(-0.00000001)]
        [TestCase(-0.230001)]
        public void FloorFunctionNegativeTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Floor(value));

            Assert.AreEqual(DecimalMath.Floor(target), cmpVal);
            Assert.AreEqual(target.Floor(), cmpVal);
        }

        [TestCase(2.63)]
        [TestCase(351.000001)]
        [TestCase(0.00000001)]
        [TestCase(0.230001)]
        public void FloorFunctionPositiveTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Floor(value));

            Assert.AreEqual(DecimalMath.Floor(target), cmpVal);
            Assert.AreEqual(target.Floor(), cmpVal);
        }

        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(1005)]
        [TestCase(0)]
        [TestCase(-1524)]
        public void FloorFunctionIdentityTest(decimal value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Floor(value));

            Assert.AreEqual(DecimalMath.Floor(target), cmpVal);
            Assert.AreEqual(target.Floor(), cmpVal);
        }

        [TestCase(-2.63)]
        [TestCase(-351.000001)]
        [TestCase(-0.00000001)]
        [TestCase(-0.230001)]
        public void CeilFunctionNegativeTest(decimal value)
        {
            Assert.AreEqual(value.Ceil(), Math.Ceiling(value));
            Assert.AreEqual(DecimalMath.Ceil(value), Math.Ceiling(value));
        }

        [TestCase(2.63)]
        [TestCase(351.000001)]
        [TestCase(0.00000001)]
        [TestCase(0.230001)]
        public void CeilFunctionPositiveTest(decimal value)
        {
            Assert.AreEqual(value.Ceil(), Math.Ceiling(value));
            Assert.AreEqual(DecimalMath.Ceil(value), Math.Ceiling(value));
        }

        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(1005)]
        [TestCase(0)]
        [TestCase(-1524)]
        public void CeilFunctionIdentityTest(decimal value)
        {
            Assert.AreEqual(value.Ceil(), value);
            Assert.AreEqual(DecimalMath.Ceil(value), value);
        }

        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(2.12524)]
        [TestCase(-2.1243)]
        [TestCase(0)]
        [TestCase(1)]
        public void ExponentTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Exp(value));

            Assert.That((DecimalMath.Exp(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Exp() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [Test]
        public void ModuloTest()
        {
            var pi = DecimalMath.PI;

            Assert.AreEqual(DecimalMath.Mod(pi / 2 + 3 * pi, pi), pi / 2);
            Assert.AreEqual(DecimalMath.Mod(pi / 2 - 3 * pi, pi), pi / 2);
            Assert.AreEqual(DecimalMath.Mod(25M, 5M), 0.0M);
            Assert.AreEqual(DecimalMath.Mod(-1M, 3M), 2.0M);
            Assert.AreEqual(DecimalMath.Mod(-1.27M, 1M), 0.73M);
            Assert.AreEqual(DecimalMath.Mod(2.000256M, 1M), 0.000256M);
            Assert.AreEqual(DecimalMath.Mod(3.0M / 2.0M, 1.0M / 2.0M), 0);

            Assert.AreEqual((pi / 2 + 3 * pi).Mod(pi), pi / 2);
            Assert.AreEqual((pi / 2 - 3 * pi).Mod(pi), pi / 2);
            Assert.AreEqual((25M).Mod(5M), 0.0M);
            Assert.AreEqual((-1M).Mod(3M), 2.0M);
            Assert.AreEqual((-1.27M).Mod(1M), 0.73M);
            Assert.AreEqual((2.000256M).Mod(1M), 0.000256M);
            Assert.AreEqual((3.0M / 2.0M).Mod(1.0M / 2.0M), 0);
        }

        [TestCase(0, 1)]
        public void ThrowIfIntegralDoesntConvergeTrapezoidalMethod(int a, int b)
        {
            var interval = (Convert.ToDecimal(a), Convert.ToDecimal(b));

            Assert.That(() => DecimalMathIntegration.Integrate(Integration.Trapezoidal, (x) => 1 / x, interval, 10000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => DecimalMathIntegration.Integrate(Integration.Trapezoidal, (x) => 1 / (1 - x), interval, 10000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => DecimalMathIntegration.Integrate(Integration.Trapezoidal, (x) => 1 / (x * x - 1), interval, 10000), Throws.TypeOf<ArithmeticException>());
            Assert.That(() => DecimalMathIntegration.Integrate(Integration.Trapezoidal, (x) => 1 / (x * x - 1.0M / 2.0M), interval, 10000), Throws.TypeOf<ArithmeticException>());
        }

        [TestCase(1.25, 5)]
        [TestCase(567, 123)]
        [TestCase(0.245, 0.001)]
        [TestCase(Math.E * Math.E, Math.E)]
        [TestCase(1500, 0.5)]
        public void LogSmallNumbersTest(double value, double lbase)
        {
            var target  = Convert.ToDecimal(value);
            var logbase = Convert.ToDecimal(lbase);
            var cmpVal  = Convert.ToDecimal(Math.Log(value, lbase));

            Assert.That((DecimalMath.Log(target, logbase) - cmpVal).Abs(), Is.LessThan(0.00000001M));
            Assert.That((target.Log(logbase) - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }

        [TestCase(0)]
        [TestCase(0.0000000001)]
        [TestCase(0.25)]
        [TestCase(1125123)]
        [TestCase(100)]
        [TestCase(231.24125)]
        [TestCase(100000000)]
        public void SqrtTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Sqrt(value));

            Assert.That((DecimalMath.Sqrt(target) - cmpVal).Abs(), Is.LessThan(0.00000001M));
            Assert.That((target.Sqrt() - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }
   
        [TestCase(0)]
        public void SignIdentityTest(double value)
        {
            var target = Convert.ToDecimal(value);

            Assert.That(DecimalMath.Sign(target), Is.EqualTo(0));
            Assert.That(target.Sign(), Is.EqualTo(0));
        }

        [TestCase(1)]
        [TestCase(0.000000000000001)]
        [TestCase(0.00001)]
        [TestCase(100)]
        [TestCase(10000000000000)]
        public void SignPositiveValueTest(double value)
        {
            var target = Convert.ToDecimal(value);

            Assert.That(DecimalMath.Sign(target), Is.EqualTo(1));
            Assert.That(target.Sign(), Is.EqualTo(1));
        }

        [TestCase(-1)]
        [TestCase(-0.000000000000001)]
        [TestCase(-0.00001)]
        [TestCase(-100)]
        [TestCase(-10000000000000)]
        public void SignNegativeValueTest(double value)
        {
            var target = Convert.ToDecimal(value);

            Assert.That(DecimalMath.Sign(target), Is.EqualTo(-1));
            Assert.That(target.Sign(), Is.EqualTo(-1));
        }

        #region Trigonometric functions tests

        [TestCase(3 * Math.PI / 2)]
        [TestCase(Math.PI / 2)]
        [TestCase(Math.PI)]
        [TestCase(2 * Math.PI)]
        [TestCase(Math.PI / 3)]
        [TestCase(Math.PI / 4)]
        [TestCase(Math.PI / 6)]
        public void CosineTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cos(value));

            Assert.That((DecimalMath.Cos(target) - cmpVal).Abs(), Is.LessThan(0.00001M));
            Assert.That((target.Cos() - cmpVal).Abs(), Is.LessThan(0.00001M));
        }

        [TestCase(100000000000000)]
        [TestCase(1000.125123123123)]
        [TestCase(1000000000.0000000000007)]
        [TestCase(0.000000000000010)]
        [TestCase(0.1000412412512400)]
        [TestCase(0.999999231241241123231)]
        [TestCase(0)]
        [TestCase(-100000000000000)]
        [TestCase(-100000.125123123123)]
        [TestCase(-1000000000.0000000000007)]
        [TestCase(-0.000000000000010)]
        [TestCase(-0.1000412412512400)]
        [TestCase(-0.999999231241241123231)]
        public void CosineTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cos(value));

            Assert.That((DecimalMath.Cos(target) - cmpVal).Abs(), Is.LessThan(0.00001M));
            Assert.That((target.Cos() - cmpVal).Abs(), Is.LessThan(0.00001M));
        }

        [TestCase(3 * Math.PI / 2)]
        [TestCase(Math.PI / 2)]
        [TestCase(Math.PI)]
        [TestCase(2 * Math.PI)]
        [TestCase(Math.PI / 3)]
        [TestCase(Math.PI / 4)]
        [TestCase(Math.PI / 6)]
        public void SineTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cos(value));

            Assert.That((DecimalMath.Sin(target) - cmpVal).Abs(), Is.LessThan(0.00001M));
            Assert.That((target.Sin() - cmpVal).Abs(), Is.LessThan(0.00001M));
        }

        [TestCase(100000000000000)]
        [TestCase(1000.125123123123)]
        [TestCase(1000000000.0000000000007)]
        [TestCase(0.000000000000010)]
        [TestCase(0.1000412412512400)]
        [TestCase(0.999999231241241123231)]
        [TestCase(0)]
        [TestCase(-100000000000000)]
        [TestCase(-1000.125123123123)]
        [TestCase(-1000000000.0000000000007)]
        [TestCase(-0.000000000000010)]
        [TestCase(-0.1000412412512400)]
        [TestCase(-0.999999231241241123231)]
        public void SineTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Sin(value));

            Assert.That((DecimalMath.Sin(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Sin() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }


        [TestCase(Math.PI)]
        [TestCase(2 * Math.PI)]
        [TestCase(Math.PI / 3)]
        [TestCase(Math.PI / 4)]
        [TestCase(Math.PI / 6)]
        [TestCase(-Math.PI)]
        [TestCase(-2 * Math.PI)]
        [TestCase(-Math.PI / 3)]
        [TestCase(-Math.PI / 4)]
        [TestCase(-Math.PI / 6)]
        public void TangentTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Tan(value));

            Assert.That((DecimalMath.Tan(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Tan() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [TestCase(100000000000000)]
        [TestCase(1000.125123123123)]
        [TestCase(1000000000.0000000000007)]
        [TestCase(0.000000000000010)]
        [TestCase(0.1000412412512400)]
        [TestCase(0.999999231241241123231)]
        [TestCase(0)]
        [TestCase(-100000000000000)]
        [TestCase(-1000.125123123123)]
        [TestCase(-1000000000.0000000000007)]
        [TestCase(-0.000000000000010)]
        [TestCase(-0.1000412412512400)]
        [TestCase(-0.999999231241241123231)]
        public void TangentTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Tan(value));

            Assert.That((DecimalMath.Tan(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Tan() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }


        [TestCase(Math.PI / 2)]
        [TestCase(Math.PI / 3)]
        [TestCase(Math.PI / 4)]
        [TestCase(Math.PI / 6)]
        [TestCase(-Math.PI / 2)]
        [TestCase(-Math.PI / 3)]
        [TestCase(-Math.PI / 4)]
        [TestCase(-Math.PI / 6)]
        public void CotangentTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(1.0 / Math.Tan(value));

            Assert.That((DecimalMath.Cot(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Cot() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [TestCase(100000000000000)]
        [TestCase(1000.125123123123)]
        [TestCase(1000000000.0000000000007)]
        [TestCase(0.000000000000010)]
        [TestCase(0.1000412412512400)]
        [TestCase(0.999999231241241123231)]
        [TestCase(-100000000000000)]
        [TestCase(-1000.125123123123)]
        [TestCase(-1000000000.0000000000007)]
        [TestCase(-0.000000000000010)]
        [TestCase(-0.1000412412512400)]
        [TestCase(-0.999999231241241123231)]

        public void CotangentTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(1.0 / Math.Tan(value));

            Assert.That((DecimalMath.Cot(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Cot() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        #endregion

        #region Hyperbolic functions tests

        [TestCase(0)]
        [TestCase(0.1)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(5)]
        [TestCase(-0.001)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-5)]
        public void SinhTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Sinh(value));

            Assert.That((DecimalMath.Sinh(target) - cmpVal).Abs(), Is.LessThan(0.00000001M));
            Assert.That((target.Sinh() - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }

        [TestCase(0)]
        [TestCase(0.1)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(5)]
        [TestCase(-0.001)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-5)]
        public void CoshTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cosh(value));

            Assert.That((DecimalMath.Cosh(target) - cmpVal).Abs(), Is.LessThan(0.00000001M));
            Assert.That((target.Cosh() - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }

        [TestCase(0)]
        [TestCase(0.1)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(5)]
        [TestCase(-0.001)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-5)]
        public void TanhTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Tanh(value));

            Assert.That((DecimalMath.Tanh(target) - cmpVal).Abs(), Is.LessThan(0.00000001M));
            Assert.That((target.Tanh() - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }

        [TestCase(0.001)]
        [TestCase(0.0000001)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(5)]
        [TestCase(-0.001)]
        [TestCase(-0.0000001)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-5)]
        public void CothTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(1.0 / Math.Tanh(value));

            Assert.That((DecimalMath.Coth(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Coth() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        #endregion

        #region Inverse hyperbolic functions tests

        [TestCase(0)]
        [TestCase(0.0000001)]
        [TestCase(0.01)]
        [TestCase(2)]
        [TestCase(20)]
        [TestCase(200)]
        [TestCase(2000)]
        [TestCase(-200)]
        [TestCase(-0.0000001)]
        [TestCase(-0.01)]
        [TestCase(-2)]
        [TestCase(-2000)]
        public void ArsinhTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Log(value + Math.Sqrt(value * value + 1)));

            Assert.That((DecimalMath.Arsinh(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Arsinh() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        [TestCase(1)]
        [TestCase(1.000001)]
        [TestCase(2)]
        [TestCase(20.002523)]
        [TestCase(200)]
        [TestCase(2000.12516)]
        [TestCase(20000)]
        public void ArcoshTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Log(value + Math.Sqrt(value * value - 1)));

            Assert.That((DecimalMath.Arcosh(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Arcosh() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        [TestCase(-0.999999999)]
        [TestCase(-0.125162123)]
        [TestCase(-0.00000001)]
        [TestCase(0)]
        [TestCase(0.00000001)]
        [TestCase(0.125162123)]
        [TestCase(0.99999999)]
        public void ArtanhTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(0.5 * Math.Log((1.0 + value) / (1.0 - value)));

            Assert.That((DecimalMath.Artanh(target) - cmpVal).Abs(), Is.LessThan(0.0001M));
            Assert.That((target.Artanh() - cmpVal).Abs(), Is.LessThan(0.0001M));
        }

        [TestCase(90000.13123)]
        [TestCase(5132)]
        [TestCase(100.125123)]
        [TestCase(10)]
        [TestCase(1.000000001)]
        [TestCase(-1.000000001)]
        [TestCase(-10)]
        [TestCase(-100.125123)]
        [TestCase(-5132)]
        [TestCase(-90000.13123)]
        public void ArcothTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(0.5 * Math.Log((value + 1.0) / (value - 1.0)));

            Assert.That((DecimalMath.Arcoth(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Arcoth() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        #endregion

        #region Inverse trigonometric functions tests

        [TestCase(-1)]
        [TestCase(-0.5)]
        [TestCase(-0.0000000001)]
        [TestCase(0)]
        [TestCase(0.0000000001)]
        [TestCase(0.5)]
        [TestCase(1)]
        public void ArcsinTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Asin(value));

            Assert.That((DecimalMath.Arcsin(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Arcsin() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

  
   
        [TestCase(-1)]
        [TestCase(-0.5)]
        [TestCase(-0.0000000001)]
        [TestCase(0)]
        [TestCase(0.0000000001)]
        [TestCase(0.5)]
        [TestCase(1)]
        public void ArccosTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Acos(value));

            Assert.That((DecimalMath.Arccos(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Arccos() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }


        [TestCase(0)]
        [TestCase(0.0000000001)]
        [TestCase(-100)]
        [TestCase(Math.PI * Math.E)]
        [TestCase(-0.0000000001)]
        [TestCase(-5)]
        [TestCase(-9)]
        [TestCase(100)]
        public void ArctanSmallNumbersTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Atan(value));

            Assert.That((DecimalMath.Arctan(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Arctan() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }


        [TestCase(0.0000000001)]
        [TestCase(-100)]
        [TestCase(Math.PI * Math.E)]
        [TestCase(-0.0000000001)]
        [TestCase(-5)]
        [TestCase(-9)]
        [TestCase(100)]
        public void ArccotSmallNumbersTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Atan(1.0 / value));

            Assert.That((DecimalMath.Arccot(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Arccot() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        #endregion


    }
}
