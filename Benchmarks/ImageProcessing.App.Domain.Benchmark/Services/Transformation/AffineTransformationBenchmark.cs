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
        public Bitmap GraphicsTransformTo2560x1440Frame()
        {
            var bmp = new Bitmap(_frame2560x1440.Width, _frame2560x1440.Height);
            using var graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            graphics.TranslateTransform((int)_tx, (int)_ty);
            graphics.DrawImageUnscaled(_frame2560x1440, 0, 0);
            return bmp;
        }

        [Benchmark]
        public Bitmap TransformTo2560x1440Frame()
        {
            return _transformation.Transform(_frame2560x1440, _tx, _ty);
        }

        [GlobalCleanup]
        public void Dispose()
        {
            _frame2560x1440.Dispose();
        }
    }
}
