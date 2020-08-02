using System.ComponentModel;
using System.Windows.Forms;

using ImageProcessing.App.UILayer.Code.Attributes;
using ImageProcessing.App.UILayer.FormControls.Base;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.View;

using MetroFramework.Forms;

namespace ImageProcessing.App.UILayer.Form
{
    /// <summary>
    /// Represents the base form with the contextual
    /// information about an application thread.
    /// </summary>
    [TypeDescriptionProvider(
        typeof(AbstractFormDescriptionProvider<BaseForm, MetroForm>))]
    internal abstract class BaseForm : MetroForm, IView
    {
        private ApplicationContext _context
            = null!;

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller { get; }
            = null!;

        protected BaseForm(
            IAppController controller)
           : base()
        {
            Controller = controller;
        }

        protected BaseForm(
            IAppController controller,
            IBaseEventBinder<IView> binder)
           : this(controller)
        {
            binder.Bind(this);
        }

        protected BaseForm()
            : base() { }

        /// <inheritdoc cref="ApplicationContext"/>
        protected ApplicationContext Context
        {
            get
            {
                if(_context is null)
                {
                    var ioc = Controller.IoC;

                    if(!ioc.IsRegistered<ApplicationContext>())
                    {
                        ioc.RegisterSingleton<ApplicationContext>();
                    }

                    _context = ioc.Resolve<ApplicationContext>();
                }

                return _context;
            }
        }
    }
}
