using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Model.Convolution;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.Services.ConvolutionFilterServices.Implementation
{
    //ptr[0] - B, ptr[1] - G, ptr[2] - R, ptr[3] - A
    public class ConvolutionFilterService : IConvolutionFilterService
    {
        public Image Convolution(Bitmap source, AbstractConvolutionFilter filter) 
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
                    MaxDegreeOfParallelism = Environment.ProcessorCount - 2
                };

                Parallel.For(kernelOffset, size.Height - kernelOffset, options, y =>
                {
                    //get an address of a new line, considering a kernel offset
                    var sourcePtr      = sourceStartPtr      + y * sourceBitmapData.Stride + kernelOffset * ptrStep;
                    var destinationPtr = destinationStartPtr + y * sourceBitmapData.Stride + kernelOffset * ptrStep;

                    //accumulators of components R, G, B
                    double R, G, B;
                    //a pointer, getting addresses of elements in a radius of a convolution
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
                                //get address of a current element
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

                        if (B > 255) B = 255;
                        else if (B < 0) B = 0;

                        if (G > 255) G = 255;
                        else if (G < 0) G = 0;

                        if (R > 255) R = 255;
                        else if (R < 0) R = 0;

                        destinationPtr[0] = (byte)B;
                        destinationPtr[1] = (byte)G;
                        destinationPtr[2] = (byte)R;
                    }                   
                });          
            }

            source.UnlockBits(sourceBitmapData);
            destination.UnlockBits(destinationBitmapData);

            return destination;
        }
    }
}
