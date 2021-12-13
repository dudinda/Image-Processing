using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.DistributionArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Distribution;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

using static ImageProcessing.App.PresentationLayer.Code.Enums.ImageContainer;
using static ImageProcessing.App.ServiceLayer.Code.Enums.RndFunction;
using static ImageProcessing.App.ServiceLayer.Code.Enums.RndInfo;

namespace ImageProcessing.App.UILayer.FormEventBinders.Distribution.Implementation
{
    internal sealed class DistributionFormEventBinder : IDistributionFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public DistributionFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }
        public void OnElementExpose(IDistributionFormExposer source)
        {
            source.ShuffleButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShuffleEventArgs());

            source.PmfButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new BuildRandomVariableFunctionEventArgs(PMF, Source));

            source.CdfButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new BuildRandomVariableFunctionEventArgs(CDF, Source));

            source.ExpectactionButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new GetRandomVariableInfoEventArgs(Expectation, Source));

            source.VarianceButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new GetRandomVariableInfoEventArgs(Variance, Source));

            source.DeviationButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new GetRandomVariableInfoEventArgs(StandardDeviation, Source));

            source.EntropyButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new GetRandomVariableInfoEventArgs(Entropy, Source));

            source.QualityButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowQualityMeasureMenuEventArgs());

            source.ApplyTransformButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new TransformHistogramEventArgs(source.Parameters));

            source.FormClosed += (sender, args)
                => _aggregator.PublishFrom(source, new FormIsClosedEventArgs());
        }

        public bool ProcessCmdKey(IDistributionFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Q):

                    _aggregator.PublishFrom(view, new BuildRandomVariableFunctionEventArgs(PMF, Source));
                    return true;

                case (Keys.Q | Keys.Control):

                    _aggregator.PublishFrom(view, new BuildRandomVariableFunctionEventArgs(PMF, Destination));
                    return true;

                case (Keys.W):

                    _aggregator.PublishFrom(view, new BuildRandomVariableFunctionEventArgs(CDF, Source));
                    return true;

                case (Keys.W | Keys.Control):

                    _aggregator.PublishFrom(view, new BuildRandomVariableFunctionEventArgs(CDF, Destination));
                    return true;
            }

            return false;
        }
    }
}
