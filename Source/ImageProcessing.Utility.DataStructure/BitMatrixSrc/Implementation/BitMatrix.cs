using System;
using System.Collections;
using System.Collections.Generic;

using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Interface;

namespace ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation
{
    /// <inheritdoc cref="IBitMatrix"/>
    public sealed class BitMatrix : IBitMatrix
    {
        private readonly byte[] _data;

        public BitMatrix(int width, int height)
        {
            if(width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }

            RowCount    = width;
            ColumnCount = height;

            var bitCount  = width * height;
            var byteCount = bitCount >> 3;

            if ((bitCount & 7) != 0)
            {
                ++byteCount;
            }
      
            _data = new byte[byteCount];
        }

        public BitMatrix(IBitMatrix matrix)
          : this(matrix.RowCount, matrix.ColumnCount)
        {
            for (var row = 0; row < RowCount; ++row)
            {
                for (var column = 0; column < ColumnCount; ++column)
                {
                    this[row, column] = matrix[row, column];
                }
            }
        }

        public BitMatrix(bool[,] matrix)
          : this(matrix.GetLength(0), matrix.GetLength(1))
        {
            for (var row = 0; row < RowCount; ++row)
            {
                for (var column = 0; column < ColumnCount; ++column)
                {
                    this[row, column] = matrix[row, column];
                }
            }
        }

        /// <inheritdoc />
        public int RowCount { get; }

        /// <inheritdoc />
        public int ColumnCount { get; }

        /// <inheritdoc />
        public bool this[int rowIndex, int columnIndex]
        {
            get
            {
                if (rowIndex < 0 || rowIndex >= RowCount)
                {
                    throw new ArgumentOutOfRangeException(nameof(rowIndex));
                }

                if (columnIndex < 0 || columnIndex >= ColumnCount)
                {
                    throw new ArgumentOutOfRangeException(nameof(columnIndex));
                }

                var pos = rowIndex * ColumnCount + columnIndex;
                var index = pos & 7;

                pos >>= 3;

                return (_data[pos] & (1 << index)) != 0;

            }

            set
            {
                if (rowIndex < 0 || rowIndex >= RowCount)
                {
                    throw new ArgumentOutOfRangeException(nameof(rowIndex));
                }

                if (columnIndex < 0 || columnIndex >= ColumnCount)
                {
                    throw new ArgumentOutOfRangeException(nameof(columnIndex));
                }

                var pos = rowIndex * ColumnCount + columnIndex;
                var index = pos & 7;

                pos >>= 3;

                _data[pos] &= (byte)(~(1 << index));

                if (value)
                {
                    _data[pos] |= (byte)(1 << index);
                }
            }
        }

        public IEnumerator<bool> GetEnumerator()
        {
            for(var row = 0; row < RowCount; ++row)
            {
                for(var column = 0; column < ColumnCount; ++column)
                {
                    yield return this[row, column];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public bool[,] To2DArray()
        {
            var result = new bool[RowCount, ColumnCount];

            for(var row = 0; row < RowCount; ++row)
            {
                for(var column = 0; column < ColumnCount; ++column)
                {
                    result[row, column] = this[row, column];
                }
            }

            return result;
        }
    }
}
