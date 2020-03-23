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
using ImageProcessing.DomainModel.Convolution.Interface;
using ImageProcessing.DomainModel.Factory.Convolution.Interface;

namespace ImageProcessing.DomainModel.Factory.Convolution.Implementation
{
    /// <inheritdoc cref="IConvolutionFilterFactory" />
    public sealed class ConvolutionFilterFactory : IConvolutionFilterFactory
    {
        /// <summary>
        /// A factory method
        /// where <see cref="ConvolutionFilter"/> represents
        /// enumeration for types implementing <see cref="IConvolutionFilter"/>.
        /// </summary>
        public IConvolutionFilter Get(ConvolutionFilter filter)
        => filter switch
        {
            ConvolutionFilter.BoxBlur3x3
                => new BoxBlur3x3(),
            ConvolutionFilter.BoxBlur5x5
                => new BoxBlur5x5(),
            ConvolutionFilter.EmbossOperator3x3
                => new Emboss3x3(),
            ConvolutionFilter.GaussianBlur3x3
                => new GaussianBlur3x3(),
            ConvolutionFilter.GaussianBlur5x5
                => new GaussianBlur5x5(),
            ConvolutionFilter.GaussianOperator3x3
                => new GaussianOperator3x3(),
            ConvolutionFilter.GaussianOperator5x5
                => new GaussianOperator5x5(),
            ConvolutionFilter.LaplacianOperator3x3
                => new LaplacianOperator3x3(),
            ConvolutionFilter.LaplacianOperator5x5
                => new LaplacianOperator5x5(),
            ConvolutionFilter.MotionBlur9x9
                => new MotionBlur9x9(),
            ConvolutionFilter.SharpenOperator3x3
                => new Sharpen3x3(),
            ConvolutionFilter.SobelOperatorHorizontal3x3
                => new SobelOperatorHorizontal(),

            ConvolutionFilter.SobelOperatorVertical3x3
                => new SobelOperatorVertical(),

            _   => throw new NotImplementedException(nameof(filter))
        };
    }
}
