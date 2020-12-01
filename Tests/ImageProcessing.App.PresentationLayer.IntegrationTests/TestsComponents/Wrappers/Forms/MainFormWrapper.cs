using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.UnitTests.Services;
using ImageProcessing.App.UILayer.Form.Main;
using ImageProcessing.App.UILayer.FormCommands.Main;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form
{
    internal partial class MainFormWrapper : MainForm
    {
        private IAutoResetEventService _synchronizer;

        public MainFormWrapper(
            IAutoResetEventService synchronizer,
            IAppController controller,
            IMainFormEventBinder binder,
            IMainFormContainerFactory container,
            IMainFormUndoRedoFactory undoRedo,
            IMainFormZoomFactory zoom,
            IMainFormRotationFactory rotation)
            : base(controller, binder, container, undoRedo, zoom, rotation)
        {
            _synchronizer = synchronizer;
        }

        protected override TElement Read<TElement>(Func<object> func)
            => (TElement)func();

        protected override void Write(Action action)
            => action();

        public override void Show()
        {

        }

        public override void SetCursor(CursorType cursor)
        {
            if(cursor == CursorType.Default)
            {
                _synchronizer.Signal();
            }

            base.SetCursor(cursor);
        }
    }
}
