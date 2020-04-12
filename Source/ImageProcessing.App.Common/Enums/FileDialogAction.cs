using System.ComponentModel;

namespace ImageProcessing.App.Common.Enums
{
    /// <summary>
    /// Specified an action of the built in file dialog.
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
        /// Save file operation without a dialog window.
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
