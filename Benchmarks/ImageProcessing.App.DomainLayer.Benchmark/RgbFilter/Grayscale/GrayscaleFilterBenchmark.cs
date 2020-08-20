using System;
using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Implementation.Grayscale;
using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Interface;

namespace ImageProcessing.App.DomainLayer.Benchmark.RgbFilter.Grayscale
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    public class GrayscaleFilterBenchmark : IDisposable
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
        public Bitmap ApplyGrayscaleFilterTo1920x1080Frame()
            => filter.Filter(_frame1920x1080);

        [Benchmark]
        public void ApplyGrayscaleFilterTo1920x1080Frame60Fps()
        {
            for (var start = 0; start < frameRate; ++start)
            {
                filter.Filter(_frame1920x1080);
            }
        }

        [Benchmark]
        public Bitmap ApplyGrayscaleFilterTo2560x1440Frame()
            => filter.Filter(_frame2560x1440);

        [Benchmark]
        public void ApplyGrayscaleFilterTo2560x1440Frame60Fps()
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
