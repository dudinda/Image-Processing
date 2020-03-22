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
        {
            switch (filter)
            {
                case ConvolutionFilter.BoxBlur3x3:
                    return new BoxBlur3x3();
                case ConvolutionFilter.BoxBlur5x5:
                    return new BoxBlur5x5();
                case ConvolutionFilter.EmbossOperator3x3:
                    return new Emboss3x3();
                case ConvolutionFilter.GaussianBlur3x3:
                    return new GaussianBlur3x3();
                case ConvolutionFilter.GaussianBlur5x5:
                    return new GaussianBlur5x5();
                case ConvolutionFilter.GaussianOperator3x3:
                    return new GaussianOperator3x3();
                case ConvolutionFilter.GaussianOperator5x5:
                    return new GaussianOperator5x5();
                case ConvolutionFilter.LaplacianOperator3x3:
                    return new LaplacianOperator3x3();
                case ConvolutionFilter.LaplacianOperator5x5:
                    return new LaplacianOperator5x5();
                case ConvolutionFilter.MotionBlur9x9:
                    return new MotionBlur9x9();
                case ConvolutionFilter.SharpenOperator3x3:
                    return new Sharpen3x3();
                case ConvolutionFilter.SobelOperatorHorizontal3x3:
                    return new SobelOperatorHorizontal();
                case ConvolutionFilter.SobelOperatorVertical3x3:
                    return new SobelOperatorVertical();

                default: throw new NotImplementedException(nameof(filter));
            }
        }
    }
}
