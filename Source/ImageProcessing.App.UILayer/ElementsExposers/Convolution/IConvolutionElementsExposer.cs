using ImageProcessing.App.PresentationLayer.Views.Convolution;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormElements.Convolution
{
    internal interface IConvolutionElementsExposer : IConvolutionView
    {
        MetroButton ApplyButton { get; }
    }
}
