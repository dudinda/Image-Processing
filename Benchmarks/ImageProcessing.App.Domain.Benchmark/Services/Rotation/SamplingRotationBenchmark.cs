using System;
using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.Domain.Models.Rotation.Implementation;

namespace ImageProcessing.App.Domain.Benchmark.Rotation.Sampling
{
    [SimpleJob(launchCount: 3, warmupCount: 10, iterationCount: 30)]
    public class SamplingRotationBenchmark
    {
        private SamplingRotation _rotation = new();

        private Bitmap _frame1920x1080;
        private Bitmap _frame2560x1440;

        private double _45degreesToRad = 45 * Math.PI / 180;
        private float _45degrees = 45f;


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
        public Bitmap GraphicsRotate45Degrees1920x1080Frame()
        {
            var bmp = new Bitmap(_frame1920x1080.Width, _frame1920x1080.Height);
            using var graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            graphics.RotateTransform(_45degrees);
            graphics.DrawImageUnscaled(_frame1920x1080, 0, 0);
            return bmp;
        }

        [Benchmark]
        public Bitmap Rotate45Degrees1920x1080Frame()
        {
            return _rotation.Rotate(_frame1920x1080, _45degreesToRad);
        }

        [Benchmark]
        public Bitmap GraphicsRotate45Degrees2560x1440Frame()
        {
            var bmp = new Bitmap(_frame2560x1440.Width, _frame2560x1440.Height);
            using var graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            graphics.RotateTransform(_45degrees);
            graphics.DrawImageUnscaled(_frame2560x1440, 0, 0);
            return bmp;
        }

        [Benchmark]
        public Bitmap Rotate45Degrees2560x1440Frame()
        {
            return _rotation.Rotate(_frame2560x1440, _45degreesToRad);
        }


        [GlobalCleanup]
        public void Dispose()
        {
            _frame1920x1080.Dispose();
            _frame2560x1440.Dispose();
        }
    }
}
