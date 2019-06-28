using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using ImageProcessing.Distributions.Abstract;
using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using ImageProcessing.Distributions.Two___Parameter_Distributions;
using ImageProcessing.Distributions.One___Parameter_Distributions;

namespace ImageProcessing
{
    //ptr[0] - B, ptr[1] - G, ptr[2] - R
    public static class DistributionContext
    {

        public static Bitmap Distribute(this Bitmap bitmap, IDistribution distribution)
        {
            //получить частоты 
            var frequencies = GetFrequencies(bitmap);

            //получить дифференциальную функцию распределения
            var pmf         = GetPMF(frequencies, bitmap.Width * bitmap.Height);

            //получить интегральную функцию распределения
            var cdf         = GetCDF(pmf);


            //получить новые значения пикселей, в соответствии с выбранным распределением
            var newPixels = Transform(cdf, distribution);


            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                            ImageLockMode.ReadWrite,
                                            PixelFormat.Format32bppRgb);

            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Environment.ProcessorCount;


            var size = bitmap.Size;

            unsafe
            { 
                Parallel.For(0, size.Height, options, y =>
                {
                    //получить адрес строки
                    var ptr = (byte*)bitmapData.Scan0.ToPointer() + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 4)
                    {
                        //получить значение пикселя из преобразованного квантильной функций массива значений
                        ptr[0] = ptr[1] = ptr[2] = newPixels[ptr[0]];
                    }
                });
            }
          
            bitmap.UnlockBits(bitmapData);

            return bitmap;

        }

        public static double GetExpectation(double[] pmf)
        {
            var total = 0.0;

            for(var i = 0; i < 256; ++i)
            {
                total += pmf[i] * i;
            }

            return total;
        }

        public static double GetExpectation(Bitmap bitmap)
        {
            var frequencies = GetFrequencies(bitmap);
            var pmf = GetPMF(frequencies, bitmap.Width * bitmap.Height);

            return GetExpectation(pmf);
        }

        public static double GetVariance(double[] pmf)
        {
            var total = 0.0;
            var mean = GetExpectation(pmf);

            for (var i = 0; i < 256; ++i)
            {
                total += pmf[i] * (i - mean) * (i - mean);
            }

            return total;
        }

        public static double GetVariance(Bitmap bitmap)
        {
            var frequencies = GetFrequencies(bitmap);
            var pmf = GetPMF(frequencies, bitmap.Width * bitmap.Height);

            return GetVariance(pmf);
        }

        public static double GetStandardDeviation(double[] pmf)
        {
            return Math.Sqrt(GetVariance(pmf));
        }

        public static double GetStandardDeviation(Bitmap bitmap)
        {
            var frequencies = GetFrequencies(bitmap);
            var pmf = GetPMF(frequencies, bitmap.Width * bitmap.Height);

            return Math.Sqrt(GetVariance(pmf));
        }

        public static double GetConditionalExpectation(int x1, int x2, double[] pmf)
        {
            var uvalue = 0.0;
            var lvalue = 0.0;
           
            for(var i = x1; i <= x2; ++i)
            {
                uvalue += (i * pmf[i]);
                lvalue += pmf[i];
            }

            return uvalue / lvalue;
        }

        public static double GetConditionalVariance(int x1, int x2, double[] frequencies)
        {
            var mean = GetConditionalExpectation(x1, x2, frequencies);

            var uvalue = 0.0;
            var lvalue = 0.0;
            
            for(var i = x1; i <= x2; ++i)
            {

                uvalue += frequencies[i] * ((i - mean) * (i - mean));
                lvalue += frequencies[i];
            }

            return uvalue / lvalue;
        }


        public static int[] GetFrequencies(Bitmap bitmap)
        {
           

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                                             ImageLockMode.ReadWrite,
                                             PixelFormat.Format24bppRgb);

            var frequencies = new int[256];

            unsafe
            {

                var size = bitmap.Size;

                var options = new ParallelOptions();
                options.MaxDegreeOfParallelism = Environment.ProcessorCount;
 
                var startPtr = (byte*)bitmapData.Scan0.ToPointer();

                var bag = new ConcurrentBag<int[]>();

                //взять N частичных массивов частот
                Parallel.For<int[]>(0, size.Height, options, () => new int[256], (y, state, subarray) =>
                {
                    //получить адрес строки
                    var ptr = startPtr + y * bitmapData.Stride;

                    for (int x = 0; x < size.Width; ++x, ptr += 3)
                    {
                        subarray[ptr[0]]++;
                    }

                    return subarray;
                },
                (part) => bag.Add(part));

                //получить суммарные частоты
                foreach (var subarray in bag)
                {
                    for (int i = 0; i < 256; ++i)
                    {
                        frequencies[i] += subarray[i];
                    }
                }         
            }


            bitmap.UnlockBits(bitmapData);

            return frequencies;
        }

        //построить интегральную функцию распределения
        public static double[] GetCDF(double[] pmf)
        {
            var cdf = pmf.Clone() as double[];

            for(int x = 1; x < cdf.Length; ++x)
            {
                cdf[x] += cdf[x - 1];
            }

            return cdf;
        }

        //построить дифференциальную функцию распределения
        //нормализовав частоты, относительно разрешения изображения
        public static double[] GetPMF(int[] frequencies, double resolution)
        {
            return frequencies.AsParallel().Select(x => (double)x / resolution).ToArray();
        }

        public static double GetEntropy(Bitmap bmp)
        {
            var entropy = 0.0;

            var resolution = bmp.Height * bmp.Width;

            var pmf = GetPMF(GetFrequencies(bmp), resolution);

            for(var index = 0; index < 256; ++index)
            {
                if (pmf[index] > Double.Epsilon)
                {
                    entropy += (pmf[index] * Math.Log(pmf[index], 2));
                }
            }

            return -entropy;
        }


        private static byte[] Transform(double[] cdf, IDistribution distribution)
        {
            var result = new byte[256];

            //преобразовать квантильной функцией массив значений
            //от 0 до 255
            for (int index = 0; index < 256; ++index)
            {
                var pixel = distribution.Quantile(cdf[index]);
                    
                //если значение превышает 255
                if (pixel > 255)
                {
                    pixel = 255;
                }

                //если меньше 0
                if (pixel < 0)
                {
                    pixel = 0;
                }

                //округлить до целого, назначить соответствующий элемент
                result[index] = Convert.ToByte(pixel);
            }

            return result;
        }
    
    }

}

