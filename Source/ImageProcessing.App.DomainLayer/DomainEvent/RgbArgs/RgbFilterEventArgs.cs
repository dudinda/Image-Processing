using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs
{
    public sealed class RgbFilterEventArgs : BaseEventArgs
    {
        public RgbFilterEventArgs(object publisher)
            : base(publisher)
        {
        }


    }
}
