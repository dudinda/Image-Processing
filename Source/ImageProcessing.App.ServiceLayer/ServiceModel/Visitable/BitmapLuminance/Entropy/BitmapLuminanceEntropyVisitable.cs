using System;
using System.Drawing;

using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.Entropy
{
    internal sealed class BitmapLuminanceEntropyVisitable : IBitmapLuminanceVisitable
    {
        private IBitmapLuminanceVisitor? _visitor;

        public IBitmapLuminanceVisitable Accept(IBitmapLuminanceVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }
           
        public decimal GetInfo(Bitmap bmp)
            => _visitor?.GetEntropy(bmp)
                ?? throw new ArgumentNullException(nameof(_visitor));
    }
}
