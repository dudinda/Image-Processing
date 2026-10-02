using System;
using System.Collections;
using System.Collections.Generic;

namespace ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation
{
    public sealed class ReadOnly2DArray<T> : IReadOnlyCollection<T>
    {
        private readonly T[,] _array;

        /// <inheritdoc />
        public int RowCount { get; }

        /// <inheritdoc />
        public int ColumnCount { get; }

        public ReadOnly2DArray(T[,] source)
        {
            RowCount    = source.GetLength(0);
            ColumnCount = source.GetLength(1);

            _array = new T[RowCount, ColumnCount];

            for (var row = 0; row < RowCount; ++row)
            {
                for(var column = 0; column < ColumnCount; ++column)
                {
                    _array[row, column] = source[row, column];
                }
            }          
        }

        public T this[int rowIndex, int columnIndex]
        {
            get => _array[rowIndex, columnIndex];
        }

        public int Count => RowCount * ColumnCount;

        public IEnumerator<T> GetEnumerator()
        {
            for (var row = 0; row < RowCount; ++row)
            {
                for (var column = 0; column < ColumnCount; ++column)
                {
                    yield return this[row, column];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();    
    }
}
