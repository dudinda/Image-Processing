using System.Collections.Generic;
using System.Drawing;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.DomainLayer.Factory.Distributions.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.BitmapDistribution
{
    /// <inheritdoc cref="IBitmapLuminanceDistributionServiceProvider"/>
    public sealed class BitmapLuminanceDistributionServiceProvider
        : IBitmapLuminanceDistributionServiceProvider
    {
        private static readonly Dictionary<string, CommandAttribute>
            _command = typeof(BitmapLuminanceDistributionServiceProvider).GetCommands();

        private readonly IBitmapLuminanceDistributionService _service;
        private readonly IDistributionFactory _factory;

        public BitmapLuminanceDistributionServiceProvider
            (IBitmapLuminanceDistributionService service,
             IDistributionFactory factory)
        {
            _service = service;
            _factory = factory;
        }

        /// <inheritdoc/>
        public Bitmap Transform(Bitmap bmp, Distributions distribution, (string, string) parms)
            =>  _service.Transform(bmp,
                    _factory.Get(distribution)
                            .SetParams(parms)
            );

        /// <inheritdoc/>
        public decimal GetInfo(Bitmap bmp, RandomVariableInfo info)
            => (decimal)_command[
                info.ToString()
            ].Method.Invoke(this, new object[] { bmp });
        
        [Command(nameof(RandomVariableInfo.Expectation))]
        private decimal GetExpectationCommand(Bitmap bmp)
            => _service.GetExpectation(bmp);

        [Command(nameof(RandomVariableInfo.Variance))]
        private decimal GetVarianceCommand(Bitmap bmp)
               => _service.GetVariance(bmp);

        [Command(nameof(RandomVariableInfo.Entropy))]
        private decimal GetEntropyCommand(Bitmap bmp)
              => _service.GetEntropy(bmp);

        [Command(nameof(RandomVariableInfo.StandardDeviation))]
        private decimal GetStandardDeviationCommand(Bitmap bmp)
              => _service.GetStandardDeviation(bmp);
    }
}
