using System.Drawing;

using ImageProcessing.App.Domain.Providers.Visitable;
using ImageProcessing.App.Domain.Providers.Visitors.BitmapLuminance;

namespace ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance
{
    public interface IBitmapLuminanceVisitable
        : IVisitable<IBitmapLuminanceVisitable, IBitmapLuminanceVisitor>
    {
        decimal GetInfo(Bitmap bmp);
    }
}
