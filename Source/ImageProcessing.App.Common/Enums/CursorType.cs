using System.ComponentModel;

namespace ImageProcessing.App.Common.Enums
{
    /// <summary>
    /// Specifies the built in cursor types.
    /// </summary>
    public enum CursorType
    {
        /// <summary>
        /// An unknown cursor.
        /// </summary>
        [Description("Cursor is not specified.")]
        Unknown = 0,

        /// <summary>
        /// Cursor by default.
        /// </summary>
        [Description("Cursor by default")]
        Default = 1,

        /// <summary>
        /// Wait cursor.
        /// </summary>
        [Description("Wait cursor")]
        Wait    = 2,

        /// <summary>
        /// Arrow cursor.
        /// </summary>
        [Description("Arrow cursor")]
        Arrow   = 3,

        /// <summary>
        /// Cross cursor.
        /// </summary>
        [Description("Cross cursor")]
        Cross   = 4,

        /// <summary>
        /// Help cursor.
        /// </summary>
        [Description("Help cursor")]
        Help    = 5,

    }
}
