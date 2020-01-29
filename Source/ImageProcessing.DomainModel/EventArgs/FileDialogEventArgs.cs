using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.DomainModel.EventArgs
{
    public class FileDialogEventArgs : IBaseEventArgs<FileDialogAction>
    {
        public FileDialogEventArgs(FileDialogAction arg)
        {
            Arg = arg;
        }
        public FileDialogAction Arg { get; }
    }
}
