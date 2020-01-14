using ImageProcessing.Common.Extensions.DecimalMathExtensions;

using NUnit.Framework;

namespace ImageProcessing.Tests.Utility
{
    [TestFixture]
    public class DecimalMathTests
    {
        [Test]
        [TestCase(-2.63)]
        public void FloorFunctionNegativeTest(decimal value)
        {
            Assert.AreEqual(value.Floor(), -3);
        }

        [Test]
        [TestCase(2.63)]
        public void FloorFunctionPositiveTest(decimal value)
        {
            Assert.AreEqual(value.Floor(), 2);
        }

        [Test]
        [TestCase(2, -2, 1005, 0, -1524)]
        public void FloorFunctionIdentityTest(decimal value)
        {
            Assert.AreEqual(value.Floor(), value);
        }

        [Test]
        [TestCase(-2.63)]
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
        [TestCase(2, -2, 1005, 0, -1524)]
        public void CeilFunctionIdentityTest(decimal value)
        {
            Assert.AreEqual(value.Ceil(), value);
        }
    }
}
