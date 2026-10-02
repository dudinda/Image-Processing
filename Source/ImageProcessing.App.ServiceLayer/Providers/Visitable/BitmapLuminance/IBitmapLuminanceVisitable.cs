using System.Drawing;

using ImageProcessing.App.ServiceLayer.Providers.Visitable;
using ImageProcessing.App.ServiceLayer.Providers.Visitors.BitmapLuminance;

namespace ImageProcessing.App.ServiceLayer.Providers.Visitable.BitmapLuminance
{
    public interface IBitmapLuminanceVisitable
        : IVisitable<IBitmapLuminanceVisitable, IBitmapLuminanceVisitor>
    {
        decimal GetInfo(Bitmap bmp);
    }
}
