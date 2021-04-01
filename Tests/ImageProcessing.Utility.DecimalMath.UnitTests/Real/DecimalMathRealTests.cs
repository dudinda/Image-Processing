using System;

using ImageProcessing.Utility.DecimalMath.Real;
using ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory;

using NUnit.Framework;

using static ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory.RealDomainCasesFactory;
using static ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory.RealFunctionCasesFactory;

namespace ImageProcessing.Tests.Utility
{
    [TestFixture]
    public class DecimalMathRealTests
    {
        private readonly DecimalReal _real = new DecimalReal();

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void FloorFunctionTest(decimal value)
            => Assert.AreEqual(_real.Floor(value), Math.Floor(value));

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void CeilFunctionTest(decimal value)
            => Assert.AreEqual(_real.Ceil(value), Math.Ceiling(value));

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow))]
        public void ExponentTest(decimal value)
            => Assert.That(
                _real.Abs(_real.Exp(value) - (decimal)Math.Exp((double)value)),
                Is.LessThan(0.0000001M)
            );
        
        [Test, TestCaseSource(
          typeof(RealFunctionCasesFactory),
           nameof(GetModValuesAndResult))]
        public void ModuloTest((decimal x, decimal mod, decimal result) src)
            => Assert.AreEqual(_real.Mod(src.x, src.mod), src.result);

        [Test, TestCaseSource(
             typeof(RealDomainCasesFactory),
              nameof(GetPositiveRealAxis))]
        public void LnTests(decimal value)
        {
            var cmpVal  = Convert.ToDecimal(Math.Log((double)value));

            Assert.That(_real.Abs(_real.Log(value) - cmpVal), Is.LessThan(0.00000001M));
        }

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void SignTest(decimal value)
            => Assert.That(
                _real.Sign(value),
                Is.EqualTo(Math.Sign(value))
            );

        #region Trigonometric functions tests

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetTrigonometryPoints))]
        public void CosineTableValuesTest(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Cos((double)value));

            Assert.That(_real.Abs(_real.Cos(value) - cmpVal), Is.LessThan(0.00001M));
        }

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void CosineTest(decimal value)
            => Assert.That(
                _real.Abs(_real.Cos(value) - (decimal)Math.Cos((double)value)),
                Is.LessThan(0.00001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetTrigonometryPoints))]
        public void SineTableValuesTest(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Sin((double)value));

            Assert.That(_real.Abs(_real.Sin(value) - cmpVal), Is.LessThan(0.00001M));
        }

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetRealAxis))]
        public void SineTest(decimal value)
            => Assert.That(
                _real.Abs(_real.Sin(value) - (decimal)Math.Sin((double)value)),
                Is.LessThan(0.0000001M)
            );

        [Test, TestCaseSource(
            typeof(RealFunctionCasesFactory),
            nameof(GetTanTableValues))]
        public void TangentTableValuesTest(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Tan((double)value));

            Assert.That(_real.Abs(_real.Tan(value) - cmpVal), Is.LessThan(0.0000001M));
        }

        [Test, TestCaseSource(
            typeof(RealFunctionCasesFactory),
            nameof(GetTanRealAxisValues))]
        public void TangentTest(decimal value)
            => Assert.That(
                _real.Abs(_real.Tan(value) - (decimal)Math.Tan((double)value)),
                Is.LessThan(0.0000001M)
            );

        [Test, TestCaseSource(
            typeof(RealFunctionCasesFactory),
            nameof(GetCotTableValues))]
        public void CotangentTableValuesTest(decimal value)
            => Assert.That(
                _real.Abs(_real.Cot(value) - Convert.ToDecimal(1.0 / Math.Tan((double)value))),
                Is.LessThan(0.0000001M)
            );

        [Test, TestCaseSource(
            typeof(RealFunctionCasesFactory),
            nameof(GetCotRealAxisValues))]
        public void CotangentTest(decimal value)
            => Assert.That(
                _real.Abs(_real.Cot(value) - (decimal)(Math.Cos((double)value) / Math.Sin((double)value))),
                Is.LessThan(0.0000001M)
            );

        #endregion

        #region Hyperbolic functions tests

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow))]
        public void SinhTests(decimal value)
            => Assert.That(
                _real.Abs(_real.Sinh(value) - (decimal)Math.Sinh((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow))]
        public void CoshTests(decimal value)
            => Assert.That(
                _real.Abs(_real.Cosh(value) - (decimal)Math.Cosh((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow))]
        public void TanhTests(decimal value)
            => Assert.That(
                _real.Abs(_real.Tanh(value) - (decimal)Math.Tanh((double)value)),
                Is.LessThan(0.00000001M)
            );

        [Test, TestCaseSource(
            typeof(RealFunctionCasesFactory),
            nameof(GetCothRealAxisValues))]
        public void CothTests(decimal value)
            => Assert.That(
                _real.Abs(_real.Coth(value) - (decimal)(1.0 / Math.Tanh((double)value))),
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

            Assert.That(_real.Abs(_real.Arsinh(val) - cmpVal), Is.LessThan(0.000001M));
        }
        
        [Test, TestCaseSource(
           typeof(RealDomainCasesFactory),
           nameof(HalfOpenIntervalFromOneToPlusInf))]
        public void ArcoshTests(decimal val)
        {
            var value = (double)val;

            var cmpVal = Convert.ToDecimal(Math.Log(value + Math.Sqrt(value * value - 1)));

            Assert.That(_real.Abs(_real.Arcosh(val) - cmpVal), Is.LessThan(0.00001M));
        }

        [Test, TestCaseSource(
           typeof(RealDomainCasesFactory),
           nameof(GetOpenIntervalFromMinusOneToOne))]
        public void ArtanhTests(decimal val)
        {
            var value = (double)val;

            var cmpVal = Convert.ToDecimal(0.5 * Math.Log((1.0 + value) / (1.0 - value)));

            Assert.That(_real.Abs(_real.Artanh(val) - cmpVal), Is.LessThan(0.0001M));
        }

        [Test, TestCaseSource(
          typeof(RealDomainCasesFactory),
          nameof(GetRealAxisExceptClosedFromMinusToPlusOne))]
        public void ArcothTests(decimal val)
        {
            var value = (double)val;
            var cmpVal = Convert.ToDecimal(0.5 * Math.Log((value + 1.0) / (value - 1.0)));

            Assert.That(_real.Abs(_real.Arcoth(val) - cmpVal), Is.LessThan(0.000001M));
        }

        #endregion

        #region Inverse trigonometric functions tests

        [Test, TestCaseSource(
           typeof(RealDomainCasesFactory),
           nameof(GetOpenIntervalFromMinusOneToOne))]
        public void ArcsinTests(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Asin((double)value));

            Assert.That(_real.Abs(_real.Arcsin(value) - cmpVal), Is.LessThan(0.0000001M));
        }

        [Test, TestCaseSource(
            typeof(RealDomainCasesFactory),
            nameof(GetOpenIntervalFromMinusOneToOne))]
        public void ArccosTests(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Acos((double)value));

            Assert.That(_real.Abs(_real.Arccos(value) - cmpVal), Is.LessThan(0.0000001M));
        }


        [Test, TestCaseSource(typeof(RealDomainCasesFactory), nameof(GetRealAxis))]
        public void ArctanTest(decimal value)
            => Assert.That(
                _real.Abs(_real.Arctan(value) - (decimal)Math.Atan((double)value)),
                Is.LessThan(0.000001M)
            );


        [Test, TestCaseSource(
            typeof(RealFunctionCasesFactory),
            nameof(GetArccotValues))]
        public void ArccotTest(decimal value)
        {
            var cmpVal = Convert.ToDecimal(Math.Atan(1.0 / (double)value));

            Assert.That(_real.Abs(_real.Arccot(value) - cmpVal), Is.LessThan(0.000001M));
        }

        #endregion

    }
}
