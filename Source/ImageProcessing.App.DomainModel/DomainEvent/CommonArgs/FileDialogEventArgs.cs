using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.DomainModel.DomainEvent.CommonArgs
{
    public sealed class FileDialogEventArgs 
    {
        public FileDialogEventArgs(FileDialogAction action)
            => Action = action;
        
        ///<inheritdoc cref="FileDialogAction"/>
        public FileDialogAction Action { get; }
    }
}
