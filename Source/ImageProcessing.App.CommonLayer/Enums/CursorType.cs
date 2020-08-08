using System.ComponentModel;

namespace ImageProcessing.App.CommonLayer.Enums
{
    /// <summary>
    /// Specifies the built in cursor types.
    /// </summary>
    public enum CursorType
    {
        /// <summary>
        /// An unknown cursor.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Cursor by default.
        /// </summary>
        Default = 1,

        /// <summary>
        /// Wait cursor.
        /// </summary>
        Wait    = 2,

        /// <summary>
        /// Arrow cursor.
        /// </summary>
        Arrow   = 3,

        /// <summary>
        /// Cross cursor.
        /// </summary>
        Cross   = 4,

        /// <summary>
        /// Help cursor.
        /// </summary>
        Help    = 5,
    }
}
