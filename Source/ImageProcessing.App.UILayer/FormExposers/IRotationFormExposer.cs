using ImageProcessing.App.UILayer.Forms.Rotation;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers
{
    /// <summary>
    /// Expose elements from the <see cref="RotationForm"/>.
    /// </summary>
    internal interface IRotationFormExposer
    {
        /// <summary>
        /// Apply a rotation button.
        /// </summary>
        MetroButton RotateButton { get; }
    }
}
