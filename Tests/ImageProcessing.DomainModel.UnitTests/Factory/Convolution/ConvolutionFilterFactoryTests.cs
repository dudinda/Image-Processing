using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Convolution.Implemetation.Blur.BoxBlur;
using ImageProcessing.DomainModel.Convolution.Implemetation.Blur.GaussianBlur;
using ImageProcessing.DomainModel.Convolution.Implemetation.Blur.MotionBlur;
using ImageProcessing.DomainModel.Convolution.Implemetation.EdgeDetection.GaussianOperator;
using ImageProcessing.DomainModel.Convolution.Implemetation.EdgeDetection.LaplacianOperator;
using ImageProcessing.DomainModel.Convolution.Implemetation.EdgeDetection.SobelOperator;
using ImageProcessing.DomainModel.Convolution.Implemetation.Emboss;
using ImageProcessing.DomainModel.Convolution.Implemetation.Sharpen;
using ImageProcessing.DomainModel.Factory.Convolution.Interface;

using NSubstitute;
using NSubstitute.ExceptionExtensions;

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
            _convolutionFactory = Substitute.For<IConvolutionFilterFactory>();
        }

        [Test]
        public void FactoryReturnsBoxBlur3x3ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.BoxBlur3x3)
                .Returns(_ => new BoxBlur3x3());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.BoxBlur3x3
                ), Is.TypeOf(typeof(BoxBlur3x3))
            );
        }

        [Test]
        public void FactoryReturnsBoxBlur5x5ByEnumValue()
        {
            _convolutionFactory
                 .Get(ConvolutionFilter.BoxBlur5x5)
                 .Returns(_ => new BoxBlur5x5());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.BoxBlur5x5
                ), Is.TypeOf(typeof(BoxBlur5x5))
            );
        }

        [Test]
        public void FactoryReturnsEmbossOperator3x3ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.EmbossOperator3x3)
                .Returns(_ => new Emboss3x3());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.EmbossOperator3x3
                ), Is.TypeOf(typeof(Emboss3x3))
            );
        }

        [Test]
        public void FactoryReturnsGaussianBlur3x3ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.GaussianBlur3x3)
                .Returns(_ => new GaussianBlur3x3());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.GaussianBlur3x3
                ), Is.TypeOf(typeof(GaussianBlur3x3))
            );
        }

        [Test]
        public void FactoryReturnsGaussianBlur5x5ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.GaussianBlur5x5)
                .Returns(_ => new GaussianBlur3x3());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.GaussianBlur5x5
                ), Is.TypeOf(typeof(GaussianBlur3x3))
            );
        }

        [Test]
        public void FactoryReturnsGaussianOperator3x3ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.GaussianOperator3x3)
                .Returns(_ => new GaussianOperator3x3());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.GaussianOperator3x3
                ), Is.TypeOf(typeof(GaussianOperator3x3))
            );
        }

        [Test]
        public void FactoryReturnsGaussianOperator5x5ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.GaussianOperator5x5)
                .Returns(_ => new GaussianOperator5x5());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.GaussianOperator5x5
                ), Is.TypeOf(typeof(GaussianOperator5x5))
            );
        }

        [Test]
        public void FactoryReturnsLaplacianOperator3x3ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.LaplacianOperator3x3)
                .Returns(_ => new LaplacianOperator3x3());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.LaplacianOperator3x3
                ), Is.TypeOf(typeof(LaplacianOperator3x3))
            );
        }

        [Test]
        public void FactoryReturnsLaplacianOperator5x5ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.LaplacianOperator5x5)
                .Returns(_ => new LaplacianOperator5x5());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.LaplacianOperator5x5
                ), Is.TypeOf(typeof(LaplacianOperator5x5))
            );
        }

        [Test]
        public void FactoryReturnsMotionBlur9x9ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.MotionBlur9x9)
                .Returns(_ => new MotionBlur9x9());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.MotionBlur9x9
                ), Is.TypeOf(typeof(MotionBlur9x9))
            );
        }

        [Test]
        public void FactoryReturnsSharpenOperator3x3ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.SharpenOperator3x3)
                .Returns(_ => new Sharpen3x3());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.SharpenOperator3x3
                ), Is.TypeOf(typeof(Sharpen3x3))
            );
        }

        [Test]
        public void FactoryReturnsSobelOperatorHorizontal3x3ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.SobelOperatorHorizontal3x3)
                .Returns(_ => new SobelOperatorHorizontal());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.SobelOperatorHorizontal3x3
                ), Is.TypeOf(typeof(SobelOperatorHorizontal))
            );
        }

        [Test]
        public void FactoryReturnsSobelOperatorVertical3x3ByEnumValue()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.SobelOperatorVertical3x3)
                .Returns(_ => new SobelOperatorVertical());

            Assert.That(
                _convolutionFactory.Get(
                    ConvolutionFilter.SobelOperatorVertical3x3
                ), Is.TypeOf(typeof(SobelOperatorVertical))
            );
        }

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
        {
            _convolutionFactory
                .Get(ConvolutionFilter.Unknown)
                .Throws(new NotImplementedException());

            Assert.Throws<NotImplementedException>(
                () => _convolutionFactory.Get(ConvolutionFilter.Unknown)
            );
        }

    }
}
