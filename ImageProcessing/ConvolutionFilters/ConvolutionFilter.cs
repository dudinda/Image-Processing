using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication4.ConvulationFilters;

namespace WindowsFormsApplication4.ConvolutionFilters
{
    public static class BitmapConvolutionFilter
    {
        public static Bitmap ConvolutionFilter<T>(this Bitmap source, T filter) where T : AbstractConvolutionFilter
        {


            var destination = new Bitmap(source);

            var sourceBitmapData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                                   System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                   System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            var destinationBitmapData = destination.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                                             System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                             System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            unsafe
            {
                var sourcePtr      = (byte*)sourceBitmapData.Scan0.ToPointer();
                var destinationPtr = (byte*)destinationBitmapData.Scan0.ToPointer();
             
            
                var nWidth = source.Width * 4;

                var kernelOffset = (filter.Kernel.GetLength(1) - 1) / 2;

                var nOffset = sourceBitmapData.Stride - source.Width * 4 + 4  * kernelOffset;

                sourcePtr      += sourceBitmapData.Stride      * kernelOffset  + nOffset;
                destinationPtr += destinationBitmapData.Stride * kernelOffset  + nOffset;

                double R, G, B;

                byte* byteOffset = null;

                for(int y = kernelOffset; y < source.Height - kernelOffset; ++y, sourcePtr += nOffset * 2, destinationPtr += nOffset * 2)
                {
                    
                    for(int x = kernelOffset; x < source.Width - kernelOffset; ++x, sourcePtr += 4, destinationPtr += 4)
                    {
                        R = 0;
                        G = 0;
                        B = 0;

                        for (int kernelRow = -kernelOffset; kernelRow <= kernelOffset; ++kernelRow)
                        {
                            for (int kernelColumn = -kernelOffset; kernelColumn <= kernelOffset; ++kernelColumn)
                            {
                                byteOffset = sourcePtr + kernelColumn * 4  + kernelRow * sourceBitmapData.Stride;
                  

                                B += byteOffset[0] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];


                                G += byteOffset[1] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];


                                R += byteOffset[2] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];
                

                            }
                        }

                        B *= filter.Factor;
                        G *= filter.Factor;
                        R *= filter.Factor;

                        if (B > 255) B = 255;
                        else if (B < 0) B = 0;

                        if (G > 255) G = 255;
                        else if (G < 0) G = 0;

                        if (R > 255) R = 255;
                        else if (R < 0) R = 0;

                        destinationPtr[0] = (byte)B;
                        destinationPtr[1] = (byte)G;
                        destinationPtr[2] = (byte)R;
                        destinationPtr[3] = 255;

                    }
                   
                }

                
            }

            source.UnlockBits(sourceBitmapData);
            destination.UnlockBits(destinationBitmapData);

            return destination;
        }

    }
}
