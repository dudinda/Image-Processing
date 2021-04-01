using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Convolution.Implementation
{
    /// <inheritdoc cref="IConvolutionService"/>
    public sealed class ConvolutionService : IConvolutionService
    {
        /// <inheritdoc/>
        public Bitmap Convolution(Bitmap source, IConvolutionKernel filter) 
        {
            source.IsSupported();

            var destination = new Bitmap(source);

            var sourceBitmapData = source.LockBits(
                new Rectangle(0, 0, source.Width, source.Height),
                ImageLockMode.ReadOnly, source.PixelFormat);

            var destinationBitmapData = destination.LockBits(
                new Rectangle(0, 0, source.Width, source.Height),
                ImageLockMode.WriteOnly, destination.PixelFormat);

            var (width, height) = (source.Width, source.Height);
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;

            unsafe
            {
                var sourceStartPtr      = (byte*)sourceBitmapData.Scan0.ToPointer();
                var destinationStartPtr = (byte*)destinationBitmapData.Scan0.ToPointer();
                var (srcStride, dstStride) = (sourceBitmapData.Stride, destinationBitmapData.Stride);

                var kernelOffset = (byte)((filter.Kernel.ColumnCount - 1) / 2);

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                Parallel.For(kernelOffset, height - kernelOffset, options, y =>
                {
                    //get the address of a new line, considering a kernel offset
                    var sourcePtr      = sourceStartPtr      + y * srcStride + kernelOffset * step;
                    var destinationPtr = destinationStartPtr + y * dstStride + kernelOffset * step;

                    //accumulators of R, G, B components 
                    double r, g, b;

                    //addresses of elements in the radius of a convolution kernel
                    byte* rowPtr, colPtr;

                    for (int x = kernelOffset; x < width - kernelOffset; ++x, sourcePtr += step, destinationPtr += step)
                    {
                        //set accumulators to 0
                        r = 0d; g = 0d; b = 0d;

                        for (var kernelRow = -kernelOffset; kernelRow <= kernelOffset; ++kernelRow)
                        {
                            rowPtr = sourcePtr + kernelRow * srcStride;

                            for (var kernelColumn = -kernelOffset; kernelColumn <= kernelOffset; ++kernelColumn)
                            {
                                //get the address of a current element
                                colPtr = rowPtr + kernelColumn * step;

                                //sum
                                b += colPtr[0] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                                g += colPtr[1] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                                r += colPtr[2] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                            }
                        }
                        //multiply each component by the kernel factor
                        b = b * filter.Factor + filter.Bias;
                        g = g * filter.Factor + filter.Bias;
                        r = r * filter.Factor + filter.Bias;

                        if (b > 255d) { b = 255d; } else if (b < 0d) { b = 0d; }
                        if (g > 255d) { g = 255d; } else if (g < 0d) { g = 0d; }
                        if (r > 255d) { r = 255d; } else if (r < 0d) { r = 0d; }

                        destinationPtr[0] = (byte)b;
                        destinationPtr[1] = (byte)g;
                        destinationPtr[2] = (byte)r;
                    }                   
                });          
            }

            source.UnlockBits(sourceBitmapData);
            destination.UnlockBits(destinationBitmapData);

            return destination;
        }
    }
}
