using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Menu;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Show;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation
{
    internal sealed class MainFormEventBinder : IMainFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public MainFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IMainFormExposer source)
        {
            source.OpenFileMenu.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new OpenFileDialogEventArgs()
                );

            source.SaveFileMenu.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new SaveWithoutFileDialogEventArgs()
                );

            source.SaveAsMenu.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new SaveAsFileDialogEventArgs()
                );

            source.ReplaceSrcByDstButton.Click += (sernder, args)
                => _aggregator.PublishFrom(source,
                    new ReplaceImageEventArgs(ImageContainer.Destination)
                );

            source.ReplaceDstBySrcButton.Click += (sernder, args)
                => _aggregator.PublishFrom(source,
                    new ReplaceImageEventArgs(ImageContainer.Source)
                );

            source.ZoomSrcTrackBar.MouseWheel += (sender, args)
             => _aggregator.PublishFrom(source,
                 new ZoomEventArgs(ImageContainer.Source)
             );

            source.ZoomSrcTrackBar.MouseUp += (secnder, args)
                => _aggregator.PublishFrom(source,
                    new ZoomEventArgs(ImageContainer.Source)
                );

            source.ZoomSrcTrackBar.KeyPress += (secnder, args)
                => _aggregator.PublishFrom(source,
                    new ZoomEventArgs(ImageContainer.Source)
                );

            source.ZoomDstTrackBar.MouseWheel += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ZoomEventArgs(ImageContainer.Destination)
                );

            source.ZoomDstTrackBar.MouseUp += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ZoomEventArgs(ImageContainer.Destination)
                );

            source.ZoomDstTrackBar.KeyPress += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ZoomEventArgs(ImageContainer.Destination)
                );

            source.RgbMenuButton.Click += (sender, args)
               => _aggregator.PublishFrom(source,
                   new ShowRgbMenuEventArgs()
               );

            source.ConvolutionMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ShowConvolutionMenuEventArgs()
                );

            source.DistributionMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ShowDistributionMenuEventArgs()
                );
        }

        public bool ProcessCmdKey(IMainFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Left): view.ReplaceSrcByDstButton.PerformClick(); return true;
                case (Keys.Right):  view.ReplaceDstBySrcButton.PerformClick(); return true;
            }

            return false;
        }
    }
}
