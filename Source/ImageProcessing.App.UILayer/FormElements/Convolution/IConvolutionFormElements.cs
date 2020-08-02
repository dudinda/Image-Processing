using ImageProcessing.App.PresentationLayer.Views.Convolution;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormElements.Convolution
{
    internal interface IConvolutionFormElements : IConvolutionFilterView
    {
        MetroButton ApplyButton { get; }
    }
}
