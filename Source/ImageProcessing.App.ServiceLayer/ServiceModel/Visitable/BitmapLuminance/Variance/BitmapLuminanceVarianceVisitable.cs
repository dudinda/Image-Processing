using System;
using System.Drawing;

using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Visitor.Interface;

namespace ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models.Variance
{
    internal sealed class BitmapLuminanceVarianceVisitable : IBitmapLuminanceVisitable
    {
        private IBitmapLuminanceVisitor _visitor = null!;

        public IBitmapLuminanceVisitable Accept(IBitmapLuminanceVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }
           
        public decimal GetInfo(Bitmap bmp)
            => _visitor?.GetVariance(bmp)
                ?? throw new ArgumentNullException(nameof(_visitor));

    }
}
