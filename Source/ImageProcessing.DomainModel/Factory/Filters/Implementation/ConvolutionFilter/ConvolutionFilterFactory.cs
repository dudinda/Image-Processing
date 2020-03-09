using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.ConvolutionFilters.Blur.BoxBlur;
using ImageProcessing.ConvolutionFilters.Blur.MotionBlur;
using ImageProcessing.ConvolutionFilters.EdgeDetection;
using ImageProcessing.ConvolutionFilters.EdgeDetection.GaussianOperator;
using ImageProcessing.ConvolutionFilters.EdgeDetection.SobelOperator;
using ImageProcessing.ConvolutionFilters.Emboss;
using ImageProcessing.ConvolutionFilters.GaussianBlur;
using ImageProcessing.ConvolutionFilters.Sharpen;
using ImageProcessing.Core.Factory.ConvolutionFactory;
using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.Factory.Filters.Convolution
{
    /// <summary>
    /// Provides a factory method for all types
    /// implementing <see cref="IConvolutionFilter"/>.
    /// </summary>
    public class ConvolutionFilterFactory : IConvolutionFilterFactory
    {
        /// <summary>
        /// A factory method
        /// where <see cref="ConvolutionFilter"/> represents
        /// enumeration for types implementing <see cref="IConvolutionFilter"/>.
        /// </summary>
        public IConvolutionFilter GetFilter(ConvolutionFilter filter)
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

                default: throw new NotSupportedException(nameof(filter));
            }
        }
    }
}
