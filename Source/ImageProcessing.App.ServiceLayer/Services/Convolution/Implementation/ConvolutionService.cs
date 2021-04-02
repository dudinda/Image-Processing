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
        public Bitmap Convolution(Bitmap src, IConvolutionKernel filter) 
        {
            src.IsSupported();

            var dst = new Bitmap(src);

            var srcData = src.LockBits(
                new Rectangle(0, 0, src.Width, src.Height),
                ImageLockMode.ReadOnly, src.PixelFormat);

            var dstData = dst.LockBits(
                new Rectangle(0, 0, dst.Width, dst.Height),
                ImageLockMode.WriteOnly, dst.PixelFormat);

            var (width, height) = (src.Width, src.Height);
            var step = Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8;

            unsafe
            {
                var srcStartPtr = (byte*)srcData.Scan0.ToPointer();
                var dstStartPtr = (byte*)dstData.Scan0.ToPointer();
                var (srcStride, dstStride) = (srcData.Stride, dstData.Stride);

                var kernelOffset = (byte)((filter.Kernel.ColumnCount - 1) / 2);

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                Parallel.For(kernelOffset, height - kernelOffset, options, y =>
                {
                    //get the address of a new line, considering a kernel offset
                    var srcPtr = srcStartPtr + y * srcStride + kernelOffset * step;
                    var dstPtr = dstStartPtr + y * dstStride + kernelOffset * step;

                    //accumulators of R, G, B components 
                    double r, g, b;

                    //addresses of elements in the radius of a convolution kernel
                    byte* rowPtr, colPtr;
                    int rowIdx, colIdx;

                    for (int x = kernelOffset; x < width - kernelOffset; ++x, srcPtr += step, dstPtr += step)
                    {
                        r = 0d; g = 0d; b = 0d;

                        for (var kernelRow = -kernelOffset; kernelRow <= kernelOffset; ++kernelRow)
                        {
                            rowPtr = srcPtr + kernelRow * srcStride;
                            rowIdx = kernelRow + kernelOffset;

                            for (var kernelColumn = -kernelOffset; kernelColumn <= kernelOffset; ++kernelColumn)
                            {
                                //get the address of a current element
                                colPtr = rowPtr + kernelColumn * step;
                                colIdx = kernelColumn + kernelOffset;
                                
                                b += colPtr[0] * filter.Kernel[rowIdx, colIdx];
                                g += colPtr[1] * filter.Kernel[rowIdx, colIdx];
                                r += colPtr[2] * filter.Kernel[rowIdx, colIdx];
                            }
                        }
                        //multiply each component by the kernel factor
                        b = b * filter.Factor + filter.Bias;
                        g = g * filter.Factor + filter.Bias;
                        r = r * filter.Factor + filter.Bias;

                        if (b > 255d) { b = 255d; } else if (b < 0d) { b = 0d; }
                        if (g > 255d) { g = 255d; } else if (g < 0d) { g = 0d; }
                        if (r > 255d) { r = 255d; } else if (r < 0d) { r = 0d; }

                        dstPtr[0] = (byte)b; dstPtr[1] = (byte)g; dstPtr[2] = (byte)r;
                    }                   
                });          
            }

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }
    }
}
