using System;
using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Grayscale;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.DomainModel.Benchmark.RgbFilter.Grayscale
{
    internal sealed class GrayscaleFilterBenchmark : IDisposable
    {
        private IRgbFilter filter = new GrayscaleFilter();

        private Bitmap _frame1920x1080;
        private Bitmap _frame2560x1440;

        private int frameRate = 60;

        [GlobalSetup]
        public void Setup()
        {
            using (var ms = new MemoryStream(Frames.Frames._1920x1080frame))
            {
                _frame1920x1080 = new Bitmap(Image.FromStream(ms));
            }

            using (var ms = new MemoryStream(Frames.Frames._2560x1440frame))
            {
                _frame2560x1440 = new Bitmap(Image.FromStream(ms));
            }

        }

        [Benchmark]
        public void ApplyBinaryFilterTo1920x1080Frame60Fps()
        {
            for (var start = 0; start < frameRate; ++start)
            {
                filter.Filter(_frame1920x1080);
            }
        }

        [Benchmark]
        public void ApplyBinaryFilterTo2560x1440Frame60Fps()
        {
            for (var start = 0; start < frameRate; ++start)
            {
                filter.Filter(_frame2560x1440);
            }
        }

        [GlobalCleanup]
        public void Dispose()
        {
            _frame1920x1080.Dispose();
            _frame2560x1440.Dispose();
        }
    }
}
