using System;
using System.Collections;
using System.Collections.Generic;

using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Interface;

namespace ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation.Safe
{
    /// <inheritdoc cref="IBitMatrix"/>
    public sealed class BitMatrixSafe : IBitMatrix
    {
        private readonly object _sync = new object();

        private readonly byte[] _data;

        public BitMatrixSafe((int width, int height) size)
        {
            if (size.width <= 0)
            {
                throw new ArgumentException(nameof(size.width));
            }

            if (size.height <= 0)
            {
                throw new ArgumentException(nameof(size.height));
            }

            RowCount    = size.width;
            ColumnCount = size.height;

            var bitCount  = size.width * size.height;
            var byteCount = bitCount >> 3;

            if ((bitCount & 7) != 0)
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

                var pos   = rowIndex * ColumnCount + columnIndex;
                var index = pos & 7;

                pos >>= 3;

                lock (_sync)
                {
                    return (_data[pos] & (1 << index)) != 0;
                }
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

                lock (_sync)
                {
                    _data[pos] &= (byte)(~(1 << index));

                    if (value)
                    {
                        _data[pos] |= (byte)(1 << index);
                    }
                }
            }
        }

        public IEnumerator<bool> GetEnumerator()
        {
            lock (_sync)
            {
                for (var row = 0; row < RowCount; ++row)
                {
                    for (var column = 0; column < ColumnCount; ++column)
                    {
                        yield return this[row, column];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public bool[,] To2DArray()
        {
            var result = new bool[RowCount, ColumnCount];

            lock (_sync)
            {
                for (var row = 0; row < RowCount; ++row)
                {
                    for (var column = 0; column < ColumnCount; ++column)
                    {
                        result[row, column] = this[row, column];
                    }
                }
            }

            return result;
        }
    }
}
