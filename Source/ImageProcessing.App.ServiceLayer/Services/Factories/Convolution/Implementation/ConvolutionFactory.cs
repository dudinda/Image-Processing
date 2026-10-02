using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Blur.BoxBlur;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Blur.GaussianBlur;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Blur.MotionBlur;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.EdgeDetection.LaplacianOperator;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.EdgeDetection.SobelOperator;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Emboss;
using ImageProcessing.App.ServiceLayer.Models.Convolution.Implementation.Sharpen;
using ImageProcessing.App.ServiceLayer.Models.Convolution;
using ImageProcessing.App.ServiceLayer.Services.Factories.Convolution;

namespace ImageProcessing.App.ServiceLayer.Factories.Convolution.Implementation
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
