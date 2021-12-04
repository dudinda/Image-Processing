using ImageProcessing.App.UILayer.Forms.Scaling;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers
{
    /// <summary>
    /// Expose elements from the <see cref="ScalingForm"/>.
    /// </summary>
    internal interface IScalingFormExposer
    {
        /// <summary>
        /// Apply a scaling method button.
        /// </summary>
        MetroButton ScaleButton { get; }
    }
}
