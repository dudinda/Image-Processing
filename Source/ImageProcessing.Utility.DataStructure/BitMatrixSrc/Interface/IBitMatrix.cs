using System;
using System.Collections;
using System.Collections.Generic;

namespace ImageProcessing.Utility.DataStructure.BitMatrixSrc.Interface
{
    /// <summary>
    /// Specifies a memory efficient 2D array
    /// where a boolean value uses 1 bit.
    /// </summary>
    public interface IBitMatrix : IEnumerable, IEnumerable<bool>, ICloneable
    {
        /// <summary>
        /// The number of rows.
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// The number of columns.
        /// </summary>
        int ColumnCount { get; }

        /// <summary>
        /// Get or set the value at the specified position.
        /// </summary>
        bool this[int rowIndex, int columnIndex] { get; set; }

        /// <summary>
        /// Convert a bit matrix to a 2D boolean array.  
        /// </summary>
        /// <returns></returns>
        bool[,] To2DArray();
    }
}
