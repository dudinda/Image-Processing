using ImageProcessing.Common.Enums;

namespace ImageProcessing.DomainModel.DomainEvent.CommonArgs
{
    public sealed class ToolbarActionEventArgs 
    {
        public ToolbarActionEventArgs(ToolbarAction action)
            => Action = action;

        ///<inheritdoc cref="ToolbarAction"/>
        public ToolbarAction Action { get; }
    }
}
