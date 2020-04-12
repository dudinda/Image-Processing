namespace ImageProcessing.App.Common.Utility.BitMatrix.Interface
{
    /// <summary>
    /// Specifies a memory efficient 2D array
    /// where a boolean value uses 1 bit.
    /// </summary>
    public interface IBitMatrix
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
    }
}
