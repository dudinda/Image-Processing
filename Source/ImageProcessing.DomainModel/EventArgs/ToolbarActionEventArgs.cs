using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.BaseEventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class ToolbarActionEventArgs : IBaseEventArgs<ToolbarAction>
    {
        public ToolbarActionEventArgs(ToolbarAction arg)
        {
            Arg = arg;
        }
        public ToolbarAction Arg { get; }
    }
}
