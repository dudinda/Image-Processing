using System.Drawing;
using ImageProcessing.ConvulationFilters;
using System.Threading.Tasks;
using System;

namespace ImageProcessing.ConvolutionFilters
{
    //ptr[0] - B, ptr[1] - G, ptr[2] - R, ptr[3] - A
    public static class BitmapConvolutionFilter
    {
        //поставить ограничение на классы, наследуемые только от AbstractConvolutionFilter
        public static Bitmap ConvolutionFilter<T>(this Bitmap source, T filter) where T : AbstractConvolutionFilter
        {


            var destination = new Bitmap(source);

            var sourceBitmapData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                                   System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                   System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            var destinationBitmapData = destination.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                                                             System.Drawing.Imaging.ImageLockMode.WriteOnly,
                                                             System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            var size = source.Size;

            unsafe
            {
                var sourceStartPtr      = (byte*)sourceBitmapData.Scan0.ToPointer();
                var destinationStartPtr = (byte*)destinationBitmapData.Scan0.ToPointer();

                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;


                var kernelOffset = (byte)((filter.Kernel.GetLength(1) - 1) / 2);

              

               

                Parallel.For(kernelOffset, size.Height - kernelOffset, options, y =>
                {
                    //получить адрес новой строки, учитывая смещение матрицы свертки
                    var sourcePtr      = sourceStartPtr      + y * sourceBitmapData.Stride + kernelOffset * 3;
                    var destinationPtr = destinationStartPtr + y * sourceBitmapData.Stride + kernelOffset * 3;

                    //аккумуляторы компонентов R, G, B
                    double R, G, B;
                    //указатель, получающий адреса элементов в радиусе матрицы свертки
                    byte* elementPtr = null;

                    for (int x = kernelOffset; x < size.Width - kernelOffset; ++x, sourcePtr += 3, destinationPtr += 3)
                    {
                        //выставить аккумуляторы в 0
                        R = 0;
                        G = 0;
                        B = 0;

                        for (int kernelRow = -kernelOffset; kernelRow <= kernelOffset; ++kernelRow)
                        {
                            for (int kernelColumn = -kernelOffset; kernelColumn <= kernelOffset; ++kernelColumn)
                            {
                                //получить адрес текущего элемента
                                elementPtr = sourcePtr + kernelColumn * 3 + kernelRow * sourceBitmapData.Stride;

                                //выполнить суммирование
                                B += elementPtr[0] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];


                                G += elementPtr[1] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];


                                R += elementPtr[2] * filter.Kernel[kernelRow + kernelOffset, kernelColumn + kernelOffset];


                            }
                        }

                        //домножить каждый компонент на соответсвующий каждому ядру множитель
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
