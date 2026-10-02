using System;

using ImageProcessing.Utility.DataStructure.UnitTests.CaseFactory;
using ImageProcessing.Utility.DataStructure.UnitTests.Fakes;

using NUnit.Framework;

using static ImageProcessing.Utility.DataStructure.UnitTests.CaseFactory.BitMatrixCaseFactory;

namespace ImageProcessing.Utility.DataStructure.UnitTests.Tests
{
    [TestFixture]
    public class BitMatrixTests
    {
        private BitMatrixFake _matrix;

        [SetUp]
        public void SetUp()
        {
            _matrix = new BitMatrixFake(RowSize, ColumnSize);

            for (var row = 0; row < _matrix.RowCount; ++row)                 //10101
            {                                                                //01010
                for (var column = 0; column < _matrix.ColumnCount; ++column) //10101
                {                                                            //01010
                    _matrix[row, column] = (row + column) % 2 == 0;          //10101
                }
            }
        }

        [Test]
        public void BitMatrixTraverseOrderTest()
           => CollectionAssert.AreEqual(
               _matrix.Traverse(),
               GetTraverseByColumnThenByRowCases
           );

        [Test]
        public void DstMatrixIsIdenticalToSrcBooleanMatrixTest()
        {
            var dst = new BitMatrixFake(_matrix.To2DArray());

            CollectionAssert.AreEqual(
              _matrix.Traverse(),
              dst.Traverse()
          );
        }

        [Test]
        public void DstMatrixIsIdenticalToSrcMatrixTest()
        {
            var dst = new BitMatrixFake(_matrix);

            CollectionAssert.AreEqual(
              _matrix.Traverse(),
              dst.Traverse()
          );
        }

        [Test]
        public void SrcMatrixCloneIsIdenticalToSrcMatrixTest()
        {
            var dst = (BitMatrixFake)new BitMatrixFake(_matrix).Clone();

            CollectionAssert.AreEqual(
              _matrix.Traverse(),
              dst.Traverse()
          );
        }

        [Test]
        public void BitMatrixTraverse2DArrayOrderTest()
          => CollectionAssert.AreEqual(
              _matrix.Traverse2DArray(),
              GetTraverseByColumnThenByRowCases
          );
    
        [Test, TestCaseSource(
            typeof(BitMatrixCaseFactory),
            nameof(GetInvalidIndices))]
        public void BitMatrixThrowsOnInvalidIndices((int width, int height) size)
            => Assert.Throws<ArgumentOutOfRangeException>(
                () => _matrix.TryGet(size.width, size.height)
            );     
    }
}
