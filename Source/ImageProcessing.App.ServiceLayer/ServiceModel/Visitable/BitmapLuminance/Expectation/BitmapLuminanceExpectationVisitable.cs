using System;
using System.Drawing;

using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Visitor.Interface;

namespace ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models.Expectation
{
    internal sealed class BitmapLuminanceExpectationVisitable : IBitmapLuminanceVisitable
    {
        private IBitmapLuminanceVisitor _visitor = null!;

        public IBitmapLuminanceVisitable Accept(IBitmapLuminanceVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }
        
        public decimal GetInfo(Bitmap bmp)
        => _visitor?.GetExpectation(bmp)
                ?? throw new ArgumentNullException(nameof(_visitor));
    }
}
