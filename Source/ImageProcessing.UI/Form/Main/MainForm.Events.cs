using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Implementation.EventArgs;
using ImageProcessing.Core.EventAggregator.Implementation.EventArgs.Convolution;

namespace ImageProcessing.Form.Main
{
    partial class MainForm
    {
        /// <summary>
        /// Publish the main window event handlers
        /// </summary>
        private void Bind()
        {
            BindFileMenu();
            BindToolbar();
            BindConvolutionFilters();
            BindRGBFilters();
            BindDistributions();
        }

        /// <summary>
        /// Publish event handlers for a file menu
        /// </summary>
        private void BindFileMenu()
        {
            OpenFile.Click += (sender, args)
                => _eventAggregator.Publish(new FileDialogEventArgs(FileDialogAction.Open));

            SaveFile.Click += (sender, args)
                => _eventAggregator.Publish(new FileDialogEventArgs(FileDialogAction.SaveWithoutDialog));

            SaveFileAs.Click += (sender, args)
                => _eventAggregator.Publish(new FileDialogEventArgs(FileDialogAction.SaveAs));
   
            FormClosing += (sender, args)
                => _eventAggregator.Publish(new CloseFormEventArgs());
        }

        /// <summary>
        /// Publish event handlers for a toolbar menu
        /// </summary>
        private void BindToolbar()
        {
            ShuffleSrc.Click += (sender, args)
                => _eventAggregator.Publish(new ToolbarActionEventArgs(ToolbarAction.Shuffle));

            PMF.Click += (sender, args)
                => _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.PMF, ImageContainer.Source));

            CDF.Click += (sender, args)
                => _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.CDF, ImageContainer.Source));

            Expectation.Click += (sender, args)
                => _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.Expectation, ImageContainer.Source));

            Variance.Click += (sender, args)
                => _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.Variance, ImageContainer.Source));

            StandardDeviation.Click += (sender, args)
                => _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.StandardDeviation, ImageContainer.Source));

            Entropy.Click += (sender, args)
                => _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.Entropy, ImageContainer.Source));

            ReplaceSrcByDst.Click += (sernder, args)
                => _eventAggregator.Publish(new ImageContainerEventArgs(ImageContainer.Destination));

            ReplaceDstBySrc.Click += (sernder, args)
                => _eventAggregator.Publish(new ImageContainerEventArgs(ImageContainer.Source));

            SrcZoom.MouseWheel += (sender, args)
             => _eventAggregator.Publish(new ZoomEventArgs(ImageContainer.Source));

            SrcZoom.MouseUp += (secnder, args)
                => _eventAggregator.Publish(new ZoomEventArgs(ImageContainer.Source));

            SrcZoom.KeyPress += (secnder, args)
                => _eventAggregator.Publish(new ZoomEventArgs(ImageContainer.Source));

            DstZoom.MouseWheel += (sender, args)
                => _eventAggregator.Publish(new ZoomEventArgs(ImageContainer.Destination));

            DstZoom.MouseUp += (sender, args)
                => _eventAggregator.Publish(new ZoomEventArgs(ImageContainer.Destination));

            DstZoom.KeyPress += (sender, args)
                => _eventAggregator.Publish(new ZoomEventArgs(ImageContainer.Destination));
        }

        /// <summary>
        /// Publish event handlers for a convolution menu
        /// </summary>
        private void BindConvolutionFilters()
        {
            ConvolutionFiltersMenu.Click += (sender, args)
                => _eventAggregator.Publish(new ShowConvolutionFilterPresenterEventArgs());
        }

        /// <summary>
        /// Publish event handlers for a rgb filters menu
        /// </summary>
        private void BindRGBFilters()
        {
            InversionFilter.Click += (sender, args)
                => _eventAggregator.Publish(new RGBFilterEventArgs(RGBFilter.Inversion));

            BinaryFilter.Click += (sender, args)
                => _eventAggregator.Publish(new RGBFilterEventArgs(RGBFilter.Binary));

            GrayscaleFilter.Click += (sender, args)
                => _eventAggregator.Publish(new RGBFilterEventArgs(RGBFilter.Grayscale));

            ColorFilterBlue.Click += (sender, args)
                => _eventAggregator.Publish(new RGBColorFilterEventArgs(RGBColors.Blue));

            ColorFilterRed.Click += (sender, args)
                => _eventAggregator.Publish(new RGBColorFilterEventArgs(RGBColors.Red));

            ColorFilterGreen.Click += (sender, args)
                => _eventAggregator.Publish(new RGBColorFilterEventArgs(RGBColors.Green));
        }

        /// <summary>
        /// Publish event handlers for a histogram transformation menu
        /// </summary>
        private void BindDistributions()
        {
            ExponentialDistribution.Click += (sender, args)
                => _eventAggregator.Publish(new DistributionEventArgs(Distribution.Exponential, Parameters));

            ParabolaDistribution.Click += (sender, args)
                => _eventAggregator.Publish(new DistributionEventArgs(Distribution.Parabola, Parameters));

            RayleighDistribution.Click += (sender, args)
                => _eventAggregator.Publish(new DistributionEventArgs(Distribution.Rayleigh, Parameters));

            CauchyDistribution.Click += (sender, args)
                => _eventAggregator.Publish(new DistributionEventArgs(Distribution.Cauchy, Parameters));

            LaplaceDistribution.Click += (sender, args)
                => _eventAggregator.Publish(new DistributionEventArgs(Distribution.Laplace, Parameters));

            NormalDistribution.Click += (sender, args)
                => _eventAggregator.Publish(new DistributionEventArgs(Distribution.Normal, Parameters));

            UniformDistribution.Click += (sender, args)
                => _eventAggregator.Publish(new DistributionEventArgs(Distribution.Uniform, Parameters));

            WeibullDistribution.Click += (sender, args)
                => _eventAggregator.Publish(new DistributionEventArgs(Distribution.Weibull, Parameters));
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
                    _eventAggregator.Publish(new ImageContainerEventArgs(ImageContainer.Source));
                    return true;
                case (Keys.Left):
                    _eventAggregator.Publish(new ImageContainerEventArgs(ImageContainer.Destination));
                    return true;
                case (Keys.Q):
                    _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.PMF, ImageContainer.Source));
                    return true;
                case (Keys.Q | Keys.Control):
                    _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.PMF, ImageContainer.Destination));
                    return true;
                case (Keys.W):
                    _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.CDF, ImageContainer.Source));
                    return true;
                case (Keys.W | Keys.Control):
                    _eventAggregator.Publish(new RandomVariableEventArgs(RandomVariable.CDF, ImageContainer.Destination));
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
   }
}
