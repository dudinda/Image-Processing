using ImageProcessing.Common.Enums;
using ImageProcessing.Core.MVP.View;
using ImageProcessing.PresentationLayer.Views.ViewComponent.Error;

namespace ImageProcessing.PresentationLayer.Views.Convolution
{
    /// <summary>
    /// Represents the base behavior of a
    /// convolution filter window.
    /// </summary>
    public interface IConvolutionFilterView : IView, IError
    {
        /// <summary>
        /// Get the specified <see cref="ConvolutionFilter"/>
        /// from a dropdown menu.
        /// </summary>
        ConvolutionFilter SelectedFilter { get; }
    }
}
