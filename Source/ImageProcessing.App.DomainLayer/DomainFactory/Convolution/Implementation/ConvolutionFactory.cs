using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.BoxBlur;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.GaussianBlur;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.MotionBlur;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.EdgeDetection.LaplacianOperator;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.EdgeDetection.SobelOperator;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Emboss;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Sharpen;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Implementation
{
    /// <inheritdoc cref="IConvolutionFactory" />
    public sealed class ConvolutionFactory : IConvolutionFactory
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="ConvKernel"/> represents an
        /// enumeration for the types implementing the <see cref="IConvolutionKernel"/>.
        /// </summary>
        public IConvolutionKernel Get(ConvKernel filter)
            => filter
        switch
        {
            ConvKernel.BoxBlur3x3
                => new BoxBlur3x3(),
            ConvKernel.BoxBlur5x5
                => new BoxBlur5x5(),
            ConvKernel.EmbossOperator3x3
                => new Emboss3x3(),
            ConvKernel.GaussianBlur3x3
                => new GaussianBlur3x3(),
            ConvKernel.GaussianBlur5x5
                => new GaussianBlur5x5(),
            ConvKernel.LaplacianOperator3x3
                => new LaplacianOperator3x3(),
            ConvKernel.LaplacianOperator5x5
                => new LaplacianOperator5x5(),
            ConvKernel.MotionBlur9x9
                => new MotionBlur9x9(),
            ConvKernel.SharpenOperator3x3
                => new Sharpen3x3(),
            ConvKernel.SobelOperatorHorizontal3x3
                => new SobelOperatorHorizontal(),
            ConvKernel.SobelOperatorVertical3x3
                => new SobelOperatorVertical(),

            _   => throw new NotImplementedException(nameof(filter))
        };
    }
}
