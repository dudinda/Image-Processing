using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Common.Enums
{
    public enum ToolbarAction
    {
        /// <summary>
        /// An unknown action
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Undo last operation
        /// </summary>
        Undo = 1,

        /// <summary>
        /// Redo last operation
        /// </summary>
        Redo = 2,

        /// <summary>
        /// Apply the F
        /// </summary>
        Shuffle = 3,

        /// <summary>
        /// Zoom an image
        /// </summary>
        Zoom   = 4
    }
}
