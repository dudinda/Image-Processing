using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.Convolution
{
    /// <summary>
    /// Expose elements from the convolution form.
    /// </summary>
    internal interface IConvolutionFormExposer 
    {
        /// <summary>
        /// Apply a convolution filter.
        /// </summary>
        MetroButton ApplyButton { get; }
    }
}
