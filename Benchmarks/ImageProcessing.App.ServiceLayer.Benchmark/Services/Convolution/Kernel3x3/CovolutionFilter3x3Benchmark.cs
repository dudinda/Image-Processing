using System;
using System.Drawing;
using System.IO;

using BenchmarkDotNet.Attributes;

using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Implemetation.Blur.BoxBlur;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Services.Convolution.Implementation;
using ImageProcessing.App.ServiceLayer.Services.ConvolutionFilterServices.Interface;

namespace ImageProcessing.App.ServiceLayer.Benchmark.Services.Convolution.Kernel3x3
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    public class CovolutionFilter5x5Benchmark : IDisposable
    {
        private IConvolutionKernel filter3x3 = new BoxBlur3x3();
        private IConvolutionService service = new ConvolutionService();

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
        public Bitmap Apply3x3ConvolutionTo1920x1080()
            => service.Convolution(_frame1920x1080, filter3x3);

        [Benchmark]
        public void Apply3x3ConvoltuionTo1920x1080Frame60Fps()
        {
            for (var start = 0; start < frameRate; ++start)
            {
                service.Convolution(_frame1920x1080, filter3x3);
            }
        }

        [Benchmark]
        public Bitmap Apply3x3ConvolutionTo2560x1440()
            => service.Convolution(_frame2560x1440, filter3x3);

        [Benchmark]
        public void Apply3x3ConvolutionTo2560x1440Frame60Fps()
        {
            for (var start = 0; start < frameRate; ++start)
            {
                service.Convolution(_frame2560x1440, filter3x3);
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
