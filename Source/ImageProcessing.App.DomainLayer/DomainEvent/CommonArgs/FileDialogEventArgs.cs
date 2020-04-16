using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    public sealed class FileDialogEventArgs 
    {
        public FileDialogEventArgs(FileDialogAction action)
            => Action = action;
        
        ///<inheritdoc cref="FileDialogAction"/>
        public FileDialogAction Action { get; }
    }
}
