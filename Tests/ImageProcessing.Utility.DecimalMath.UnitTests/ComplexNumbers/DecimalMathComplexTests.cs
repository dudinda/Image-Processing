
using ImageProcessing.Utility.DecimalMath.Complex;
using ImageProcessing.Utility.DecimalMath.Real;
using ImageProcessing.Utility.DecimalMath.UnitTests.CasesFactory;

using NUnit.Framework;

using static ImageProcessing.Utility.DecimalMath.Real.DecimalReal;
using static ImageProcessing.Utility.DecimalMath.UnitTests.CasesFactory.ComplexDomainCasesFactory;

using ComplexNumber = System.Numerics.Complex;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.ComplexNumbers
{
    [TestFixture]
    public class DecimalMathComplexTests
    {
        private readonly DecimalComplex _complex = new DecimalComplex();
        private readonly DecimalReal _real = new DecimalReal();

        [Test, TestCaseSource(
             typeof(ComplexDomainCasesFactory),
             nameof(GetComplexNumbers))]
        public void RealPartTest((decimal re, decimal im) z)
        {
            Assert.AreEqual(_complex.Re(z), z.re);
        }

        [Test, TestCaseSource(
                 typeof(ComplexDomainCasesFactory),
                 nameof(GetComplexNumbers))]
        public void ImaginaryPartTest((decimal re, decimal im) z)
        {
            Assert.AreEqual(_complex.Im(z), z.im);
        }

        [Test, TestCaseSource(
                 typeof(ComplexDomainCasesFactory),
                 nameof(GetComplexNumbers))]
        public void SubtractionTest((decimal re, decimal im) z)
        {
            var z1 = (25M, 30M);

            var w1 = new ComplexNumber((double)z.re, (double)z.im);
            var w2 = new ComplexNumber(25, 30);

            var w = w2 - w1;

            var result = _complex.Sub(z1, z);

            Assert.That(() => _real.Abs(((decimal)w.Real - result.Re)) < Epsilon);
            Assert.That(() => _real.Abs(((decimal)w.Imaginary - result.Im)) < Epsilon);
        }
        [Test, TestCaseSource(
                     typeof(ComplexDomainCasesFactory),
                     nameof(GetComplexNumbers))]
        public void AdditionTest((decimal re, decimal im) z)
        {
            var z1 = (25M, 30M);

            var w1 = new ComplexNumber((double)z.re, (double)z.im);
            var w2 = new ComplexNumber(25, 30);

            var w = w2 + w1;

            var result = _complex.Add(z1, z);

            Assert.That(() => _real.Abs(((decimal)w.Real - result.Re)) < Epsilon);
            Assert.That(() => _real.Abs(((decimal)w.Imaginary - result.Im)) < Epsilon);
        }

        [Test, TestCaseSource(
                   typeof(ComplexDomainCasesFactory),
                   nameof(GetComplexNumbers))]
        public void MultiplicationTest((decimal re, decimal im) z)
        {
            var z1 = (25M, 30M);

            var w1 = new ComplexNumber((double)z.re, (double)z.im);
            var w2 = new ComplexNumber(25, 30);

            var w = w2 * w1;

            var result = _complex.Mul(z1, z);

            Assert.That(() => _real.Abs(((decimal)w.Real - result.Re)) < 1.0E-9M);
            Assert.That(() => _real.Abs(((decimal)w.Imaginary - result.Im)) < 1.0E-9M);
        }

        [Test, TestCaseSource(
                     typeof(ComplexDomainCasesFactory),
                     nameof(GetComplexNumbers))]
        public void DivisionTest((decimal re, decimal im) z)
        {
            var z1 = (25M, 30M);

            var w1 = new ComplexNumber((double)z.re, (double)z.im);
            var w2 = new ComplexNumber(25, 30);

            var w = w1 / w2;

            var result = _complex.Div(z, z1);

            Assert.That(() => _real.Abs(((decimal)w.Real - result.Re)) < 1.0E-11M);
            Assert.That(() => _real.Abs(((decimal)w.Imaginary - result.Im)) < 1.0E-11M);
        }
    }
}
