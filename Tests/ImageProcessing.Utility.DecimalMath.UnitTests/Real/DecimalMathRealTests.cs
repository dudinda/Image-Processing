using System;

using ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.Real;
using ImageProcessing.Utility.DecimalMath.Real;
using ImageProcessing.Utility.DecimalMath.UnitTests.Factory;

using NUnit.Framework;

using static ImageProcessing.Utility.DecimalMath.Real.DecimalMathReal;

namespace ImageProcessing.Tests.Utility
{
    [TestFixture]
    public class DecimalMathRealTests
    {
        private readonly object[] _realAxis
            = DecimalMathRealCasesFactory.Factory["(-inf, +inf)"];
        private readonly object[] _trigonometry
            = DecimalMathRealCasesFactory.Factory["Trigonometry"];
        private readonly object[] _fromMinusToPlusOneClosed
            = DecimalMathRealCasesFactory.Factory["[-1, 1]"];
        private readonly object[] _fromMinusToPlusOneOpen
            = DecimalMathRealCasesFactory.Factory["(-1, 1)"];

        [Test, TestCaseSource(nameof(_realAxis))]
        public void FloorFunctionTest(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Floor(value));

            Assert.AreEqual(Floor(value), cmpVal);
        }

        [Test, TestCaseSource(nameof(_realAxis))]
        public void CeilFunctionTest(decimal value)
        {
            var cmpVal = Math.Ceiling(value);

            Assert.AreEqual(Ceil(value), cmpVal);
        }


        [Test, TestCaseSource(nameof(_realAxis))]
        public void ExponentTest(decimal value)
        { 
            var cmpVal = (decimal)Math.Exp((double)value);

            Assert.That(Abs(Exp(value) - cmpVal) < 0.0000001M);
        }

        [Test]
        public void ModuloTest()
        {
            var pi = DecimalMathReal.PI;

            Assert.AreEqual(Mod(pi / 2 + 3 * pi, pi), pi / 2);
            Assert.AreEqual(Mod(pi / 2 - 3 * pi, pi), pi / 2);
            Assert.AreEqual(Mod(25M, 5M), 0.0M);
            Assert.AreEqual(Mod(-1M, 3M), 2.0M);
            Assert.AreEqual(Mod(-1.27M, 1M), 0.73M);
            Assert.AreEqual(Mod(2.000256M, 1M), 0.000256M);
            Assert.AreEqual(Mod(3.0M / 2.0M, 1.0M / 2.0M), 0);

            Assert.AreEqual((pi / 2 + 3 * pi).Mod(pi), pi / 2);
            Assert.AreEqual((pi / 2 - 3 * pi).Mod(pi), pi / 2);
            Assert.AreEqual((25M).Mod(5M), 0.0M);
            Assert.AreEqual((-1M).Mod(3M), 2.0M);
            Assert.AreEqual((-1.27M).Mod(1M), 0.73M);
            Assert.AreEqual((2.000256M).Mod(1M), 0.000256M);
            Assert.AreEqual((3.0M / 2.0M).Mod(1.0M / 2.0M), 0);
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

            Assert.That((Log(target, logbase) - cmpVal).Abs(), Is.LessThan(0.00000001M));
            Assert.That((target.Log(logbase) - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }

        [Test, TestCaseSource(nameof(_nonNegativeRealAxis))]
        public void SqrtTests(decimal value)
        {
            var cmpVal = (decimal)Math.Sqrt((double)value);

            Assert.That(Abs(Sqrt(value) - cmpVal), Is.LessThan(0.00000001M));
        }
   
        [Test, TestCaseSource(nameof(_realAxis))]
        public void SignTest(decimal value)
        {
            var cmpVal = (decimal)(Math.Sign(value));

            Assert.That(Sign(value), Is.EqualTo(cmpVal));
        }

        #region Trigonometric functions tests

        [Test, TestCaseSource(nameof(_trigonometry))]
        public void CosineTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cos(value));

            Assert.That((Cos(target) - cmpVal).Abs(), Is.LessThan(0.00001M));
            Assert.That((target.Cos() - cmpVal).Abs(), Is.LessThan(0.00001M));
        }

        [Test, TestCaseSource(nameof(_realAxis))]
        public void CosineTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cos(value));

            Assert.That((DecimalMathReal.Cos(target) - cmpVal).Abs(), Is.LessThan(0.00001M));
            Assert.That((target.Cos() - cmpVal).Abs(), Is.LessThan(0.00001M));
        }

        [Test, TestCaseSource(nameof(_trigonometry))]
        public void SineTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cos(value));

            Assert.That((DecimalMathReal.Sin(target) - cmpVal).Abs(), Is.LessThan(0.00001M));
            Assert.That((target.Sin() - cmpVal).Abs(), Is.LessThan(0.00001M));
        }

        [Test, TestCaseSource(nameof(_realAxis))]
        public void SineTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Sin(value));

            Assert.That((DecimalMathReal.Sin(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Sin() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [Test, TestCaseSource(nameof(_trigonometry))]
        public void TangentTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Tan(value));

            Assert.That((DecimalMathReal.Tan(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Tan() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [Test, TestCaseSource(nameof(_realAxis))]
        public void TangentTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Tan(value));

            Assert.That((DecimalMathReal.Tan(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Tan() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [Test, TestCaseSource(nameof(_trigonometry))]
        public void CotangentTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(1.0 / Math.Tan(value));

            Assert.That((Cot(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Cot() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [Test, TestCaseSource(nameof(_realAxis))]
        public void CotangentTest(decimal value)
        {
            var cmpVal = (decimal)(1.0 / Math.Tan((double)value));

            Assert.That(Abs(Cot(value) - cmpVal), Is.LessThan(0.0000001M));
        }

        #endregion

        #region Hyperbolic functions tests

        [Test, TestCaseSource(nameof(_realAxis))]
        public void SinhTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Sinh(value));

            Assert.That((Sinh(target) - cmpVal).Abs(), Is.LessThan(0.00000001M));
            Assert.That((target.Sinh() - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }

        [Test, TestCaseSource(nameof(_realAxis))]
        public void CoshTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cosh(value));

            Assert.That((DecimalMathReal.Cosh(target) - cmpVal).Abs(), Is.LessThan(0.00000001M));
            Assert.That((target.Cosh() - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }

        [Test, TestCaseSource(nameof(_realAxis))]
        public void TanhTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Tanh(value));

            Assert.That((Tanh(target) - cmpVal).Abs(), Is.LessThan(0.00000001M));
            Assert.That((target.Tanh() - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }

        [Test, TestCaseSource(nameof(_realAxis))]
        public void CothTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(1.0 / Math.Tanh(value));

            Assert.That((Coth(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Coth() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        #endregion

        #region Inverse hyperbolic functions tests

        [Test, TestCaseSource(nameof(_realAxis))]
        public void ArsinhTests(decimal val)
        {
            var value = (double)val;

            var cmpVal = Convert.ToDecimal(Math.Log(value + Math.Sqrt(value * value + 1)));

            Assert.That(Abs(Arsinh(val) - cmpVal), Is.LessThan(0.000001M));
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

            Assert.That((DecimalMathReal.Arcosh(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
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

            Assert.That((DecimalMathReal.Artanh(target) - cmpVal).Abs(), Is.LessThan(0.0001M));
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

            Assert.That((DecimalMathReal.Arcoth(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Arcoth() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        #endregion

        #region Inverse trigonometric functions tests

        [Test, TestCaseSource(nameof(_fromMinusToPlusOneClosed))]
        public void ArcsinTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Asin(value));

            Assert.That((DecimalMathReal.Arcsin(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Arcsin() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

  
   
        [Test, TestCaseSource(nameof(_fromMinusToPlusOneClosed))]
        public void ArccosTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Acos(value));

            Assert.That((DecimalMathReal.Arccos(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Arccos() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }


        [Test, TestCaseSource(nameof(_realAxis))]
        public void ArctanSmallNumbersTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Atan(value));

            Assert.That((DecimalMathReal.Arctan(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Arctan() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }


        [Test, TestCaseSource(nameof(_realAxis))]
        public void ArccotTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Atan(1.0 / value));

            Assert.That((DecimalMathReal.Arccot(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Arccot() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        #endregion

        private static readonly object[] _nonNegativeRealAxis =
        {
            100000000000000M,
            1000.125123123123M,
            1000000000.0000000000007M,
            0.000000000000010M,
            0.1000412412512400M,
            0.999999231241241123231M,
            0M
        };

        private static readonly object[] _positiveRealAxis =
        {
            100000000000000M,
            1000.125123123123M,
            1000000000.0000000000007M,
            0.000000000000010M,
            0.1000412412512400M,
            0.999999231241241123231M,
        };
    }
}
