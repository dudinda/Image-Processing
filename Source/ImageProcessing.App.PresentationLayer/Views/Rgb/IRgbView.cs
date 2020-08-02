using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.RgbMenu;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views.Rgb
{
    public interface IRgbView
        : IView, IDisposable, IColorMenu
        
    {
        public RgbFilter SelectedFilter { get; }
    }
}
