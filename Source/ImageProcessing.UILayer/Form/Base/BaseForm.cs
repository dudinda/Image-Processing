using System.Windows.Forms;

using ImageProcessing.Common.Helpers;
using ImageProcessing.ServiceLayer.Services.EventAggregator.Interface;

using MetroFramework.Forms;

namespace ImageProcessing.UILayer.Form.Base
{
    /// <summary>
    /// Represents the base form with the contextual
    /// information about an application thread.
    /// </summary>
    internal class BaseMainForm : MetroForm
    {
        /// <inheritdoc cref="IEventAggregator"/>
        protected IEventAggregator EventAggregator { get; }

        /// <inheritdoc cref="ApplicationContext"/>
        protected ApplicationContext Context { get; }

        protected BaseMainForm(ApplicationContext context, IEventAggregator eventAggregator)
            : base()
        {
            Context = Requires.IsNotNull(
                context, nameof(context));
            EventAggregator = Requires.IsNotNull(
                eventAggregator, nameof(eventAggregator));
        }

        protected BaseMainForm() { }
    }

    /// <summary>
    /// Represents the base form.
    /// </summary>
    internal class BaseForm : MetroForm
    {
        /// <inheritdoc cref="IEventAggregator"/>
        protected IEventAggregator EventAggregator { get; }

        protected BaseForm(IEventAggregator eventAggregator)
            : base()
        {
            EventAggregator = Requires.IsNotNull(
                eventAggregator, nameof(eventAggregator));
        }

        protected BaseForm() { }
    }
}
