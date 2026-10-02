using System;
using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.Domain.Models.Convolution.Implementation.Blur.GaussianBlur;
using ImageProcessing.App.Domain.Models.Convolution;
using ImageProcessing.App.Domain.Services.Convolution;
using ImageProcessing.App.Domain.Services.Convolution.Implementation;

namespace ImageProcessing.App.Domain.Benchmark.Services.Convolution.Kernel5x5
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    public class CovolutionFilter5x5Benchmark : IDisposable
    {
        private IConvolutionKernel _filter5x5 = new GaussianBlur5x5();
        private IConvolutionService _service = new ConvolutionService();

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
        public Bitmap Apply5x5ConvolutionTo1920x1080()
            => _service.Convolution(_frame1920x1080, _filter5x5);

        [Benchmark]
        public void Apply5x5ConvoltuionTo1920x1080Frame60Fps()
        {
            for (var start = 0; start < _frameRate; ++start)
            {
                _service.Convolution(_frame1920x1080, _filter5x5);
            }
        }

        [Benchmark]
        public Bitmap Apply5x5ConvolutionTo2560x1440()
            => _service.Convolution(_frame2560x1440, _filter5x5);

        [Benchmark]
        public void Apply5x5ConvolutionTo2560x1440Frame60Fps()
        {
            for (var start = 0; start < _frameRate; ++start)
            {
                _service.Convolution(_frame2560x1440, _filter5x5);
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
