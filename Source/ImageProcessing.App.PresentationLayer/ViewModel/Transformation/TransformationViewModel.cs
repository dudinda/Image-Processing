using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModel.Transformation
{
    internal sealed class TransformationViewModel
    {
        public TransformationViewModel(Bitmap source)
        {
            Source = source;
        }

        public Bitmap Source { get; set; }
    }
}
