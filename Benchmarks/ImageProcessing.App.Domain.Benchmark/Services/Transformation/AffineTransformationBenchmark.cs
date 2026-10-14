using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.Domain.Models.Transformation.Implementation;

namespace ImageProcessing.App.Domain.Benchmark.Rotation.AreaMapping
{
    [SimpleJob(launchCount: 3, warmupCount: 10, iterationCount: 20)]
    public class AffineTransformationBenchmark
    {
        private TranslationTransformation _transformation = new();

        private Bitmap _frame2560x1440;

        private double _tx = 30;
        private double _ty = 30;


        private int _frameRate = 60;

        [GlobalSetup]
        public void Setup()
        {

            using (var ms = new MemoryStream(Frames.Frames._2560x1440frame))
            {
                _frame2560x1440 = new Bitmap(Image.FromStream(ms));
            }
        }

        [Benchmark]
        public void GraphicsTransformTo2560x1440Frame()
        {
            using var graphics = Graphics.FromImage(_frame2560x1440);
            graphics.Clear(Color.White);
            graphics.TranslateTransform((int)_tx, (int)_ty);
        }

        [Benchmark]
        public void GraphicsTransformTo2560x1440Frame60Fps()
        {
            using var graphics = Graphics.FromImage(_frame2560x1440);
            for (var start = 0; start < _frameRate; ++start)
            {
                graphics.Clear(Color.White);
                graphics.TranslateTransform((int)_tx, (int)_ty);
            }
        }

        [Benchmark]
        public void TransformTo2560x1440Frame()
        {
            _transformation.Transform(_frame2560x1440, _tx, _ty);
        }

        [Benchmark]
        public void Transform2560x1440Frame60Fps()
        {
            for (var start = 0; start < _frameRate; ++start)
            {
                _transformation.Transform(_frame2560x1440, _tx, _ty);
            }
        }

        [GlobalCleanup]
        public void Dispose()
        {
            _frame2560x1440.Dispose();
        }
    }
}
