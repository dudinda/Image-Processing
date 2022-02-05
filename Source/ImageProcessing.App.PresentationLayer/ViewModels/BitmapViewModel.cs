using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModels
{
    internal sealed class BitmapViewModel
    {
        private object _sync = new object();

        private Rectangle _area;

        public BitmapViewModel(Rectangle area)
        {
            _area = area;
        }

        public Rectangle SelectedArea
        {
            get
            {
                lock(_sync)
                {
                    return _area;
                }
            }

            set
            {
                lock(_sync)
                {
                    _area = value;
                }
            }
        } 
    }
}
