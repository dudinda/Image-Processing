using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Convolution.Implementation
{
    /// <inheritdoc cref="IConvolutionService"/>
    internal sealed class ConvolutionService : IConvolutionService
    {
        /// <inheritdoc/>
        public Bitmap Convolution(Bitmap source, IConvolutionKernel filter) 
        {
            var destination = new Bitmap(source);

            var sourceBitmapData = source.LockBits(
                new Rectangle(0, 0, source.Width, source.Height),
                ImageLockMode.ReadOnly, source.PixelFormat);

            var destinationBitmapData = destination.LockBits(
                new Rectangle(0, 0, source.Width, source.Height),
                ImageLockMode.WriteOnly, destination.PixelFormat);

            var size = source.Size;
            var ptrStep = source.GetBitsPerPixel() / 8;
            unsafe
            {
                var sourceStartPtr      = (byte*)sourceBitmapData.Scan0.ToPointer();
                var destinationStartPtr = (byte*)destinationBitmapData.Scan0.ToPointer();
                
                var kernelOffset = (byte)((filter.Kernel.ColumnCount - 1) / 2);

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                Parallel.For(kernelOffset, size.Height - kernelOffset, options, y =>
                {
                    //get the address of a new line, considering a kernel offset
                    var sourcePtr      = sourceStartPtr      + y * sourceBitmapData.Stride      + kernelOffset * ptrStep;
                    var destinationPtr = destinationStartPtr + y * destinationBitmapData.Stride + kernelOffset * ptrStep;

                    //accumulators of R, G, B components 
                    double r, g, b;
                    //a pointer, which gets addresses of elements in the radius of a convolution kernel
                    byte* elementPtr = null;

                    for (int x = kernelOffset; x < size.Width - kernelOffset; ++x, sourcePtr += ptrStep, destinationPtr += ptrStep)
                    {
                        //set accumulators to 0
                        r = 0; g = 0; b = 0;

                        for (var kernelRow = -kernelOffset; kernelRow <= kernelOffset; ++kernelRow)
                        {
                            for (var kernelColumn = -kernelOffset; kernelColumn <= kernelOffset; ++kernelColumn)
                            {
                                //get the address of a current element
                                elementPtr = sourcePtr + kernelColumn * ptrStep + kernelRow * sourceBitmapData.Stride;

                                //sum
                                b += elementPtr[0] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                                g += elementPtr[1] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                                r += elementPtr[2] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                            }
                        }
                        //multiply each component by the kernel factor
                        b = b * filter.Factor + filter.Bias;
                        g = g * filter.Factor + filter.Bias;
                        r = r * filter.Factor + filter.Bias;

                        if (b > 255) { b = 255; } else if (b < 0) { b = 0; }
                        if (g > 255) { g = 255; } else if (g < 0) { g = 0; }
                        if (r > 255) { r = 255; } else if (r < 0) { r = 0; }

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
