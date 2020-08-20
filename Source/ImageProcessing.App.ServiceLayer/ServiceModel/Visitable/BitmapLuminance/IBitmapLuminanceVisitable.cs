using System.Drawing;

using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance
{
    internal interface IBitmapLuminanceVisitable
        : IVisitable<IBitmapLuminanceVisitable, IBitmapLuminanceVisitor>
    {
        decimal GetInfo(Bitmap bmp);
    }
}
