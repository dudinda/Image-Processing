using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs
{
    public sealed class ApplyRgbFilterEventArgs : BaseEventArgs
    {
        public ApplyRgbFilterEventArgs(object publisher)
            : base(publisher)
        {
        }


    }
}
