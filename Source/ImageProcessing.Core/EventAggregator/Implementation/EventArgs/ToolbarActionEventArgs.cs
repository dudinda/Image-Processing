using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class ToolbarActionEventArgs : IBaseEventArgs<ToolbarAction>
    {
        public ToolbarActionEventArgs(ToolbarAction arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="ToolbarAction"/>
        public ToolbarAction Arg { get; }
    }
}
