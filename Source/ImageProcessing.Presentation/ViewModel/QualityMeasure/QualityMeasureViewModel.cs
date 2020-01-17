using System.Drawing;

namespace ImageProcessing.Presentation.ViewModel.QualityMeasure
{
    public class QualityMeasureViewModel
    {
        public QualityMeasureViewModel(Bitmap bitmap)
        {
            Bitmap = bitmap;
        }

        public Bitmap Bitmap { get; }

    }
}
