using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class ToolbarActionEventArgs : IBaseEventArgs<ToolbarAction>
    {
        public ToolbarActionEventArgs(ToolbarAction arg)
        {
            Arg = arg;
        }
        /// <summary>
        /// <see cref="ToolbarAction"/>
        /// </summary>
        public ToolbarAction Arg { get; }
    }
}
