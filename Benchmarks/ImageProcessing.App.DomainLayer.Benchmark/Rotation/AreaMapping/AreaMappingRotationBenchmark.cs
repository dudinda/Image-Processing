using System;
using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;

namespace ImageProcessing.App.DomainLayer.Benchmark.Rotation.AreaMapping
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    public class AreaMappingRotationBenchmark
    {
        private AreaMappingRotation rotation = new AreaMappingRotation();

        private Bitmap _frame1920x1080;
        private Bitmap _frame2560x1440;

        private double _45degreesToRad = 45 * Math.PI / 180;

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
        public Bitmap Rotate45Degrees1920x1080Frame()
            => rotation.Rotate(_frame1920x1080, _45degreesToRad);

        [Benchmark]
        public void ApplyColorFilterTo1920x1080Frame60Fps()
        {
            for (var start = 0; start < frameRate; ++start)
            {
                rotation.Rotate(_frame1920x1080, _45degreesToRad);
            }
        }

        [Benchmark]
        public Bitmap ApplyColorFilterTo2560x1440Frame()
          => rotation.Rotate(_frame2560x1440, _45degreesToRad);

        [Benchmark]
        public void ApplyColorFilterTo2560x1440Frame60Fps()
        {
            for (var start = 0; start < frameRate; ++start)
            {
                rotation.Rotate(_frame2560x1440, _45degreesToRad);
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
