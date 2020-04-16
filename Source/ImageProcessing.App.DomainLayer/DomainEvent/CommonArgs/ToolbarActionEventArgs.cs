using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    public sealed class ToolbarActionEventArgs 
    {
        public ToolbarActionEventArgs(ToolbarAction action)
            => Action = action;

        ///<inheritdoc cref="ToolbarAction"/>
        public ToolbarAction Action { get; }
    }
}
