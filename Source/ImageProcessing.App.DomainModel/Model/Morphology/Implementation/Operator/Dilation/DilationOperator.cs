using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.App.Common.Extensions.BitmapExtensions;
using ImageProcessing.App.Common.Helpers;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrix.Implementation;

namespace ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Dilation
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class DilationOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(kernel, nameof(kernel));

            var destination = new Bitmap(bitmap);

            var source = bitmap.AdjustBorder(kernel.ColumnCount / 2, Color.Black);

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

                var kernelOffset = (byte)(kernel.ColumnCount / 2);

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount - 1
                };


                Parallel.For(kernelOffset, size.Height - kernelOffset, options, y =>
                {
                    //get the address of a new line, considering a kernel offset
                    var sourcePtr      = sourceStartPtr + y * sourceBitmapData.Stride + kernelOffset * ptrStep;
                    var destinationPtr = destinationStartPtr + y * destinationBitmapData.Stride + kernelOffset * ptrStep;

                    //a pointer, which gets addresses of the elements in the radius of a structured element
                    byte* elementPtr = null;

                    for (int x = kernelOffset; x < size.Width - kernelOffset; ++x, sourcePtr += ptrStep, destinationPtr += ptrStep)
                    {
                        bool isDilate = false;

                        for (int kernelRow = -kernelOffset; kernelRow <= kernelOffset; ++kernelRow)
                        {
                            for (int kernelColumn = -kernelOffset; kernelColumn <= kernelOffset; ++kernelColumn)
                            {
                                //get the address of a current element
                                elementPtr = sourcePtr + kernelColumn * ptrStep + kernelRow * sourceBitmapData.Stride;

                                if (kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset] && elementPtr[0] == 255)
                                {
                                    destinationPtr[0] = destinationPtr[1] = destinationPtr[2] = 255;
                                    isDilate = true;
                                    break;
                                }

                            }

                            if (isDilate) break;
                        }
                    }
                });
            }

            source.UnlockBits(sourceBitmapData);
            destination.UnlockBits(destinationBitmapData);

            source.Dispose();

            return destination;         
        }
    }
}
