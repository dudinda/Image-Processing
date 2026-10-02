using System;
using System.Drawing;

using ImageProcessing.App.ServiceLayer.Providers.Visitable.BitmapLuminance;
using ImageProcessing.App.ServiceLayer.Providers.Visitors.BitmapLuminance;

namespace ImageProcessing.App.ServiceLayer.Providers.Visitable.BitmapLuminance.StandardDeviation
{
    internal sealed class BitmapLuminanceStandardDeviationVisitable : IBitmapLuminanceVisitable
    {
        private IBitmapLuminanceVisitor? _visitor;

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
