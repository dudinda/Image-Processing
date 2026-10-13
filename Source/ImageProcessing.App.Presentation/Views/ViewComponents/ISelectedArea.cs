using System.Drawing;

namespace ImageProcessing.App.Presentation.Views.ViewComponents
{
    public interface ISelectedArea
    {
        Rectangle GetArea();
        void SetArea(Rectangle area);
    }
}
