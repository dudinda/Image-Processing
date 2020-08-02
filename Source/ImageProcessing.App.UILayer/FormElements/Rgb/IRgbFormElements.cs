using ImageProcessing.App.PresentationLayer.Views.Rgb;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormControls.Rgb
{
    internal interface IRgbFormElements : IRgbView
    {
        MetroRadioButton RedButton { get; }
        MetroRadioButton GreenButton { get; }
        MetroRadioButton BlueButton { get; }
        MetroButton ApplyFilterButton { get; }
    }
}
