using ImageProcessing.Common.Enums;
using ImageProcessing.Core.View;

namespace ImageProcessing.PresentationLayer.Views.Convolution
{
    public interface IConvolutionFilterView : IView
    {
        ConvolutionFilter SelectedFilter { get; }
        void ShowError(string error);
    }
}
