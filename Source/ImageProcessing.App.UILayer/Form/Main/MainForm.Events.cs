using System.Windows.Forms;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.DomainModel.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainModel.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainModel.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainModel.DomainEvent.RgbArgs;

namespace ImageProcessing.App.UILayer.Form.Main
{
    partial class MainForm
    {
        /// <summary>
        /// Publish the main window event handlers
        /// </summary>
        private void Bind()
        {
            EventAggregator.Subscribe(this);

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
                => EventAggregator.Publish(new FileDialogEventArgs(FileDialogAction.Open));

            SaveFile.Click += (sender, args)
                => EventAggregator.Publish(new FileDialogEventArgs(FileDialogAction.SaveWithoutDialog));

            SaveFileAs.Click += (sender, args)
                => EventAggregator.Publish(new FileDialogEventArgs(FileDialogAction.SaveAs));
   
            FormClosing += (sender, args)
                => EventAggregator.Publish(new CloseFormEventArgs());
        }

        /// <summary>
        /// Publish event handlers for a toolbar menu
        /// </summary>
        private void BindToolbar()
        {
            ShuffleSrc.Click += (sender, args)
                => EventAggregator.Publish(new ToolbarActionEventArgs(ToolbarAction.Shuffle));

            PMF.Click += (sender, args)
                => EventAggregator.Publish(new RandomVariableFunctionEventArgs(RandomVariableFunction.PMF, ImageContainer.Source));

            CDF.Click += (sender, args)
                => EventAggregator.Publish(new RandomVariableFunctionEventArgs(RandomVariableFunction.CDF, ImageContainer.Source));

            Expectation.Click += (sender, args)
                => EventAggregator.Publish(new RandomVariableInfoEventArgs(RandomVariableInfo.Expectation, ImageContainer.Source));

            Variance.Click += (sender, args)
                => EventAggregator.Publish(new RandomVariableInfoEventArgs(RandomVariableInfo.Variance, ImageContainer.Source));

            StandardDeviation.Click += (sender, args)
                => EventAggregator.Publish(new RandomVariableInfoEventArgs(RandomVariableInfo.StandardDeviation, ImageContainer.Source));

            Entropy.Click += (sender, args)
                => EventAggregator.Publish(new RandomVariableInfoEventArgs(RandomVariableInfo.Entropy, ImageContainer.Source));

            ReplaceSrcByDst.Click += (sernder, args)
                => EventAggregator.Publish(new ImageContainerEventArgs(ImageContainer.Destination));

            ReplaceDstBySrc.Click += (sernder, args)
                => EventAggregator.Publish(new ImageContainerEventArgs(ImageContainer.Source));

            SrcZoom.MouseWheel += (sender, args)
             => EventAggregator.Publish(new ZoomEventArgs(ImageContainer.Source));

            SrcZoom.MouseUp += (secnder, args)
                => EventAggregator.Publish(new ZoomEventArgs(ImageContainer.Source));

            SrcZoom.KeyPress += (secnder, args)
                => EventAggregator.Publish(new ZoomEventArgs(ImageContainer.Source));

            DstZoom.MouseWheel += (sender, args)
                => EventAggregator.Publish(new ZoomEventArgs(ImageContainer.Destination));

            DstZoom.MouseUp += (sender, args)
                => EventAggregator.Publish(new ZoomEventArgs(ImageContainer.Destination));

            DstZoom.KeyPress += (sender, args)
                => EventAggregator.Publish(new ZoomEventArgs(ImageContainer.Destination));
        }

        /// <summary>
        /// Publish event handlers for a convolution menu
        /// </summary>
        private void BindConvolutionFilters()
        {
            ConvolutionFiltersMenu.Click += (sender, args)
                => EventAggregator.Publish(new ShowConvolutionFilterPresenterEventArgs());
        }

        /// <summary>
        /// Publish event handlers for a rgb filters menu
        /// </summary>
        private void BindRgbFilters()
        {
            InversionFilter.Click += (sender, args)
                => EventAggregator.Publish(new RgbFilterEventArgs(RgbFilter.Inversion));

            BinaryFilter.Click += (sender, args)
                => EventAggregator.Publish(new RgbFilterEventArgs(RgbFilter.Binary));

            GrayscaleFilter.Click += (sender, args)
                => EventAggregator.Publish(new RgbFilterEventArgs(RgbFilter.Grayscale));

            ColorFilterBlue.Click += (sender, args)
                => EventAggregator.Publish(new RgbColorFilterEventArgs(RgbColors.Blue));

            ColorFilterRed.Click += (sender, args)
                => EventAggregator.Publish(new RgbColorFilterEventArgs(RgbColors.Red));

            ColorFilterGreen.Click += (sender, args)
                => EventAggregator.Publish(new RgbColorFilterEventArgs(RgbColors.Green));
        }

        /// <summary>
        /// Publish event handlers for a histogram transformation menu
        /// </summary>
        private void BindDistributions()
        {
            ExponentialDistribution.Click += (sender, args)
                => EventAggregator.Publish(new DistributionEventArgs(Distribution.Exponential, Parameters));

            ParabolaDistribution.Click += (sender, args)
                => EventAggregator.Publish(new DistributionEventArgs(Distribution.Parabola, Parameters));

            RayleighDistribution.Click += (sender, args)
                => EventAggregator.Publish(new DistributionEventArgs(Distribution.Rayleigh, Parameters));

            CauchyDistribution.Click += (sender, args)
                => EventAggregator.Publish(new DistributionEventArgs(Distribution.Cauchy, Parameters));

            LaplaceDistribution.Click += (sender, args)
                => EventAggregator.Publish(new DistributionEventArgs(Distribution.Laplace, Parameters));

            NormalDistribution.Click += (sender, args)
                => EventAggregator.Publish(new DistributionEventArgs(Distribution.Normal, Parameters));

            UniformDistribution.Click += (sender, args)
                => EventAggregator.Publish(new DistributionEventArgs(Distribution.Uniform, Parameters));

            WeibullDistribution.Click += (sender, args)
                => EventAggregator.Publish(new DistributionEventArgs(Distribution.Weibull, Parameters));
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

                    EventAggregator.Publish(
                        new ImageContainerEventArgs(ImageContainer.Source)
                    );

                    return true;
                case (Keys.Left):

                    EventAggregator.Publish(
                        new ImageContainerEventArgs(ImageContainer.Destination)
                    );

                    return true;
                case (Keys.Q):

                    EventAggregator.Publish(
                        new RandomVariableFunctionEventArgs(
                            RandomVariableFunction.PMF, ImageContainer.Source
                        )
                    );

                    return true;
                case (Keys.Q | Keys.Control):

                    EventAggregator.Publish(
                        new RandomVariableFunctionEventArgs(
                            RandomVariableFunction.PMF, ImageContainer.Destination
                        )
                    );

                    return true;
                case (Keys.W):

                    EventAggregator.Publish(
                        new RandomVariableFunctionEventArgs(
                            RandomVariableFunction.CDF, ImageContainer.Source
                        )
                    );

                    return true;
                case (Keys.W | Keys.Control):

                    EventAggregator.Publish(
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
