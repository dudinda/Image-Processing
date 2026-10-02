using System;
using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.ServiceLayer.Models.Recommendation.Implementation;
using ImageProcessing.App.ServiceLayer.Models.Rgb.RgbFilter.Implementation;
using ImageProcessing.App.ServiceLayer.Benchmark.Frames;

namespace ImageProcessing.App.ServiceLayer.Benchmark.RgbFilter.Binary
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    public class BinaryFilterBenchmark : IDisposable
    {
        private BinaryFilter _filter = new BinaryFilter(new Rec709());

        private Bitmap _frame1920x1080;
        private Bitmap _frame2560x1440;

        private int _frameRate = 60;

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
        public Bitmap ApplyBinaryFilterTo1920x1080()
            => _filter.Filter(_frame1920x1080);

        [Benchmark]
        public void ApplyBinaryFilterTo1920x1080Frame60Fps()
        {
            for(var start = 0; start < _frameRate; ++start)
            {
                _filter.Filter(_frame1920x1080);
            }
        }

        [Benchmark]
        public Bitmap ApplyBinaryFilterTo2560x1440()
            => _filter.Filter(_frame2560x1440);

        [Benchmark]
        public void ApplyBinaryFilterTo2560x1440Frame60Fps()
        {
            for (var start = 0; start < _frameRate; ++start)
            {
                _filter.Filter(_frame2560x1440);
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
