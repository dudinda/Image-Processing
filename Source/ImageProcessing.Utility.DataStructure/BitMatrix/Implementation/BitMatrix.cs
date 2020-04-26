using System;
using System.Collections;
using System.Collections.Generic;
using ImageProcessing.Utility.DataStructure.BitMatrix.Interface;

namespace ImageProcessing.Utility.DataStructure.BitMatrix.Implementation
{
    /// <inheritdoc cref="IBitMatrix"/>
    public sealed class BitMatrix : IBitMatrix
    {
        private readonly byte[] _data;

        public BitMatrix((int width, int height) size)
        {
            RowCount    = size.width;
            ColumnCount = size.height;

            var bitCount  = size.width * size.height;
            var byteCount = bitCount >> 3;

            if (bitCount % 8 != 0)
            {
                ++byteCount;
            }

            _data = new byte[byteCount];
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
                var index = pos % 8;

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
                var index = pos % 8;

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
    }
}
