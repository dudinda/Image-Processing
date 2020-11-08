using System.Collections;
using System.Collections.Generic;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Interface;

namespace ImageProcessing.Utility.DataStructure.UnitTests.Fakes
{
    internal sealed class BitMatrixFake : IBitMatrix
    {
        public  BitMatrix Matrix { get; }

        public int RowCount
            => Matrix.RowCount;

        public int ColumnCount
            => Matrix.ColumnCount;

        public BitMatrixFake(int row, int column)
            => Matrix = new BitMatrix(row, column);

        public BitMatrixFake(BitMatrixFake matrix)
            => Matrix = new BitMatrix(matrix.Matrix);

        public BitMatrixFake(bool[,] matrix)
            => Matrix = new BitMatrix(matrix);

        public BitMatrixFake(BitMatrix matrix)
            => Matrix = matrix;

        public bool[,] To2DArray()
            => Matrix.To2DArray();

        public object Clone()
            => new BitMatrixFake((BitMatrix)Matrix.Clone());

        public bool this[int rowIndex, int columnIndex]
        {
            get => Matrix[rowIndex, columnIndex];
            set => Matrix[rowIndex, columnIndex] = value;
        }

        public bool TryGet(int rowIndex, int columnIndex)
            => Matrix[rowIndex, columnIndex];

        public IEnumerable Traverse2DArray()
        {
            var array = Matrix.To2DArray();

            for(var row = 0; row < Matrix.RowCount; ++row)
            {
                for(var column = 0; column < Matrix.ColumnCount; ++column)
                {
                    yield return array[row, column];
                }
            }
        }

        public IEnumerable Traverse()
        {
            using (var iterator = Matrix.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        public IEnumerator<bool> GetEnumerator()
            => Matrix.GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
