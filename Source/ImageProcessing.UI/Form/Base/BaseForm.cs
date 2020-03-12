using System.Windows.Forms;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.EventAggregator.Interface;

using MetroFramework.Forms;

namespace ImageProcessing.Form.Base
{
    public class BaseMainForm : MetroForm
    {
        protected IEventAggregator EventAggregator { get; }
        protected ApplicationContext Context { get; }

        protected BaseMainForm(ApplicationContext context, IEventAggregator eventAggregator)
            : base()
        {
            Context         = Requires.IsNotNull(context, nameof(context));
            EventAggregator = Requires.IsNotNull(eventAggregator, nameof(eventAggregator));
        }
    }

    public class BaseForm : MetroForm
    {
        protected IEventAggregator EventAggregator { get; }

        protected BaseForm(IEventAggregator eventAggregator)
            : base()
        {
            EventAggregator = Requires.IsNotNull(eventAggregator, nameof(eventAggregator));
        }
    }
}
