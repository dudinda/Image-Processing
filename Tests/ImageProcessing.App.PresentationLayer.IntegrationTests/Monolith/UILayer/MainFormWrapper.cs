using System;

using ImageProcessing.App.UILayer.FormCommands.Main;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.App.UILayer.Forms.Main;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form
{
    internal partial class MainFormWrapper : MainForm
    {
        public MainFormWrapper(
            IAppController controller,
            IMainFormEventBinder binder,
            IMainFormContainerFactory container,
            IMainFormUndoRedoFactory undoRedo,
            IMainFormZoomFactory zoom,
            IMainFormRotationFactory rotation)
            : base(controller, binder, container, undoRedo, zoom, rotation)
        {
            
        }

        protected override TElement Read<TElement>(Func<object> func)
            => (TElement)func();

        protected override void Write(Action action)
            => action();

        public override void Show()
        {

        }
    }
}
