using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
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
            BindRgbFilters();
            BindDistributions();
        }

        /// <summary>
        /// Publish event handlers for a file menu
        /// </summary>
        private void BindFileMenu()
        {
            OpenFile.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new OpenFileDialogEventArgs()
                );

            SaveFile.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new SaveWithoutFileDialogEventArgs()
                );

            SaveFileAs.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new SaveAsFileDialogEventArgs()
                );
   
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

            ReplaceSrcByDst.Click += (sernder, args)
                => Controller.Aggregator.PublishFromAll(
                    new ImageContainerEventArgs(ImageContainer.Destination)
                );

            ReplaceDstBySrc.Click += (sernder, args)
                => Controller.Aggregator.PublishFromAll(
                    new ImageContainerEventArgs(ImageContainer.Source)
                );

            SrcZoom.MouseWheel += (sender, args)
             => Controller.Aggregator.PublishFromAll(
                 new ZoomEventArgs(ImageContainer.Source)
             );

            SrcZoom.MouseUp += (secnder, args)
                => Controller.Aggregator.PublishFromAll(
                    new ZoomEventArgs(ImageContainer.Source)
                );

            SrcZoom.KeyPress += (secnder, args)
                => Controller.Aggregator.PublishFromAll(
                    new ZoomEventArgs(ImageContainer.Source)
                );

            DstZoom.MouseWheel += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new ZoomEventArgs(ImageContainer.Destination)
                );

            DstZoom.MouseUp += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new ZoomEventArgs(ImageContainer.Destination)
                );

            DstZoom.KeyPress += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new ZoomEventArgs(ImageContainer.Destination)
                );

            QualityMeasure.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new ShowQualityMeasureEventArgs()
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
        /// Publish event handlers for a rgb filters menu
        /// </summary>
        private void BindRgbFilters()
        {
            InversionFilter.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RgbFilterEventArgs(RgbFilter.Inversion)
                );

            BinaryFilter.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RgbFilterEventArgs(RgbFilter.Binary)
                );

            GrayscaleFilter.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RgbFilterEventArgs(RgbFilter.Grayscale)
                );

            ColorFilterBlue.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RgbColorFilterEventArgs(RgbColors.Blue)
                );

            ColorFilterRed.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RgbColorFilterEventArgs(RgbColors.Red)
                );

            ColorFilterGreen.Click += (sender, args)
                => Controller.Aggregator.PublishFromAll(
                    new RgbColorFilterEventArgs(RgbColors.Green)
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
            switch (keyData)
            {
                case (Keys.Right):

                    Controller.Aggregator.PublishFromAll(
                        new ImageContainerEventArgs(ImageContainer.Source)
                    );

                    return true;
                case (Keys.Left):

                    Controller.Aggregator.PublishFromAll(
                        new ImageContainerEventArgs(ImageContainer.Destination)
                    );

                    return true;
                case (Keys.Q):

                    Controller.Aggregator.PublishFromAll(
                        new RandomVariableFunctionEventArgs(
                            RandomVariableFunction.PMF, ImageContainer.Source
                        )
                    );

                    return true;
                case (Keys.Q | Keys.Control):

                    Controller.Aggregator.PublishFromAll(
                        new RandomVariableFunctionEventArgs(
                            RandomVariableFunction.PMF, ImageContainer.Destination
                        )
                    );

                    return true;
                case (Keys.W):

                    Controller.Aggregator.PublishFromAll(
                        new RandomVariableFunctionEventArgs(
                            RandomVariableFunction.CDF, ImageContainer.Source
                        )
                    );

                    return true;
                case (Keys.W | Keys.Control):

                    Controller.Aggregator.PublishFromAll(
                        new RandomVariableFunctionEventArgs(
                            RandomVariableFunction.CDF, ImageContainer.Destination
                        )
                    );

                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
   }
}
