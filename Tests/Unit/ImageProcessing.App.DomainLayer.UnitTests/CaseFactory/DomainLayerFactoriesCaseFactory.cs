using System;
using System.Collections;
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
using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Implementation.Binary;
using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Implementation.Color.Colors;
using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Implementation.Grayscale;
using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Implementation.Inversion;

using NUnit.Framework;

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

        public static IEnumerable<(ConvolutionFilter Input, Type Result)> ConvolutionFactoryTestCases
        {
            get
            {
                yield return (ConvolutionFilter.BoxBlur3x3, typeof(BoxBlur3x3));
                yield return (ConvolutionFilter.BoxBlur5x5, typeof(BoxBlur5x5));
                yield return (ConvolutionFilter.EmbossOperator3x3, typeof(Emboss3x3));
                yield return (ConvolutionFilter.GaussianBlur3x3, typeof(GaussianBlur3x3));
                yield return (ConvolutionFilter.GaussianBlur5x5, typeof(GaussianBlur5x5));
                yield return (ConvolutionFilter.LaplacianOperator3x3, typeof(LaplacianOperator3x3));
                yield return (ConvolutionFilter.LaplacianOperator5x5, typeof(LaplacianOperator5x5));
                yield return (ConvolutionFilter.MotionBlur9x9, typeof(MotionBlur9x9));
                yield return (ConvolutionFilter.SharpenOperator3x3, typeof(Sharpen3x3));
                yield return (ConvolutionFilter.SobelOperatorHorizontal3x3, typeof(SobelOperatorHorizontal));
                yield return (ConvolutionFilter.SobelOperatorVertical3x3, typeof(SobelOperatorVertical));
            }
        }

        public static IEnumerable<(Distributions Input, Type Result)> DistributionFactoryTestCases
        {
            get
            {
                yield return (Distributions.Rayleigh, typeof(RayleighDistribution));
                yield return (Distributions.Exponential, typeof(ExponentialDistribution));
                yield return (Distributions.Cauchy, typeof(CauchyDistribution));
                yield return (Distributions.Laplace, typeof(LaplaceDistribution));
                yield return (Distributions.Normal, typeof(NormalDistribution));
                yield return (Distributions.Parabola, typeof(ParabolaDistribution));
                yield return (Distributions.Uniform, typeof(UniformDistribution));
                yield return (Distributions.Weibull, typeof(WeibullDistribution));
            }
        }

        public static IEnumerable<(RgbFilter Input, Type Result)> RgbFiltersFactoryTestCases
        {
            get
            {
                yield return (RgbFilter.Binary, typeof(BinaryFilter));
                yield return (RgbFilter.Grayscale, typeof(GrayscaleFilter));
                yield return (RgbFilter.Inversion, typeof(InversionFilter));
            }
        }
    }
}
