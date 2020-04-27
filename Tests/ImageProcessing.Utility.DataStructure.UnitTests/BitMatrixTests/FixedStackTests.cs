using ImageProcessing.Utility.DataStructure.UnitTests.Fakes;

using NUnit.Framework;

using static ImageProcessing.Utility.DataStructure.UnitTests.StubFactory.FixedStackStubFactory;

namespace ImageProcessing.Utility.DataStructure.UnitTests.BitMatrixTests
{
    [TestFixture]
    public class FixedStackTests
    {
        private FixedStackFake<int> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new FixedStackFake<int>(10);

            /// --> (head) 0-1-...-9 (tail)

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
    }
}
