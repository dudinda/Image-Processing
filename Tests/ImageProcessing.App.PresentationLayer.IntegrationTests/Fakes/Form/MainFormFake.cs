using System;

using ImageProcessing.App.UILayer.Form.Main;
using ImageProcessing.App.UILayer.FormCommands.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form
{
    internal partial class MainFormFake : MainForm
    {
        public MainFormFake(
            IAppController controller,
            IMainFormEventBinder binder,
            IMainFormCommand command)
            : base(controller, binder, command) { }

        protected override TElement Read<TElement>(Func<object> func)
            => (TElement)func();

        protected override void Write(Action action)
            => action();
    }
}
