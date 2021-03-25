using System.Drawing;

using ImageProcessing.App.ServiceLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.ViewModels
{
    internal sealed class HistogramViewModel
    {
        public HistogramViewModel(Bitmap source, RndFunction mode)
        {
            Source = source;
            Mode = mode;
        }

        public Bitmap Source { get; }
        public RndFunction Mode { get; }
    }
}
