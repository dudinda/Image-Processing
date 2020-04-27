using System.Collections;

using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.Utility.DataStructure.UnitTests.Fakes
{
    internal sealed class BitMatrixFake
    {
        private readonly BitMatrix _matrix;

        public BitMatrixFake(int row, int column)
            => _matrix = new BitMatrix(row, column);

        public int RowCount
            => _matrix.RowCount;

        public int ColumnCount
            => _matrix.ColumnCount;

        public bool this[int rowIndex, int columnIndex]
        {
            get => _matrix[rowIndex, columnIndex];
            set => _matrix[rowIndex, columnIndex] = value;
        }

        public bool TryGet(int rowIndex, int columnIndex)
            => _matrix[rowIndex, columnIndex];

        public IEnumerable Traverse2DArray()
        {
            var array = _matrix.To2DArray();

            for(var row = 0; row < _matrix.RowCount; ++row)
            {
                for(var column = 0; column < _matrix.ColumnCount; ++column)
                {
                    yield return array[row, column];
                }
            }

        }

        public IEnumerable Traverse()
        {
            using (var iterator = _matrix.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }
    }
}
