using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Common.Enums
{
    public enum FileDialogAction
    {
        /// <summary>
        /// An unknown file dialog action
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Open file dialog
        /// </summary>
        Open    = 1,

        /// <summary>
        /// Save file dialog
        /// </summary>
        Save    = 2,

        /// <summary>
        /// Save file as dialog
        /// </summary>
        SaveAs  = 3,
        
        /// <summary>
        /// Color dialog 
        /// </summary>
        Color   = 4
    }
}
