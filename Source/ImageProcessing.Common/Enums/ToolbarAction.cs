using System.ComponentModel;

namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Specifies a toolbar action of the main window
    /// </summary>
    public enum ToolbarAction
    {
        /// <summary>
        /// An unknown action.
        /// </summary>
        [Description("Toolbar action is not specified")]
        Unknown = 0,

        /// <summary>
        /// Undo last operation.
        /// </summary>
        [Description("Undo last operation")]
        Undo    = 1,

        /// <summary>
        /// Redo last operation.
        /// </summary>
        [Description("Redo last operation")]
        Redo    = 2,

        /// <summary>
        /// Apply the Fisher-Yates algorithm.
        /// </summary>
        [Description("Shuffle the source image")]
        Shuffle = 3,

        /// <summary>
        /// Zoom an image.
        /// </summary>
        [Description("Zoom an image")]
        Zoom    = 4
    }
}
