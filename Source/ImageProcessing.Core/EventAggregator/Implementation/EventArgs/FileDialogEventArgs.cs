using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs
{
    public class FileDialogEventArgs : IBaseEventArgs<FileDialogAction>
    {
        public FileDialogEventArgs(FileDialogAction arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="FileDialogAction"/>
        public FileDialogAction Arg { get; }
    }
}
