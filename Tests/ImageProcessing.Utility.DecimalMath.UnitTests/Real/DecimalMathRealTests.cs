using System;

using ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.RealAxis;
using ImageProcessing.Utility.DecimalMath.RealAxis;
using ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory;

using NUnit.Framework;

using static ImageProcessing.Utility.DecimalMath.RealAxis.DecimalMathReal;
using static ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory.RealDomainCasesFactory;
using static ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory.RealFunctionCasesFactory;

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
            nameof(GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow))]
        public void ExponentTest(decimal value)
            => Assert.That(
                Abs(Exp(value) - (decimal)Math.Exp((double)value)),
                Is.LessThan(0.0000001M)
            );

        [Test, TestCaseSource(
          typeof(RealFunctionCasesFactory),
           nameof(GetModValuesAndResult))]
        public void ModuloTest((decimal x, decimal mod, decimal result) src)
            => Assert.AreEqual(Mod(src.x, src.mod), src.result);

        [Test, TestCaseSource(
             typeof(RealDomainCasesFactory),
              nameof(GetPositiveRealAxis))]
        public void LnTests(decimal value)
        {
            var cmpVal  = Convert.ToDecimal(Math.Log((double)value));

            Assert.That((Log(value) - cmpVal).Abs(), Is.LessThan(0.00000001M));
        }

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
             nameof(GetNonNegativeRealAxis))]
        public void SqrtTests(decimal value)
            => Assert.That(
                Abs(Sqrt(value) - (decimal)Math.Sqrt((double)value)),
                Is.LessThan(0.00001M)
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
        public void CosineTableValuesTest(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Cos((double)value));

            Assert.That((Cos(value) - cmpVal).Abs(), Is.LessThan(0.00001M));
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
        public void SineTableValuesTest(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Sin((double)value));

            Assert.That((Sin(value) - cmpVal).Abs(), Is.LessThan(0.00001M));
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
        public void TangentTableValuesTest(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Tan((double)value));

            Assert.That(Abs(Tan(value) - cmpVal), Is.LessThan(0.0000001M));
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
        public void CotangentTableValuesTest(decimal value)
            => Assert.That(
                Abs(Cot(value) - Convert.ToDecimal(1.0 / Math.Tan((double)value))),
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
            nameof(GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow))]
        public void SinhTests(decimal value)
            => Assert.That(
                Abs(Sinh(value) - (decimal)Math.Sinh((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow))]
        public void CoshTests(decimal value)
            => Assert.That(
                Abs(Cosh(value) - (decimal)Math.Cosh((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow))]
        public void TanhTests(decimal value)
            => Assert.That(
                Abs(Tanh(value) - (decimal)Math.Tanh((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow))]
        public void CothTests(decimal value)
        {
            if (value != 0)
            {
                Assert.That(
                Abs(Coth(value) - (decimal)(1.0 / Math.Tanh((double)value))),
                Is.LessThan(0.000001M));
            }
        }
        
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

            Assert.That((Arcosh(val) - cmpVal).Abs(), Is.LessThan(0.00001M));
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
           nameof(GetOpenIntervalFromMinusOneToOne))]
        public void ArcsinTests(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Asin((double)value));

            Assert.That((Arcsin(value) - cmpVal).Abs(), Is.LessThan(0.0000001M));
        }

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetOpenIntervalFromMinusOneToOne))]
        public void ArccosTests(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Acos((double)value));

            Assert.That(Abs(Arccos(value) - cmpVal), Is.LessThan(0.0000001M));
        }


        [Test, TestCaseSource(typeof(RealDomainCasesFactory), nameof(GetRealAxis))]
        public void ArctanTest(decimal value)
            => Assert.That(
                Abs(Arctan(value) - (decimal)Math.Atan((double)value)),
                Is.LessThan(0.000001M)
            );


        [Test, TestCaseSource(
            typeof(RealFunctionCasesFactory),
            nameof(GetArccotValues))]
        public void ArccotTest(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Atan(1.0 / (double)value));

            Assert.That(Abs(Arccot(value) - cmpVal), Is.LessThan(0.000001M));
        }

        #endregion

    }
}
