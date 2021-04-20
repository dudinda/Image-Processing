using ImageProcessing.App.UILayer.Forms.Transformation;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.Transformation
{
    /// <summary>
    /// Expose elements from the <see cref="TransformationForm"/>.
    /// </summary>
    internal interface ITransformationFormExposer
    {
        /// <summary>
        /// Apply transformation button.
        /// </summary>
        MetroButton ApplyButton { get; }

        /// <summary>
        /// Distribution parameters.
        /// </summary>
        (string, string) Parameters { get; }
    }
}
