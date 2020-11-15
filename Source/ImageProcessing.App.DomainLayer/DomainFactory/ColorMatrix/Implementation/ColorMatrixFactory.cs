using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Implementation
{
    internal sealed class ColorMatrixFactory : IColorMatrixFactory
    {
        public IColorMatrix Get(ClrMatrix matrix)
            => matrix
        switch
         {
             ClrMatrix.Grayscale240M
                 => new GrayscaleSmpte240MColorMatrix(),
             ClrMatrix.Grayscale601
                 => new GrayscaleRec601ColorMatrix(),
             ClrMatrix.Grayscale709
                 => new GrayscaleRec709ColorMatrix(),
             ClrMatrix.Identity
                 => new IdentityColorMatrix(),
             ClrMatrix.Inverse
                 => new InversionColorMatrix(),
             ClrMatrix.SepiaTone
                 => new SepiaToneColorMatrix(),
             ClrMatrix.RgbToYiq
                 => new RgbToYiqColorMatrix(),
             ClrMatrix.YiqToRgb
                 => new YiqToRgbColorMatrix(),
             ClrMatrix.XyzToRgb
                 => new XyzEToRgbColorMatrix(),
             ClrMatrix.RgbToXyz
                 => new RgbToXyzEColorMatrix(),
             ClrMatrix.PolaroidTone
                 => new PolaroidToneColorMatrix(),

             _   => throw new NotImplementedException(nameof(matrix))
         };
    }
}
