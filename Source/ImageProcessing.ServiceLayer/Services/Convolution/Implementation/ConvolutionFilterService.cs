using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.DomainModel.Convolution.Interface;
using ImageProcessing.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.ServiceLayer.Services.Convolution.Implementation
{
    public sealed class ConvolutionFilterService : IConvolutionFilterService
    {
        public Bitmap Convolution(Bitmap source, IConvolutionFilter filter) 
        {
            Requires.IsNotNull(source, nameof(source));
            Requires.IsNotNull(filter, nameof(filter));

            var destination = new Bitmap(source);

            var sourceBitmapData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                                   ImageLockMode.ReadOnly,
                                                   source.PixelFormat);

            var destinationBitmapData = destination.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                                             ImageLockMode.WriteOnly,
                                                             destination.PixelFormat);

            var size = source.Size;
            var ptrStep = source.GetBitsPerPixel() / 8;
            unsafe
            {
                var sourceStartPtr      = (byte*)sourceBitmapData.Scan0.ToPointer();
                var destinationStartPtr = (byte*)destinationBitmapData.Scan0.ToPointer();
                
                var kernelOffset = (byte)((filter.Kernel.GetLength(1) - 1) / 2);

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount - 1
                };

                Parallel.For(kernelOffset, size.Height - kernelOffset, options, y =>
                {
                    //get the address of a new line, considering a kernel offset
                    var sourcePtr      = sourceStartPtr      + y * sourceBitmapData.Stride + kernelOffset * ptrStep;
                    var destinationPtr = destinationStartPtr + y * destinationBitmapData.Stride + kernelOffset * ptrStep;

                    //accumulators of R, G, B components 
                    double R, G, B;
                    //a pointer, which gets addresses of elements in the radius of a convolution kernel
                    byte* elementPtr = null;

                    for (int x = kernelOffset; x < size.Width - kernelOffset; ++x, sourcePtr += ptrStep, destinationPtr += ptrStep)
                    {
                        //set accumulators to 0
                        R = 0;
                        G = 0;
                        B = 0;

                        for (int kernelRow = -kernelOffset; kernelRow <= kernelOffset; ++kernelRow)
                        {
                            for (int kernelColumn = -kernelOffset; kernelColumn <= kernelOffset; ++kernelColumn)
                            {
                                //get the address of a current element
                                elementPtr = sourcePtr + kernelColumn * ptrStep + kernelRow * sourceBitmapData.Stride;

                                //sum
                                B += elementPtr[0] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                                G += elementPtr[1] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                                R += elementPtr[2] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                            }
                        }
                        //multiply each component by the kernel factor
                        B = B * filter.Factor + filter.Bias;
                        G = G * filter.Factor + filter.Bias;
                        R = R * filter.Factor + filter.Bias;

                        destinationPtr[0] = GetByteValue(ref B);
                        destinationPtr[1] = GetByteValue(ref G);
                        destinationPtr[2] = GetByteValue(ref R);
                    }                   
                });          
            }

            source.UnlockBits(sourceBitmapData);
            destination.UnlockBits(destinationBitmapData);

            return destination;

            byte GetByteValue(ref double value)
            {
                if (value > 255)
                {
                    value = 255;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                return (byte)value;
            };
        }
    }
}
