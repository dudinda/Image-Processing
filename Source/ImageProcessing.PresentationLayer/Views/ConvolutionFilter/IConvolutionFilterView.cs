using ImageProcessing.Common.Enums;
using ImageProcessing.Core.View;
using ImageProcessing.PresentationLayer.Views.ViewComponent.Error;

namespace ImageProcessing.PresentationLayer.Views.Convolution
{
    public interface IConvolutionFilterView : IView, IError
    {
        ConvolutionFilter SelectedFilter { get; }
    }
}
