using System.ComponentModel;

namespace ImageProcessing.Utility.Interop.Code.Enums
{
    /// <summary>
    /// The following table describes the system classes
    /// that are available only for use by the system. 
    /// </summary>
    internal enum ClassOnlyForSystem
    {
        /// <summary>
        /// An unknown class.
        /// </summary>
        [Description("Class is not specified")]
        Unknown          = 0,

        /// <summary>
        /// The class for the list box contained in a combo box.
        /// </summary>
        [Description("ComboLBox")]
        ComboLBox        = 1,

        /// <summary>
        /// The class for Dynamic Data Exchange Management Library (DDEML) events.
        /// </summary>
        [Description("DDEMLEvent")]
        DDEMLEvent       = 2,

        /// <summary>
        /// The class for a message-only window.
        /// </summary>
        [Description("Message")]
        Message          = 3,

        /// <summary>
        /// The class for a menu.
        /// </summary>
        [Description("#32768")]
        Menu             = 4,

        /// <summary>
        /// The class for the desktop window.
        /// </summary>
        [Description("#32769")]
        DesktopWindow    = 5,

        /// <summary>
        /// The class for a dialog box.
        /// </summary>
        [Description("#32770")]
        DialogBox        = 6,

        /// <summary>
        /// The class for the task switch window.
        /// </summary>
        [Description("#32771")]
        TaskSwitchWindow = 7,

        /// <summary>
        /// The class for icon titles.
        /// </summary>
        [Description("#32772")]
        IconTitles       = 8
    }
}
