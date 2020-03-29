using NUnit.Framework;

using static ImageProcessing.DecimalMath.Complex.DecimalMathComplex;

namespace ImageProcessing.Tests.DecimalMath.Complex
{
    [TestFixture]
    public class DecimalMathComplexTests
    {
        [Test]
        public void ComplexNumberMultiplicationTest()
        {
            var z1 = (0.25M, 3M);
            var z2 = (0.25M, -3M);

            var z = Mul(z1, z2);

            Assert.AreEqual(Re(z), 9.0625);
            Assert.AreEqual(Im(z), 0);
        }

        [Test]
        public void ComplexNumberDivisionTest()
        {
            var z1 = (0.25M, 3M);
            var z2 = (0.25M, -3M);

            var z = Div(z1, z2);

            Assert.AreEqual(Re(z), 0.9862069 < 0.00001);
            Assert.AreEqual(Im(z), 0.1655172);
        }

        [Test]
        public void ComplexNumberAdditionTest()
        {
            var z1 = (0.25M, 3M);
            var z2 = (0.25M, -3M);

            var z = Div(z1, z2);

            Assert.AreEqual(Re(z), 0.5);
            Assert.AreEqual(Im(z), 0);
        }

        [Test]
        public void ComplexNumberSubtractionTest()
        {
            var z1 = (0.25M, 3M);
            var z2 = (0.25M, -3M);

            var z = Sub(z1, z2);

            Assert.AreEqual(Re(z), 0);
            Assert.AreEqual(Im(z), 6);
        }

    }
}
