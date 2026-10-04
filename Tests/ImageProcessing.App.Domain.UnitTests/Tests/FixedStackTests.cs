using System;

using ImageProcessing.Utility.DataStructure.UnitTests.CaseFactory;
using ImageProcessing.Utility.DataStructure.UnitTests.Fakes;

using NUnit.Framework;

using static ImageProcessing.Utility.DataStructure.UnitTests.CaseFactory.FixedStackCaseFactory;

namespace ImageProcessing.Utility.DataStructure.UnitTests.Tests
{
    [TestFixture]
    public class FixedStackTests
    {
        private FixedStackFake<int> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new FixedStackFake<int>(StackSize);

            /// --> (top) 0-1-...-9 (bottom)

            for(var value = 9; value >= 0; --value)
            {
                _stack.Push(value);
            }
        }

        [Test]
        public void StackTraverseOrderTest()
           => CollectionAssert.AreEqual(
               _stack.Traverse(),
               GetStackValues
           );

        [Test, TestCaseSource(
            typeof(FixedStackCaseFactory),
            nameof(GetInvalidCapacity))]
        public void BitMatrixThrowsOnInvalidIndices(int capacity)
            => Assert.Throws<ArgumentOutOfRangeException>(
                () => new FixedStackFake<int>(capacity)
            );
    }
}
