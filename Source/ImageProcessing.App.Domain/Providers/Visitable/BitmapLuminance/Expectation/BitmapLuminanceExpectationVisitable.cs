using System;
using System.Drawing;

using ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance;
using ImageProcessing.App.Domain.Providers.Visitors.BitmapLuminance;

namespace ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance.Expectation
{
    internal sealed class BitmapLuminanceExpectationVisitable : IBitmapLuminanceVisitable
    {
        private IBitmapLuminanceVisitor? _visitor;

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
