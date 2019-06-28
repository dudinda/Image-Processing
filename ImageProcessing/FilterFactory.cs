using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessing
{
    //ptr[0] - B, ptr[1] - G, ptr[2] - R
    static class FilterFactory
    {

        public enum Filter
        {
            RED,
            GREEN,
            BLUE
        };

        public static Bitmap GrayScale(Bitmap bitmap)
        {

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                                                           ImageLockMode.ReadWrite, 
                                                           PixelFormat.Format24bppRgb);

            var size = bitmap.Size;

            var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;


            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>  
                {
                    //получить адрес строки
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        ptr[0] = ptr[1] = ptr[2] = (byte)(0.299 * ptr[2] +
                                                          0.587 * ptr[1] +
                                                          0.114 * ptr[0]);
                    }
                });
            }



            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }


        public static Bitmap Inversion(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                                                           ImageLockMode.ReadWrite, 
                                                           PixelFormat.Format24bppRgb);
            var size = bitmap.Size;

            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Environment.ProcessorCount;

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    //получить адрес строки
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        ptr[0] = (byte)(255 - ptr[0]);
                        ptr[1] = (byte)(255 - ptr[1]);
                        ptr[2] = (byte)(255 - ptr[2]);
                    }
                });
            }


            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        public static Bitmap ColorFilter(Bitmap bitmap, Filter filter)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                           ImageLockMode.ReadWrite,
                                                           PixelFormat.Format24bppRgb);

            int firstIndex, secondIndex;

            //получить индексы компонентов RGB, которым присваивается значение 0
            //в зависимости от желаемого фильтра
            GetIndices(out firstIndex, out secondIndex, filter);

            var size = bitmap.Size;

            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Environment.ProcessorCount;

            unsafe
            {
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                Parallel.For(0, size.Height, options, y =>
                {
                    //получить адрес строки
                    var ptr = startPtr  + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        ptr[firstIndex] = 0;
                        ptr[secondIndex] = 0;
                    }

                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        private static void GetIndices(out int firstIndex, out int secondIndex, Filter filter)
        {
            switch (filter)
            {
                case Filter.RED:
                    {
                        firstIndex = 0;
                        secondIndex = 1;
                        break;
                    }

                case Filter.GREEN:
                    {
                        firstIndex = 0;
                        secondIndex = 2;
                        break;
                    }

                case Filter.BLUE:
                    {
                        firstIndex = 1;
                        secondIndex = 2;
                        break;
                    }
                default:
                    {
                        firstIndex = 0;
                        secondIndex = 1;
                        break;
                    }
            }
        }

        public static Bitmap BinaryImage(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                                                           ImageLockMode.ReadWrite, 
                                                           PixelFormat.Format24bppRgb);

            var brightness = 0.0;


            var size = bitmap.Size;

            

            unsafe
            {

                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;

                //получить указатель на начало изображения
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                var bag = new ConcurrentBag<double>();

                //взять N частичных сумм
                Parallel.For<double>(0, size.Height, options, () => 0.0, (y, state, subtotal) =>
                {
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        subtotal += 0.299 * ptr[2] + 0.587 * ptr[1] + 0.114 * ptr[0]; 
                    }

                    return subtotal;
                },
                (x) => bag.Add(x));

                //получить общую сумму, затем получить среднее значение яркости изображения
                var average =  bag.Sum() / (size.Width * size.Height);


   

                Parallel.For(0, size.Height, options, y =>
                {
                    //получить адрес строки
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        brightness = 0.299 * ptr[2] + 0.587 * ptr[1] + 0.114 * ptr[0];

                        //если яркость больше средней 
                        //назначить белый
                        if (brightness >= average)
                        {
                            ptr[0] = ptr[1] = ptr[2] = 255;
                        }
                        //иначен назначить черный
                        else
                        {
                            ptr[0] = ptr[1] = ptr[2] = 0;
                        }
                    }
                });
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
