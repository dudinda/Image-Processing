using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.Domain.Models.Scaling.Implementation;

namespace ImageProcessing.App.Domain.Benchmark.Rotation.AreaMapping
{
    [SimpleJob(launchCount: 3, warmupCount: 10, iterationCount: 30)]
    public class BilinearInterpolationBenchmark
    {
        private BilinearInterpolation _scaling = new();

        private Bitmap _frame1920x1080;
        private Bitmap _frame2560x1440;

        private double _scaleX = 2;
        private double _scaleY = 2;

        private float _scaleXGraphics;
        private float _scaleYGraphics;

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

            _scaleXGraphics = (float)(_scaleX);
            _scaleYGraphics = (float)(_scaleY);
        }

        [Benchmark]
        public Bitmap SystemGraphicsResize1920x1080Frame()
        {
            var bmp = new Bitmap(_frame2560x1440.Width, _frame2560x1440.Height);
            using var graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            graphics.ScaleTransform(_scaleXGraphics, _scaleYGraphics);
            graphics.DrawImageUnscaled(_frame2560x1440, 0, 0);
            return bmp;
        }


        [Benchmark]
        public Bitmap Resize1920x1080Frame()
        {
            return _scaling.Resize(_frame1920x1080, _scaleX, _scaleY);
        }

        [Benchmark]
        public Bitmap SystemGraphicsResize2560x1440Frame()
        {
            var bmp = new Bitmap(_frame2560x1440.Width, _frame2560x1440.Height);
            using var graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            graphics.ScaleTransform(_scaleXGraphics, _scaleYGraphics);
            graphics.DrawImageUnscaled(_frame2560x1440, 0, 0);
            return bmp;
        }

        [Benchmark]
        public Bitmap Resize2560x1440Frame()
        {
            return _scaling.Resize(_frame2560x1440, _scaleX, _scaleY);
        }

        [GlobalCleanup]
        public void Dispose()
        {
            _frame1920x1080.Dispose();
            _frame2560x1440.Dispose();
        }
    }
}
