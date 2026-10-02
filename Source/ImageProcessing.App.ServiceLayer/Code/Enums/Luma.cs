using System.ComponentModel;

namespace ImageProcessing.App.DomainLayer.Code.Enums
{
    /// <summary>
    /// Specifies the definition of luma.
    /// </summary>
    public enum Luma
    {
        /// <summary>
        /// ITU-R Recommendation BT.709.
        /// </summary>
        [Description("ITUR Recommendation BT.709")]
        Rec709  = 0,

        /// <summary>
        /// ITU-R Recommendation BT.601.
        /// </summary>
        [Description("ITUR Recommendation BT.601")]
        Rec601   = 1,

        /// <summary>
        /// SMPTE-240M.
        /// </summary>
        [Description("SMPTE-240M")]
        Rec240   = 2,

        /// <summary>
        /// ITU-R Recommendation BT.2020.
        /// </summary>
        [Description("ITUR Recommendation BT.2020")]
        Rec2020  = 4,

        /// <summary>
        /// ITU-R Recommendation BT.2100.
        /// </summary>
        [Description("ITUR Recommendation BT.2100")]
        Rec2100  = 5
    }
}
