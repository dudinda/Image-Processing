using ImageProcessing.App.PresentationLayer.Views.Convolution;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormElements.Convolution
{
    /// <summary>
    /// Expose elements from the convolution form.
    /// </summary>
    internal interface IConvolutionElementExposer : IConvolutionView
    {
        /// <summary>
        /// Apply a convolution filter.
        /// </summary>
        MetroButton ApplyButton { get; }
    }
}
