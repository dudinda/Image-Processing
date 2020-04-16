using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.UILayer.Code.Enums
{
    /// <summary>
    /// Specifies a main view action.
    /// </summary>
    internal enum MainViewAction
    {
        /// <summary>
        /// An unknown action.
        /// </summary>
        Unknown       = 0,

        /// <summary>
        /// Refresh an <see cref="ImageContainer"/>.
        /// </summary>
        Refresh       = 1,

        /// <summary>
        /// Zoom an <see cref="ImageContainer"/>.
        /// </summary>
        Zoom          = 2,

        /// <summary>
        /// Reset a trackbar value of an <see cref="ImageContainer"/> trackbar. 
        /// </summary>
        ResetTrackBar = 3,

        /// <summary>
        /// Set a trackbar value of an <see cref="ImageContainer"/>.
        /// </summary>
        SetImage      = 4,

        /// <summary>
        /// Set a copy of an <see cref="ImageContainer"/>.
        /// </summary>
        SetCopy       = 5,

        /// <summary>
        /// Set a <see cref="CursorType"/>.
        /// </summary>
        SetCursor     = 6,

        /// <summary>
        /// Check wether an <see cref="ImageContainer"/> is null.
        /// </summary>
        ImageIsNull   = 7,

        /// <summary>
        /// Get a copy of an <see cref="ImageContainer"/>.
        /// </summary>
        GetCopy       = 8,

        /// <summary>
        /// Set a zoom copy of an <see cref="ImageContainer"/>.
        /// </summary>
        SetToZoom     = 9,

        /// <summary>
        /// Get a <see cref="RgbColors"/> combination.
        /// </summary>
        GetColor      = 10
    }
}
