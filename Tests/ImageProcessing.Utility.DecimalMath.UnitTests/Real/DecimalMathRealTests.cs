using System;

using ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.RealAxis;
using ImageProcessing.Utility.DecimalMath.RealAxis;
using ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory;
using ImageProcessing.Utility.DecimalMath.UnitTests.CaseRepository;

using NUnit.Framework;

using static ImageProcessing.Utility.DecimalMath.RealAxis.DecimalMathReal;
using static ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory.RealDomainCasesFactory;

namespace ImageProcessing.Tests.Utility
{
    [TestFixture]
    public class DecimalMathRealTests
    {
        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void FloorFunctionTest(decimal value)
            => Assert.AreEqual(Floor(value), Math.Floor(value));

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void CeilFunctionTest(decimal value)
            => Assert.AreEqual(Ceil(value), Math.Ceiling(value));

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void ExponentTest(decimal value)
            => Assert.That(
                Abs(Exp(value) - (decimal)Math.Exp((double)value)),
                Is.LessThan(0.0000001M)
            );

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

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetNonNegativeRealAxis))]
        public void SqrtTests(decimal value)
            => Assert.That(
                Abs(Sqrt(value) - (decimal)Math.Sqrt((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void SignTest(decimal value)
            => Assert.That(
                Sign(value),
                Is.EqualTo(Math.Sign(value))
            );

        #region Trigonometric functions tests

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetTrigonometryPoints))]
        public void CosineTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cos(value));

            Assert.That((Cos(target) - cmpVal).Abs(), Is.LessThan(0.00001M));
            Assert.That((target.Cos() - cmpVal).Abs(), Is.LessThan(0.00001M));
        }

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void CosineTest(decimal value)
            => Assert.That(
                Abs(Cos(value) - (decimal)Math.Cos((double)value)),
                Is.LessThan(0.00001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetTrigonometryPoints))]
        public void SineTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Cos(value));

            Assert.That((DecimalMathReal.Sin(target) - cmpVal).Abs(), Is.LessThan(0.00001M));
            Assert.That((target.Sin() - cmpVal).Abs(), Is.LessThan(0.00001M));
        }

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void SineTest(decimal value)
            => Assert.That(
                Abs(Sin(value) - (decimal)Math.Sin((double)value)),
                Is.LessThan(0.0000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetTrigonometryPoints))]
        public void TangentTableValuesTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Tan(value));

            Assert.That((DecimalMathReal.Tan(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Tan() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void TangentTest(decimal value)
            => Assert.That(
                Abs(Tan(value) - (decimal)Math.Tan((double)value)),
                Is.LessThan(0.0000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetTrigonometryPoints))]
        public void CotangentTableValuesTest(double value)
            => Assert.That(
                Abs(Cot(Convert.ToDecimal(value)) - Convert.ToDecimal(1.0 / Math.Tan(value))),
                Is.LessThan(0.0000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void CotangentTest(decimal value)
            => Assert.That(
                Abs(Cot(value) - (decimal)(1.0 / Math.Tan((double)value))),
                Is.LessThan(0.0000001M)
            );

        #endregion

        #region Hyperbolic functions tests

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void SinhTests(decimal value)
            => Assert.That(
                Abs(Sinh(value) - (decimal)Math.Sinh((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void CoshTests(decimal value)
            => Assert.That(
                Abs(Cosh(value) - (decimal)Math.Cosh((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void TanhTests(decimal value)
            => Assert.That(
                Abs(Tanh(value) - (decimal)Math.Tanh((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void CothTests(decimal value)
            => Assert.That(
                Abs(Coth(value) - (decimal)(1.0 / Math.Tanh((double)value))),
                Is.LessThan(0.000001M)
            );

        #endregion

        #region Inverse hyperbolic functions tests

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void ArsinhTests(decimal val)
        {
            var value = (double)val;

            var cmpVal = Convert.ToDecimal(Math.Log(value + Math.Sqrt(value * value + 1)));

            Assert.That(Abs(Arsinh(val) - cmpVal), Is.LessThan(0.000001M));
        }
        
        [Test, TestCaseSource(
           typeof(RealDomainCasesFactory),
           nameof(HalfOpenIntervalFromOneToPlusInf))]
        public void ArcoshTests(decimal val)
        {
            var value = (double)val;

            var cmpVal = Convert.ToDecimal(Math.Log(value + Math.Sqrt(value * value - 1)));

            Assert.That((Arcosh(val) - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        [Test, TestCaseSource(
           typeof(RealDomainCasesFactory),
           nameof(GetOpenIntervalFromMinusOneToOne))]
        public void ArtanhTests(decimal val)
        {
            var value = (double)val;

            var cmpVal = Convert.ToDecimal(0.5 * Math.Log((1.0 + value) / (1.0 - value)));

            Assert.That((Artanh(val) - cmpVal).Abs(), Is.LessThan(0.0001M));
        }

        [Test, TestCaseSource(
          typeof(RealDomainCasesFactory),
          nameof(GetRealAxisExceptClosedFromMinusToPlusOne))]
        public void ArcothTests(decimal val)
        {
            var value = (double)val;
            var cmpVal = Convert.ToDecimal(0.5 * Math.Log((value + 1.0) / (value - 1.0)));

            Assert.That(Abs(Arcoth(val) - cmpVal), Is.LessThan(0.000001M));
        }

        #endregion

        #region Inverse trigonometric functions tests

        [Test, TestCaseSource(
           typeof(RealDomainCasesFactory),
           nameof(GetRealAxisExceptClosedFromMinusToPlusOne))]
        public void ArcsinTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Asin(value));

            Assert.That((DecimalMathReal.Arcsin(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Arcsin() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }



        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxisExceptClosedFromMinusToPlusOne))]
        public void ArccosTests(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Acos(value));

            Assert.That((DecimalMathReal.Arccos(target) - cmpVal).Abs(), Is.LessThan(0.0000001M));
            Assert.That((target.Arccos() - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }


        [Test, TestCaseSource(typeof(RealDomainCasesFactory), nameof(GetRealAxis))]
        public void ArctanTest(decimal value)
            => Assert.That(
                Abs(Arctan(value) - (decimal)Math.Atan((double)value)),
                Is.LessThan(0.000001M)
            );


        [Test, TestCaseSource(typeof(RealDomainCasesFactory), nameof(GetRealAxis))]
        public void ArccotTest(double value)
        {
            var target = Convert.ToDecimal(value);
            var cmpVal = Convert.ToDecimal(Math.Atan(1.0 / value));

            Assert.That((DecimalMathReal.Arccot(target) - cmpVal).Abs(), Is.LessThan(0.000001M));
            Assert.That((target.Arccot() - cmpVal).Abs(), Is.LessThan(0.000001M));
        }

        #endregion

    }
}
