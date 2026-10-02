using System;
using System.Collections.Generic;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Blur.BoxBlur;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Blur.GaussianBlur;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Blur.MotionBlur;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.EdgeDetection.LaplacianOperator;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.EdgeDetection.SobelOperator;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Emboss;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Sharpen;
using ImageProcessing.App.ServiceLayer.Models.Distribution.Implementation.OneParameter;
using ImageProcessing.App.ServiceLayer.Models.Distribution.Implementation.TwoParameter;
using ImageProcessing.App.ServiceLayer.Models.Rgb.Channel.Implementation;
using ImageProcessing.App.ServiceLayer.Models.Rgb.RgbFilter.Implementation;

namespace ImageProcessing.App.ServiceLayer.UnitTests.CaseFactory
{
    public static class ServiceLayerFactoriesCaseFactory
    {
        public static IEnumerable<(RgbChannels Input, Type Result)> ColorFactoryTestCases
        {
            get
            {
                yield return (RgbChannels.Red, typeof(RChannel));
                yield return (RgbChannels.Blue, typeof(BChannel));
                yield return (RgbChannels.Green, typeof(GChannel));
                yield return (RgbChannels.Red | RgbChannels.Green, typeof(RGChannel));
                yield return (RgbChannels.Blue | RgbChannels.Green, typeof(BGChannel));
                yield return (RgbChannels.Red | RgbChannels.Blue, typeof(RBChannel));
                yield return (RgbChannels.Red | RgbChannels.Green | RgbChannels.Blue, typeof(RGBChannel));
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
