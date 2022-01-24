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
                => _aggregator.PublishFrom(source, new OpenFileDialogEventArgs());

            source.SaveFileMenu.Click += (sender, args)
                => _aggregator.PublishFrom(source, new SaveWithoutFileDialogEventArgs());

            source.SaveAsMenu.Click += (sender, args)
                => _aggregator.PublishFrom(source, new SaveAsFileDialogEventArgs());

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

            source.RgbMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowRgbMenuEventArgs());

            source.AffineTransformationMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowTransformationMenuEventArgs());

            source.SettingsMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowSettingsMenuEventArgs());

            source.ConvolutionMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowConvolutionMenuEventArgs());

            source.RotationMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowRotationMenuEventArgs());

            source.ScalingMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowScalingMenuEventArgs());

            source.DistributionMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ShowDistributionMenuEventArgs());

            source.UndoButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new UndoRedoEventArgs(Undo));

            source.RedoButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new UndoRedoEventArgs(Redo));

            source.FormClosed += (sender, args)
                => _aggregator.PublishFrom(source, new FormIsClosedEventArgs());

            source.SetSourceButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new SetSourceEventArgs());
        }

        public bool ProcessCmdKey(IMainFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Left):

                    if (view.TabsCtrl.SelectedIndex > 0)
                    {
                        view.TabsCtrl.SelectedIndex--;
                        return true;
                    }

                    view.TabsCtrl.SelectedIndex = view.TabsCtrl.TabCount - 1;

                    return true;

                case (Keys.Right):

                    if (view.TabsCtrl.SelectedIndex < view.TabsCtrl.TabCount - 1)
                    {
                        view.TabsCtrl.SelectedIndex++;
                        return true;
                    }

                    view.TabsCtrl.SelectedIndex = 0;

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
