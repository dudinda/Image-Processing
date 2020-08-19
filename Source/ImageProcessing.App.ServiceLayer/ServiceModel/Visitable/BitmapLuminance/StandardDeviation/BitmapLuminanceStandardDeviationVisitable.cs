using System;
using System.Drawing;

using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Visitor.Interface;

namespace ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models.StandardDeviation
{
    internal sealed class BitmapLuminanceStandardDeviationVisitable : IBitmapLuminanceVisitable
    {
        private IBitmapLuminanceVisitor _visitor = null!;

        public IBitmapLuminanceVisitable Accept(IBitmapLuminanceVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }
             
        public decimal GetInfo(Bitmap bmp)
            => _visitor?.GetStandardDeviation(bmp)
                ?? throw new ArgumentNullException(nameof(_visitor));
    }
}
