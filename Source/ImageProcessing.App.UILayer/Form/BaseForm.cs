using System;
using System.Windows.Forms;

using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Forms;

namespace ImageProcessing.App.UILayer.Form
{
    /// <summary>
    /// Represents the base form with the contextual
    /// information about an application thread.
    /// </summary>
    internal abstract class BaseMainForm : MetroForm
    {
        private ApplicationContext _context
            = null!;

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }
            = null!;

        /// <inheritdoc cref="ApplicationContext"/>
        protected ApplicationContext Context
        {
            get
            {
                if(_context is null)
                {
                    Controller.IoC
                        .RegisterSingleton<ApplicationContext>();

                    _context = Controller.IoC.Resolve<ApplicationContext>();
                }

                return _context;
            }
        }
           

        protected BaseMainForm(IAppController controller)
            : base() => Controller = controller;
        
        protected BaseMainForm()
            : base() { }
    }

    /// <summary>
    /// Represents the base form.
    /// </summary>
    internal abstract class BaseForm : MetroForm, IDisposable
    {
        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }
            = null!;

        protected BaseForm(IAppController controller)
            : base() => Controller = controller;

        protected BaseForm()
            : base() { }
    }
}
