using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ToolbarArgs;
using ImageProcessing.App.DomainLayer.DomainEvents.QualityMeasureArgs;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Distribution;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.Distribution.Implementation
{
    internal class DistributionFormEventBinder : IDistributionFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public DistributionFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }
        public void OnElementExpose(IDistributionFormExposer source)
        {
            source.ShuffleButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ShuffleEventArgs(source)
                );

            source.PmfButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new BuildRandomVariableFunctionEventArgs(
                        RandomVariableFunction.PMF, ImageContainer.Source
                    )
                );

            source.CdfButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new BuildRandomVariableFunctionEventArgs(
                        RandomVariableFunction.CDF, ImageContainer.Source
                    )
                );

            source.ExpectactionButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new GetRandomVariableInfoEventArgs(
                        RandomVariableInfo.Expectation, ImageContainer.Source
                    )
                );

            source.VarianceButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new GetRandomVariableInfoEventArgs(
                        RandomVariableInfo.Variance, ImageContainer.Source
                    )
                );

            source.DeviationButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new GetRandomVariableInfoEventArgs(
                        RandomVariableInfo.StandardDeviation, ImageContainer.Source
                    )
                );

            source.EntropyButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new GetRandomVariableInfoEventArgs(
                        RandomVariableInfo.Entropy, ImageContainer.Source
                    )
                );

            source.QualityButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ShowQualityMeasureMenuEventArgs()
                );

            source.ApplyTransformButton.Click += (sender, args)
               => _aggregator.PublishFrom(source,
                   new TransformHistogramEventArgs(source,
                       source.Parameters
                    )
               );
        }

        public bool ProcessCmdKey(IDistributionFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Q):

                    _aggregator.PublishFrom(view,
                        new BuildRandomVariableFunctionEventArgs(
                            RandomVariableFunction.PMF, ImageContainer.Source
                        )
                    );

                    return true;
                case (Keys.Q | Keys.Control):

                    _aggregator.PublishFrom(view,
                        new BuildRandomVariableFunctionEventArgs(
                            RandomVariableFunction.PMF, ImageContainer.Destination
                        )
                    );

                    return true;
                case (Keys.W):

                    _aggregator.PublishFrom(view,
                        new BuildRandomVariableFunctionEventArgs(
                            RandomVariableFunction.CDF, ImageContainer.Source
                        )
                    );

                    return true;
                case (Keys.W | Keys.Control):

                    _aggregator.PublishFrom(view,
                        new BuildRandomVariableFunctionEventArgs(
                            RandomVariableFunction.CDF, ImageContainer.Destination
                        )
                    );

                    return true;
            }

            return false;
        }
    }
}
