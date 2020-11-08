using System;
using System.Collections.Generic;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.BoxBlur;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.GaussianBlur;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.MotionBlur;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.EdgeDetection.LaplacianOperator;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.EdgeDetection.SobelOperator;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Emboss;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Sharpen;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Implementation.OneParameter;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Implementation.TwoParameter;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation;

namespace ImageProcessing.App.DomainLayer.UnitTests.CaseFactory
{
    public static class DomainLayerFactoriesCaseFactory
    {
        public static IEnumerable<(RgbColors Input, Type Result)> ColorFactoryTestCases
        {
            get
            {
                yield return (RgbColors.Red, typeof(RColor));
                yield return (RgbColors.Blue, typeof(BColor));
                yield return (RgbColors.Green, typeof(GColor));
                yield return (RgbColors.Red | RgbColors.Green, typeof(RGColor));
                yield return (RgbColors.Blue | RgbColors.Green, typeof(BGColor));
                yield return (RgbColors.Red | RgbColors.Blue, typeof(RBColor));
                yield return (RgbColors.Red | RgbColors.Green | RgbColors.Blue, typeof(RGBColor));
            }
        }

        public static IEnumerable<(ConvKernel Input, Type Result)> ConvolutionFactoryTestCases
        {
            get
            {
                yield return (ConvKernel.BoxBlur3x3, typeof(BoxBlur3x3));
                yield return (ConvKernel.BoxBlur5x5, typeof(BoxBlur5x5));
                yield return (ConvKernel.EmbossOperator3x3, typeof(Emboss3x3));
                yield return (ConvKernel.GaussianBlur3x3, typeof(GaussianBlur3x3));
                yield return (ConvKernel.GaussianBlur5x5, typeof(GaussianBlur5x5));
                yield return (ConvKernel.LaplacianOperator3x3, typeof(LaplacianOperator3x3));
                yield return (ConvKernel.LaplacianOperator5x5, typeof(LaplacianOperator5x5));
                yield return (ConvKernel.MotionBlur9x9, typeof(MotionBlur9x9));
                yield return (ConvKernel.SharpenOperator3x3, typeof(Sharpen3x3));
                yield return (ConvKernel.SobelOperatorHorizontal3x3, typeof(SobelOperatorHorizontal));
                yield return (ConvKernel.SobelOperatorVertical3x3, typeof(SobelOperatorVertical));
            }
        }

        public static IEnumerable<(PrDistribution Input, Type Result)> DistributionFactoryTestCases
        {
            get
            {
                yield return (PrDistribution.Rayleigh, typeof(RayleighDistribution));
                yield return (PrDistribution.Exponential, typeof(ExponentialDistribution));
                yield return (PrDistribution.Cauchy, typeof(CauchyDistribution));
                yield return (PrDistribution.Laplace, typeof(LaplaceDistribution));
                yield return (PrDistribution.Normal, typeof(NormalDistribution));
                yield return (PrDistribution.Parabola, typeof(ParabolaDistribution));
                yield return (PrDistribution.Uniform, typeof(UniformDistribution));
                yield return (PrDistribution.Weibull, typeof(WeibullDistribution));
            }
        }

        public static IEnumerable<(RgbFltr Input, Type Result)> RgbFiltersFactoryTestCases
        {
            get
            {
                yield return (RgbFltr.Binary, typeof(BinaryFilter));
                yield return (RgbFltr.Grayscale, typeof(GrayscaleFilter));
                yield return (RgbFltr.Inversion, typeof(InversionFilter));
            }
        }
    }
}
