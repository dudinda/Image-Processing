using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Extensions.EnumExt;
using ImageProcessing.App.UILayer.Code.Attributes;
using ImageProcessing.App.UILayer.FormEventBinders;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.View;

using MetroFramework.Controls;
using MetroFramework.Forms;

namespace ImageProcessing.App.UILayer.Forms
{
    /// <summary>
    /// Represents the base form with the contextual
    /// information about an application thread.
    /// </summary>
    [TypeDescriptionProvider(
        typeof(AbstractFormDescriptionProvider<BaseForm, MetroForm>))]
    internal abstract class BaseForm : MetroForm, IView
    {
        private IAppController? _controller;
        private ApplicationContext? _context;

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller
        {
            get => _controller ?? throw new ArgumentNullException();
            set => _controller = value;
        }

        protected BaseForm(IAppController controller) : base()
        {
            Controller = controller;
        }
            
        protected BaseForm() : base()
        {

        }

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

        protected virtual TElement Read<TElement>(Func<object> func)
        {
            object? result = null;

            if (SynchronizationContext.Current is null)
            {
                Invoke((Action)(() => result = func() ));
            }
            else
            {
                result = func();
            } 

            return (TElement)(result ?? throw new ArgumentNullException(nameof(result)));
        }

        protected virtual void Write(Action action)
        {
            if(SynchronizationContext.Current is null)
            {
                Invoke(action);
            }
            else
            {
                action();
            } 
        }

        protected void PopulateComboBox<TEnum>(MetroComboBox box)
           where TEnum : Enum
        {
            var values = EnumExtensions.GetAllEnumValues<TEnum>()
                .Select(val => val.GetDescription()).ToArray();

            box.Items.AddRange(Array.ConvertAll(values, item => (object)item));
            box.SelectedIndex = 0;
        }
    }
}
