using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Extensions.EnumExt;
using ImageProcessing.App.UILayer.Code.Extensions;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Implementation;
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
    internal class BaseForm : MetroForm, IView
    {
        private IAppController? _controller;
        private ApplicationContext? _context;

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller
            => _controller ??= AppController.Controller;

        /// <inheritdoc cref="IEventAggregator"/>
        protected IEventAggregator Aggregator
            => Controller.Aggregator;

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

            return (TElement)result;
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

        public void EnableControls(bool isEnabled)
        {
            Write(() =>
           {
               foreach (Control c in Controls)
               {
                   c.Enable(isEnabled);
               }
           });
        }
    }
}
