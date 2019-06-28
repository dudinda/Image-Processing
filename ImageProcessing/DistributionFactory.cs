using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    public static class DistributionFactory
    {

        private static  Dictionary<string, Func<double, double, double>> oneParamQuantile = new Dictionary<string, Func<double, double, double>>()
        {
            { "Exponential", (f, param) => (-Math.Log(1 - f)/param) },
            { "Rayleigh", (f, param) => param * (Math.Sqrt(-2 * Math.Log(1 - f))) }
        };

        private static Func<double, double, double> oneParameterDistribution = null;

        private static Dictionary<string, Func<double, double, double, double>> twoParamQuantile = new Dictionary<string, Func<double, double, double, double>>()
        {
            { "Uniform", (f, firstParam, secondParam) => firstParam + f * (secondParam - firstParam) },
            { "Cauchy", (f, firstParam, secondParam) => firstParam + secondParam * Math.Tan(Math.PI * (f - 0.5))},
            { "Weibull", (f, firstParam, secondParam) => firstParam * Math.Pow(-Math.Log(1 - f), 1.0 / secondParam)} 
        };

        private static Func<double, double, double, double> twoParameterDistribution = null;


        public static Bitmap TwoParameterDistribution(this Bitmap bitmap, string distribution, double firstParam, double secondParam)
        {
            var frequencies = GetFrequencies(bitmap);

            var pmf         = GetPMF(frequencies, bitmap.Width * bitmap.Height);

            var cdf         = GetCDF(pmf);

            twoParameterDistribution = twoParamQuantile[distribution];

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                            ImageLockMode.ReadWrite,
                                            PixelFormat.Format24bppRgb);

            unsafe
            {
                var ptr = (byte*)bitmapData.Scan0.ToPointer();

                var nOffset = bitmapData.Stride - bitmap.Width * 3;

                for (int y = 0; y < bitmap.Height; ++y, ptr += nOffset)
                {
                    for (int x = 0; x < bitmap.Width; ++x, ptr += 3)
                    {
                        var newPixel = (byte) twoParameterDistribution(cdf[ptr[0]], firstParam, secondParam);

                        ptr[0] = ptr[1] = ptr[2] = newPixel;
                    }
                }
            }
          
            bitmap.UnlockBits(bitmapData);

            return bitmap;

        }

        public static Bitmap OneParameterDistribution(this Bitmap bitmap, string distribution, double param)
        {
            var frequencies = GetFrequencies(bitmap);

            var pmf = GetPMF(frequencies, bitmap.Width * bitmap.Height);

            var cdf = GetCDF(pmf);

            oneParameterDistribution = oneParamQuantile[distribution];

           var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                            ImageLockMode.ReadWrite,
                                            PixelFormat.Format24bppRgb);

            unsafe
            {
                var ptr = (byte*)bitmapData.Scan0.ToPointer();

                var nOffset = bitmapData.Stride - bitmap.Width * 3;

                for (int y = 0; y < bitmap.Height; ++y, ptr += nOffset)
                {
                    for (int x = 0; x < bitmap.Width; ++x, ptr += 3)
                    {
                        var newPixel = (byte)oneParameterDistribution(cdf[ptr[0]], param);

                        ptr[0] = ptr[1] = ptr[2] = newPixel;
                    }
                }
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;

        }

        public static int[] GetFrequencies(Bitmap bitmap)
        {
            var frequencies = new int[256];

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                                             ImageLockMode.ReadWrite,
                                             PixelFormat.Format24bppRgb);

            unsafe
            {
                var ptr = (byte*)bitmapData.Scan0.ToPointer();

                var nOffset = bitmapData.Stride - bitmap.Width * 3;

                for (int y = 0; y < bitmap.Height; ++y, ptr += nOffset)
                {
                    for (int x = 0; x < bitmap.Width; ++x, ptr += 3)
                    {
                        frequencies[ptr[0]]++;
                    }
                }
            }

            bitmap.UnlockBits(bitmapData);

            return frequencies;
        }

        private static double[] GetCDF(double[] pmf)
        {
            var cdf = pmf.Clone() as double[];

            for(int x = 1; x < cdf.Length; ++x)
            {
                cdf[x] += cdf[x - 1];
            }

            return cdf;
        }

        private static double[] GetPMF(int[] frequencies, double resolution)
        {
            var pmf = frequencies.Select(value => (double)value).ToArray();

            for(int x = 0; x < frequencies.Length; ++x)
            {
                pmf[x] /= resolution;
            }

            return pmf;
        }
    
    }

}

