using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
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
                => _aggregator.PublishFromForm(source,
                    new OpenFileDialogEventArgs()
                );

            source.SaveFileMenu.Click += (sender, args)
                => _aggregator.PublishFromForm(source,
                    new SaveWithoutFileDialogEventArgs()
                );

            source.SaveAsMenu.Click += (sender, args)
                => _aggregator.PublishFromForm(source,
                    new SaveAsFileDialogEventArgs()
                );

            source.ReplaceSrcByDstButton.Click += (sernder, args)
                => _aggregator.PublishFromForm(source,
                    new ReplaceImageEventArgs(ImageContainer.Destination)
                );

            source.ReplaceDstBySrcButton.Click += (sernder, args)
                => _aggregator.PublishFromForm(source,
                    new ReplaceImageEventArgs(ImageContainer.Source)
                );

            source.ZoomSrcTrackBar.MouseWheel += (sender, args)
             => _aggregator.PublishFromForm(source,
                 new ZoomEventArgs(ImageContainer.Source)
             );

            source.ZoomSrcTrackBar.MouseUp += (secnder, args)
                => _aggregator.PublishFromForm(source,
                    new ZoomEventArgs(ImageContainer.Source)
                );

            source.ZoomSrcTrackBar.KeyPress += (secnder, args)
                => _aggregator.PublishFromForm(source,
                    new ZoomEventArgs(ImageContainer.Source)
                );

            source.ZoomDstTrackBar.MouseWheel += (sender, args)
                => _aggregator.PublishFromForm(source,
                    new ZoomEventArgs(ImageContainer.Destination)
                );

            source.ZoomDstTrackBar.MouseUp += (sender, args)
                => _aggregator.PublishFromForm(source,
                    new ZoomEventArgs(ImageContainer.Destination)
                );

            source.ZoomDstTrackBar.KeyPress += (sender, args)
                => _aggregator.PublishFromForm(source,
                    new ZoomEventArgs(ImageContainer.Destination)
                );
        }

        public bool ProcessCmdKey(IMainFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Right):

                    _aggregator.PublishFromForm(view,
                        new ReplaceImageEventArgs(ImageContainer.Source)
                    );

                    return true;
                case (Keys.Left):

                    _aggregator.PublishFromForm(view,
                        new ReplaceImageEventArgs(ImageContainer.Destination)
                    );

                    return true;
                case (Keys.Q):

                    _aggregator.PublishFromForm(view,
                        new BuildRandomVariableFunctionEventArgs(
                            RandomVariableFunction.PMF, ImageContainer.Source
                        )
                    );

                    return true;
                case (Keys.Q | Keys.Control):

                    _aggregator.PublishFromForm(view,
                        new BuildRandomVariableFunctionEventArgs(
                            RandomVariableFunction.PMF, ImageContainer.Destination
                        )
                    );

                    return true;
                case (Keys.W):

                    _aggregator.PublishFromForm(view,
                        new BuildRandomVariableFunctionEventArgs(
                            RandomVariableFunction.CDF, ImageContainer.Source
                        )
                    );

                    return true;
                case (Keys.W | Keys.Control):

                    _aggregator.PublishFromForm(view,
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
