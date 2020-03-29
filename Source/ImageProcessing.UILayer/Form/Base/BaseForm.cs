using System.Runtime.CompilerServices;
using System.Windows.Forms;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.EventAggregator.Interface;

using MetroFramework.Forms;

[assembly: InternalsVisibleTo("ImageProcessing.Tests")]
namespace ImageProcessing.UILayer.Form.Base
{
    internal class BaseMainForm : MetroForm
    {
        protected IEventAggregator EventAggregator { get; }
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

    internal class BaseForm : MetroForm
    {
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
