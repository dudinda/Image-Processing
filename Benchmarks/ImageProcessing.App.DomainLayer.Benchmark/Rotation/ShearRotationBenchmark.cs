
using System;
using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Implementation;

namespace ImageProcessing.App.DomainLayer.Benchmark.Rotation.Shear
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    public class ShearRotationBenchmark
    {
        private ShearRotation _rotation = new ShearRotation();

        private Bitmap _frame1920x1080;
        private Bitmap _frame2560x1440;

        private double _45degreesToRad = 45 * Math.PI / 180;

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
            => _rotation.Rotate(_frame1920x1080, _45degreesToRad);

        [Benchmark]
        public void Rotate45Degrees1920x1080Frame60Fps()
        {
            for (var start = 0; start < _frameRate; ++start)
            {
                _rotation.Rotate(_frame1920x1080, _45degreesToRad);
            }
        }

        [Benchmark]
        public Bitmap Rotate45Degrees2560x1440Frame()
          => _rotation.Rotate(_frame2560x1440, _45degreesToRad);

        [Benchmark]
        public void Rotate45Degrees2560x1440Frame60Fps()
        {
            for (var start = 0; start < _frameRate; ++start)
            {
                _rotation.Rotate(_frame2560x1440, _45degreesToRad);
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
