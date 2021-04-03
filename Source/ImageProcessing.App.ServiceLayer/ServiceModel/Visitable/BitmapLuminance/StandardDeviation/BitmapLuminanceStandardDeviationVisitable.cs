using System;
using System.Drawing;

using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.StandardDeviation
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
