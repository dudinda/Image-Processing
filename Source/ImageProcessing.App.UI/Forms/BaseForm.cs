using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using ImageProcessing.App.Domain.Code.Extensions;
using ImageProcessing.Microkernel.MVP.Services.Aggregator;
using ImageProcessing.Microkernel.MVP.Services.Controller;
using ImageProcessing.Microkernel.MVP.Services.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.View;

using MetroFramework.Controls;
using MetroFramework.Forms;

namespace ImageProcessing.App.UI.Forms
{
    /// <summary>
    /// Represents the base form with the contextual
    /// information about an application thread.
    /// </summary>
    internal class BaseForm : MetroForm, IView
    {

        /// <inheritdoc cref="IAppController"/>
        protected IAppController Controller
            => field ??= AppController.Controller;

        /// <inheritdoc cref="IEventAggregator"/>
        protected IEventAggregator Aggregator
            => Controller.Aggregator;

        /// <inheritdoc cref="ApplicationContext"/>
        protected ApplicationContext Context
        {
            get
            {
                if(field is null)
                {
                    var ioc = Controller.IoC;

                    if(!ioc.IsRegistered<ApplicationContext>())
                    {
                        ioc.RegisterSingleton<ApplicationContext>();
                    }

                    field = ioc.Resolve<ApplicationContext>();
                }

                return field;
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
    }
}
