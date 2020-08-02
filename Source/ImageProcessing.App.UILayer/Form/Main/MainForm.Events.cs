using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Show;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ToolbarArgs;
using ImageProcessing.App.DomainLayer.DomainEvents.QualityMeasureArgs;

namespace ImageProcessing.App.UILayer.Form.Main
{
    internal sealed partial class MainForm
    {
        /// <summary>
        /// Publish the main window event handlers
        /// </summary>
        private void Bind()
        {
            BindFileMenu();
            BindToolbar();
            BindConvolutionFilters();
            BindDistributions();
        }

        /// <summary>
        /// Publish event handlers for a file menu
        /// </summary>
        private void BindFileMenu()
        {
           
            FormClosing += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new CloseFormEventArgs()
                );
        }

        /// <summary>
        /// Publish event handlers for a toolbar menu
        /// </summary>
        private void BindToolbar()
        {
            ShuffleSrc.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new ShuffleEventArgs()
                );

            PMF.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RandomVariableFunctionEventArgs(
                        RandomVariableFunction.PMF, ImageContainer.Source
                    )
                );

            CDF.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RandomVariableFunctionEventArgs(
                        RandomVariableFunction.CDF, ImageContainer.Source
                    )
                );

            Expectation.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RandomVariableInfoEventArgs(
                        RandomVariableInfo.Expectation, ImageContainer.Source
                    )
                );

            Variance.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RandomVariableInfoEventArgs(
                        RandomVariableInfo.Variance, ImageContainer.Source
                    )
                );

            StandardDeviation.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RandomVariableInfoEventArgs(
                        RandomVariableInfo.StandardDeviation, ImageContainer.Source
                    )
                );

            Entropy.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RandomVariableInfoEventArgs(
                        RandomVariableInfo.Entropy, ImageContainer.Source
                    )
                );

            
            QualityMeasure.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new ShowQualityMeasureEventArgs()
                );

            RgbMenu.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new ShowRgbFiltersEventArgs()
                );
        }

        /// <summary>
        /// Publish event handlers for a convolution menu
        /// </summary>
        private void BindConvolutionFilters()
        {
            ConvolutionFiltersMenu.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new ShowConvolutionFilterPresenterEventArgs()
                );
        }

     
        /// <summary>
        /// Publish event handlers for a histogram transformation menu
        /// </summary>
        private void BindDistributions()
        {
            ExponentialDistribution.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new DistributionEventArgs(
                        Distribution.Exponential, Parameters
                    )
                );

            ParabolaDistribution.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new DistributionEventArgs(
                        Distribution.Parabola, Parameters
                    )
                );

            RayleighDistribution.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new DistributionEventArgs(
                        Distribution.Rayleigh, Parameters
                    )
                );

            CauchyDistribution.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new DistributionEventArgs(
                        Distribution.Cauchy, Parameters
                    )
                );

            LaplaceDistribution.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new DistributionEventArgs(
                        Distribution.Laplace, Parameters
                    )
                );

            NormalDistribution.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new DistributionEventArgs(
                        Distribution.Normal, Parameters
                    )
                );

            UniformDistribution.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new DistributionEventArgs(
                        Distribution.Uniform, Parameters
                    )
                );

            WeibullDistribution.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new DistributionEventArgs(
                        Distribution.Weibull, Parameters
                    )
                );
        }

        /// <summary>
        /// Provides the binder for tool strip buttons and zoom trackbars
        /// </summary>
        /// <param name="msg">A Windows message</param>
        /// <param name="keyData">The pressed key</param>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(_binder.ProcessCmdKey(this, keyData))
            {
                return true; 
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
   }
}
