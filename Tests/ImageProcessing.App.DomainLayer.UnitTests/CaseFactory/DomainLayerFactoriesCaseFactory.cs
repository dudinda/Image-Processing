using System.Collections;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Convolution.Implemetation.Blur.BoxBlur;
using ImageProcessing.App.DomainLayer.Convolution.Implemetation.Blur.GaussianBlur;
using ImageProcessing.App.DomainLayer.Convolution.Implemetation.Blur.MotionBlur;
using ImageProcessing.App.DomainLayer.Convolution.Implemetation.EdgeDetection.LaplacianOperator;
using ImageProcessing.App.DomainLayer.Convolution.Implemetation.EdgeDetection.SobelOperator;
using ImageProcessing.App.DomainLayer.Convolution.Implemetation.Emboss;
using ImageProcessing.App.DomainLayer.Convolution.Implemetation.Sharpen;
using ImageProcessing.App.DomainLayer.Model.Distributions.Implementation.OneParameter;
using ImageProcessing.App.DomainLayer.Model.Distributions.Implementation.TwoParameter;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Color.Colors;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Grayscale;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Inversion;

using NUnit.Framework;

namespace ImageProcessing.App.DomainLayer.UnitTests.CaseFactory
{
    public static class DomainLayerFactoriesCaseFactory
    {
        public static IEnumerable ColorFactoryTestCases
        {
            get
            {
                yield return new TestCaseData(RgbColors.Red, typeof(RColor));
                yield return new TestCaseData(RgbColors.Blue, typeof(BColor));
                yield return new TestCaseData(RgbColors.Green, typeof(GColor));
                yield return new TestCaseData(RgbColors.Red | RgbColors.Green, typeof(RGColor));
                yield return new TestCaseData(RgbColors.Blue | RgbColors.Green, typeof(BGColor));
                yield return new TestCaseData(RgbColors.Red | RgbColors.Blue, typeof(RBColor));
                yield return new TestCaseData(RgbColors.Red | RgbColors.Green | RgbColors.Blue, typeof(RGBColor));
                yield return new TestCaseData(RgbColors.Red, typeof(RColor)).Returns(new RColor());
            }
        }

        public static IEnumerable ConvolutionFactoryTestCases
        {
            get
            {
                yield return new TestCaseData(ConvolutionFilter.BoxBlur3x3, typeof(BoxBlur3x3));
                yield return new TestCaseData(ConvolutionFilter.BoxBlur5x5, typeof(BoxBlur5x5));
                yield return new TestCaseData(ConvolutionFilter.EmbossOperator3x3, typeof(Emboss3x3));
                yield return new TestCaseData(ConvolutionFilter.GaussianBlur3x3, typeof(GaussianBlur3x3));
                yield return new TestCaseData(ConvolutionFilter.GaussianBlur5x5, typeof(GaussianBlur5x5));
                yield return new TestCaseData(ConvolutionFilter.LaplacianOperator3x3, typeof(LaplacianOperator3x3));
                yield return new TestCaseData(ConvolutionFilter.LaplacianOperator5x5, typeof(LaplacianOperator5x5));
                yield return new TestCaseData(ConvolutionFilter.MotionBlur9x9, typeof(MotionBlur9x9));
                yield return new TestCaseData(ConvolutionFilter.SharpenOperator3x3, typeof(Sharpen3x3));
                yield return new TestCaseData(ConvolutionFilter.SobelOperatorHorizontal3x3, typeof(SobelOperatorHorizontal));
                yield return new TestCaseData(ConvolutionFilter.SobelOperatorVertical3x3, typeof(SobelOperatorVertical));
            }
        }

        public static IEnumerable DistributionFactoryTestCases
        {
            get
            {
                yield return new TestCaseData(Distributions.Rayleigh, typeof(RayleighDistribution));
                yield return new TestCaseData(Distributions.Exponential, typeof(ExponentialDistribution));
                yield return new TestCaseData(Distributions.Cauchy, typeof(CauchyDistribution));
                yield return new TestCaseData(Distributions.Laplace, typeof(LaplaceDistribution));
                yield return new TestCaseData(Distributions.Normal, typeof(NormalDistribution));
                yield return new TestCaseData(Distributions.Parabola, typeof(ParabolaDistribution));
                yield return new TestCaseData(Distributions.Uniform, typeof(UniformDistribution));
                yield return new TestCaseData(Distributions.Weibull, typeof(WeibullDistribution));
            }
        }

        public static IEnumerable RgbFiltersFactoryTestCases
        {
            get
            {
                yield return new TestCaseData(RgbFilter.Binary, typeof(BinaryFilter));
                yield return new TestCaseData(RgbFilter.Grayscale, typeof(GrayscaleFilter));
                yield return new TestCaseData(RgbFilter.Inversion, typeof(InversionFilter));
            }
        }
    }
}
