using System;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Forms;

namespace ImageProcessing.App.UILayer.Form.Base
{
    /// <summary>
    /// Represents the base form with the contextual
    /// information about an application thread.
    /// </summary>
    internal class BaseMainForm : MetroForm
    {
        private Lazy<ApplicationContext> _context
            => new Lazy<ApplicationContext>(
                Controller.IoC.Resolve<ApplicationContext>
            );

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }

        /// <inheritdoc cref="ApplicationContext"/>
        protected ApplicationContext Context
            => _context.Value;

        protected BaseMainForm(IAppController controller)
            : base()
            => Controller = Requires.IsNotNull(
                controller, nameof(controller));
        
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
            => Controller = Requires.IsNotNull(
                controller, nameof(controller));

        protected BaseForm() { }
    }
}
