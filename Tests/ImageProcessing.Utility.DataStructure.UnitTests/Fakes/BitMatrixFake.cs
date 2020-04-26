using System.Collections;

using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.Utility.DataStructure.UnitTests.Fakes
{
    internal sealed class BitMatrixFake
    {
        private readonly BitMatrix _matrix;

        public BitMatrixFake(int row, int column)
            => _matrix = new BitMatrix((row, column));

        public int RowCount
            => _matrix.RowCount;

        public int ColumnCount
            => _matrix.ColumnCount;

        public bool this[int rowIndex, int columnIndex]
        {
            get => _matrix[rowIndex, columnIndex];
            set => _matrix[rowIndex, columnIndex] = value;
        }

        public IEnumerable Traverse()
        {
            var iterator = _matrix.GetEnumerator();

            while(iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
    }
}
