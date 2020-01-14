using System;
using ImageProcessing.Common.Extensions.DecimalMathExtensions;
using ImageProcessing.Common.Utility.DecimalMath;
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
        [TestCase(2)]
        [TestCase(-2)]
        [TestCase(1005)]
        [TestCase(0)]
        [TestCase(-1524)]
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
        public void ExponentTest()
        {
            Assert.That((2.0M.Exp() - DecimalMath.E * DecimalMath.E).Abs(), Is.LessThan(0.0000001M));
        }

        [Test]
        public void CosineTableValuesTest()
        {
            var pi = DecimalMath.PI;

            Assert.That((DecimalMath.Cos(3 * pi / 2.0M) - 0.0M).Abs(), Is.LessThan(0.0000001M));
            Assert.That((DecimalMath.Cos(pi / 2.0M) - 0.0M).Abs(), Is.LessThan(0.0000001M));
            Assert.That((DecimalMath.Cos(pi / 3.0M) - 0.5M).Abs(), Is.LessThan(0.0000001M));
            Assert.That((DecimalMath.Cos(pi / 4.0M) - 2.0M.Sqrt() / 2.0M).Abs(), Is.LessThan(0.0000001M));
            Assert.That((DecimalMath.Cos(pi / 6.0M) - 3.0M.Sqrt() / 2.0M).Abs(), Is.LessThan(0.0000001M));
        }

        [Test]
        public void SineTableValuesTest()
        {
            var pi = DecimalMath.PI;

            Assert.That((DecimalMath.Sin(pi) - 0.0M).Abs(), Is.LessThan(0.0000001M));
            Assert.That((DecimalMath.Sin(pi / 2.0M) - 1.0M).Abs(), Is.LessThan(0.0000001M));
            Assert.That((DecimalMath.Sin(3 *  pi / 2.0M) + 1.0M).Abs(), Is.LessThan(0.0000001M));
            Assert.That((DecimalMath.Sin(pi / 3.0M) - 0.5M).Abs(), Is.LessThan(0.0000001M));
            Assert.That((DecimalMath.Sin(pi / 4.0M) - 2.0M.Sqrt() / 2.0M).Abs(), Is.LessThan(0.0000001M));
            Assert.That((DecimalMath.Sin(pi / 6.0M) - 3.0M.Sqrt() / 2.0M).Abs(), Is.LessThan(0.0000001M));
        }
    }
}
