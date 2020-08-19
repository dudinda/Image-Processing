using System.Drawing;

using ImageProcessing.App.ServiceLayer.CompoundModels.Visitable;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Visitor.Interface;

namespace ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models
{
    internal interface IBitmapLuminanceVisitable
        : IVisitable<IBitmapLuminanceVisitable, IBitmapLuminanceVisitor>
    {
        decimal GetInfo(Bitmap bmp);
    }
}
