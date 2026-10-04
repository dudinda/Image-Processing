using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.ColorMatrix;
using ImageProcessing.App.Domain.Models.ColorMatrix.Implementation;
using ImageProcessing.App.Domain.Services.Factories.ColorMatrix;

namespace ImageProcessing.App.Domain.Factories.ColorMatrix.Implementation
{
    public sealed class ColorMatrixFactory : IColorMatrixFactory
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
             ClrMatrix.Unknown
                 => new UnknownColorMatrix(),

             _   => throw new NotImplementedException(nameof(matrix))
         };
    }
}
