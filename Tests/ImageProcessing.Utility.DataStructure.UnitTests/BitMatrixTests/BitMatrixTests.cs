using ImageProcessing.Utility.DataStructure.UnitTests.Fakes;

using NUnit.Framework;

using static ImageProcessing.Utility.DataStructure.UnitTests.CaseFactory.BitMatrixCaseFactory;

namespace ImageProcessing.Utility.DataStructure.UnitTests.CollectionTests
{
    [TestFixture]
    public class BitMatrixTests
    {
        private  BitMatrixFake _matrix;

        [SetUp]
        public void SetUp()
        {
            _matrix  = new BitMatrixFake(5, 5);

            for(var row = 0; row < _matrix.RowCount; ++row)                 //10101
            {                                                               //01010
                for(var column = 0; column < _matrix.ColumnCount; ++column) //10101
                {                                                           //01010
                    _matrix[row, column] = (row + column) % 2 == 1;         //10101
                }
            }
        }

        [Test]
        public void CeilFunctionTest()
           => CollectionAssert.AreEqual(
               _matrix.Traverse(),
               GetTraverseByColumnTheByRowCases
           );
    }
}
