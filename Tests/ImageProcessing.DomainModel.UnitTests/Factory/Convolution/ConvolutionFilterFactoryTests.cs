using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Convolution.Implemetation.Blur.BoxBlur;
using ImageProcessing.DomainModel.Convolution.Implemetation.Blur.GaussianBlur;
using ImageProcessing.DomainModel.Convolution.Implemetation.Blur.MotionBlur;
using ImageProcessing.DomainModel.Convolution.Implemetation.EdgeDetection.LaplacianOperator;
using ImageProcessing.DomainModel.Convolution.Implemetation.EdgeDetection.SobelOperator;
using ImageProcessing.DomainModel.Convolution.Implemetation.Emboss;
using ImageProcessing.DomainModel.Convolution.Implemetation.Sharpen;
using ImageProcessing.DomainModel.Factory.Convolution.Implementation;
using ImageProcessing.DomainModel.Factory.Convolution.Interface;

using NUnit.Framework;

namespace ImageProcessing.DomainModel.UnitTests.Factory.Convolution
{
    [TestFixture]
    internal sealed class ConvolutionFilterFactoryTests
    {
        private IConvolutionFilterFactory _convolutionFactory;

        [SetUp]
        public void SetUp()
        {
            _convolutionFactory = new ConvolutionFilterFactory();
        }

        [Test]
        public void FactoryReturnsBoxBlur3x3ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.BoxBlur3x3
                ), Is.TypeOf(typeof(BoxBlur3x3))
            );
        }

        [Test]
        public void FactoryReturnsBoxBlur5x5ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.BoxBlur5x5
                ), Is.TypeOf(typeof(BoxBlur5x5))
            );
        }

        [Test]
        public void FactoryReturnsEmbossOperator3x3ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.EmbossOperator3x3
                ), Is.TypeOf(typeof(Emboss3x3))
            );
        }

        [Test]
        public void FactoryReturnsGaussianBlur3x3ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.GaussianBlur3x3
                ), Is.TypeOf(typeof(GaussianBlur3x3))
            );
        }

        [Test]
        public void FactoryReturnsGaussianBlur5x5ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.GaussianBlur5x5
                ), Is.TypeOf(typeof(GaussianBlur3x3))
            );
        }

        [Test]
        public void FactoryReturnsLaplacianOperator3x3ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.LaplacianOperator3x3
                ), Is.TypeOf(typeof(LaplacianOperator3x3))
            );
        }

        [Test]
        public void FactoryReturnsLaplacianOperator5x5ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.LaplacianOperator5x5
                ), Is.TypeOf(typeof(LaplacianOperator5x5))
            );
        }

        [Test]
        public void FactoryReturnsMotionBlur9x9ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.MotionBlur9x9
                ), Is.TypeOf(typeof(MotionBlur9x9))
            );
        }

        [Test]
        public void FactoryReturnsSharpenOperator3x3ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.SharpenOperator3x3
                ), Is.TypeOf(typeof(Sharpen3x3))
            );
        }

        [Test]
        public void FactoryReturnsSobelOperatorHorizontal3x3ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.SobelOperatorHorizontal3x3
                ), Is.TypeOf(typeof(SobelOperatorHorizontal))
            );
        }

        [Test]
        public void FactoryReturnsSobelOperatorVertical3x3ByEnumValue()
        {
            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.SobelOperatorVertical3x3
                ), Is.TypeOf(typeof(SobelOperatorVertical))
            );
        }

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
        {
            Assert.Throws<NotImplementedException>(
                () => _convolutionFactory.Get(ConvolutionFilter.Unknown)
            );
        }

    }
}
