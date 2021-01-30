using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModels.Distribution
{
    public sealed class DistributionViewModel
    {
        public DistributionViewModel(Bitmap source)
        {
            Source = source;
        }

        public Bitmap Source { get; set; }
    }
}
