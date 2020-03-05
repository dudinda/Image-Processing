using System.ComponentModel;

namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Specified action of the built in file dialog.
    /// </summary>
    public enum FileDialogAction
    {
        /// <summary>
        /// An unknown file dialog action.
        /// </summary>
        [Description("File dialog is not specified")]
        Unknown              = 0,

        /// <summary>
        /// Open file dialog.
        /// </summary>
        [Description("Open file dialog")]
        Open                 = 1,

        /// <summary>
        /// Save file without dialog window.
        /// </summary>
        [Description("Save file without dialog window")]
        SaveWithoutDialog    = 2,

        /// <summary>
        /// Save as file dialog.
        /// </summary>
        [Description("Save as file dialog")]
        SaveAs               = 3,

        /// <summary>
        /// Color file dialog.
        /// </summary>
        [Description("Color file dialog")]
        Color                 = 4
    }
}
