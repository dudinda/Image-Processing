using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Container;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Show;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

using static ImageProcessing.App.PresentationLayer.Code.Enums.ImageContainer;
using static ImageProcessing.App.PresentationLayer.Code.Enums.UndoRedoAction;

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
                => _aggregator.PublishFrom(source, new OpenFileDialogEventArgs());

            source.SaveFileMenu.Click += (sender, args)
                => _aggregator.PublishFrom(source, new SaveWithoutFileDialogEventArgs());

            source.SaveAsMenu.Click += (sender, args)
                => _aggregator.PublishFrom(source, new SaveAsFileDialogEventArgs());

            source.ReplaceSrcByDstButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ReplaceImageEventArgs(Destination));

            source.ReplaceDstBySrcButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ReplaceImageEventArgs(Source));

            source.ZoomSrcTrackBar.MouseWheel += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Source));

            source.ZoomSrcTrackBar.MouseUp += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Source));

            source.ZoomSrcTrackBar.KeyPress += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Source));

            source.RotationSrcTrackBar.MouseWheel += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Source));

            source.RotationSrcTrackBar.MouseUp += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Source));

            source.RotationSrcTrackBar.KeyPress += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Source));

            source.ZoomDstTrackBar.MouseWheel += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Destination));

            source.ZoomDstTrackBar.MouseUp += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Destination));

            source.ZoomDstTrackBar.KeyPress += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Destination));

            source.RotationDstTrackBar.MouseWheel += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Destination));

            source.RotationDstTrackBar.MouseUp += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Destination));

            source.RotationDstTrackBar.KeyPress += (sender, args)
                => _aggregator.PublishFrom(source, new TrackBarEventArgs(Destination));

            source.RgbMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowRgbMenuEventArgs());

            source.AffineTransformationMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowTransformationMenuEventArgs());

            source.SettingsMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowSettingsMenuEventArgs());

            source.ConvolutionMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowConvolutionMenuEventArgs());

            source.DistributionMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowDistributionMenuEventArgs());

            source.UndoButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new UndoRedoEventArgs(Undo));

            source.RedoButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new UndoRedoEventArgs(Redo));

            source.FormClosed += (sender, args)
                => _aggregator.PublishFrom(source, new FormIsClosedEventArgs());
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
