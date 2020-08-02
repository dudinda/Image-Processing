using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.UILayer.FormControls.Base;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormControls.Rgb
{
    internal interface IRgbFormControls : IRgbView
    {
        MetroRadioButton RedButton { get; }
        MetroRadioButton GreenButton { get; }
        MetroRadioButton BlueButton { get; }
        MetroButton ApplyFilterButton { get; }
    }
}
