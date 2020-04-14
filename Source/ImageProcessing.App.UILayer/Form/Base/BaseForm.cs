using System.Windows.Forms;

using ImageProcessing.App.Common.Helpers;
using ImageProcessing.Microkernel.DI.Controller.Interface;

using MetroFramework.Forms;

namespace ImageProcessing.App.UILayer.Form.Base
{
    /// <summary>
    /// Represents the base form with the contextual
    /// information about an application thread.
    /// </summary>
    internal class BaseMainForm : MetroForm
    {
        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }

        /// <inheritdoc cref="ApplicationContext"/>
        protected ApplicationContext Context { get; }

        protected BaseMainForm(ApplicationContext context, IAppController controller)
            : base()
        {
            Context = Requires.IsNotNull(
                context, nameof(context));
            Controller = Requires.IsNotNull(
                controller, nameof(controller));
        }

        protected BaseMainForm() { }
    }

    /// <summary>
    /// Represents the base form.
    /// </summary>
    internal class BaseForm : MetroForm
    {
        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }

        protected BaseForm(IAppController controller)
            : base()
        {
            Controller = Requires.IsNotNull(
                controller, nameof(controller));
        }

        protected BaseForm() { }
    }
}
