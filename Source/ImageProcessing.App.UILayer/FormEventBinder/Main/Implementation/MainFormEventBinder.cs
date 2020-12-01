using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Container;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.FileDialog;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Menu;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Show;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation
{
    internal class MainFormEventBinder : IMainFormEventBinder
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
                    new TrackBarEventArgs(ImageContainer.Source)
                );

            source.ZoomSrcTrackBar.MouseUp += (secnder, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Source)
                );

            source.ZoomSrcTrackBar.KeyPress += (secnder, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Source)
                );

            source.RotationSrcTrackBar.MouseWheel += (sender, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Source)
                );

            source.RotationSrcTrackBar.MouseUp += (secnder, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Source)
                );

            source.RotationSrcTrackBar.KeyPress += (secnder, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Source)
                );

            source.ZoomDstTrackBar.MouseWheel += (sender, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Destination)
                );

            source.ZoomDstTrackBar.MouseUp += (sender, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Destination)
                );

            source.ZoomDstTrackBar.KeyPress += (sender, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Destination)
                );

            source.RotationDstTrackBar.MouseWheel += (sender, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Destination)
                );

            source.RotationDstTrackBar.MouseUp += (sender, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Destination)
                );

            source.RotationDstTrackBar.KeyPress += (sender, args)
                => _aggregator.PublishFrom(source,
                    new TrackBarEventArgs(ImageContainer.Destination)
                );

            source.RgbMenuButton.Click += (sender, args)
               => _aggregator.PublishFrom(source,
                   new ShowRgbMenuEventArgs()
               );

            source.AffineTransformationMenuButton.Click += (sender, args)
               => _aggregator.PublishFrom(source,
                   new ShowTransformationMenuEventArgs()
               );

            source.SettingsMenuButton.Click += (sender, args)
               => _aggregator.PublishFrom(source,
                   new ShowSettingsMenuEventArgs()
               );

            source.ConvolutionMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ShowConvolutionMenuEventArgs()
                );

            source.DistributionMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ShowDistributionMenuEventArgs()
                );

            source.UndoButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new UndoRedoEventArgs(UndoRedoAction.Undo)
                );

            source.RedoButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                     new UndoRedoEventArgs(UndoRedoAction.Redo)
                );
        }

        public bool ProcessCmdKey(IMainFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Left):

                    view.ReplaceSrcByDstButton.PerformClick();
                    return true;

                case (Keys.Right):

                    view.ReplaceDstBySrcButton.PerformClick();
                    return true;

                case (Keys.Z | Keys.Control):

                    view.UndoButton.PerformClick();
                    return true;

                case (Keys.Y | Keys.Control):

                    view.RedoButton.PerformClick();
                    return true;
            }

            return false;
        }
    }
}
