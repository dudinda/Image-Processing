using System.Drawing;

namespace ImageProcessing.App.Presentation.ViewModels
{
    internal sealed class DistributionViewModel
    {
        public DistributionViewModel(Bitmap source)
        {
            Source = source;
        }

        public Bitmap Source { get; set; }
    }
}
