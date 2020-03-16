using ImageProcessing.Common.Enums;

namespace ImageProcessing.DomainModel.DomainEvent.CommonArgs
{
    public sealed class FileDialogEventArgs 
    {
        public FileDialogEventArgs(FileDialogAction action)
            => Action = action;
        
        ///<inheritdoc cref="FileDialogAction"/>
        public FileDialogAction Action { get; }
    }
}
