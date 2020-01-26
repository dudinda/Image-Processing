using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Common.Enums
{
    public enum Luma
    {
        /// <summary>
        /// An unknown recommendation
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// ITU-R Recommendation BT.601
        /// </summary>
        Rec601 = 1,

        /// <summary>
        /// ITU-R Recommendation BT.709
        /// </summary>
        Rec709 = 2,

        /// <summary>
        /// ITU-R Recommendation BT.240
        /// </summary>
        Rec240 = 3
    }
}
