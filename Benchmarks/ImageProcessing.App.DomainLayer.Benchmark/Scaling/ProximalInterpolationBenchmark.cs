using System;
using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Implementation;

namespace ImageProcessing.App.DomainLayer.Benchmark.Rotation.AreaMapping
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    public class ProximalInterpolationBenchmark
    {
        private ProximalInterpolation _scaling = new ProximalInterpolation();

        private Bitmap _frame1920x1080;
        private Bitmap _frame2560x1440;

        private double _scaleX = 2;
        private double _scaleY = 2;

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
        public Bitmap Rotate45Degrees1920x1080Frame()
            => _scaling.Resize(_frame1920x1080, _scaleX, _scaleY);

        [Benchmark]
        public void ApplyColorFilterTo1920x1080Frame60Fps()
        {
            for (var start = 0; start < _frameRate; ++start)
            {
                _scaling.Resize(_frame1920x1080, _scaleX, _scaleY);
            }
        }

        [Benchmark]
        public Bitmap ApplyColorFilterTo2560x1440Frame()
          => _scaling.Resize(_frame2560x1440, _scaleX, _scaleY);

        [Benchmark]
        public void ApplyColorFilterTo2560x1440Frame60Fps()
        {
            for (var start = 0; start < _frameRate; ++start)
            {
                _scaling.Resize(_frame2560x1440, _scaleX, _scaleY);
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
