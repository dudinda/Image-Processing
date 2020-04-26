using System;
using System.Collections;
using System.Collections.Generic;
using ImageProcessing.Utility.DataStructure.BitMatrix.Interface;

namespace ImageProcessing.Utility.DataStructure.BitMatrix.Implementation.Safe
{
    /// <inheritdoc cref="IBitMatrix"/>
    public sealed class BitMatrixSafe : IBitMatrix
    {
        private readonly object _sync = new object();

        private readonly byte[] _data;

        public BitMatrixSafe((int width, int height) size)
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

                var pos   = rowIndex * ColumnCount + columnIndex;
                var index = pos % 8;

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
                var index = pos % 8;

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

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<bool> IEnumerable<bool>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
