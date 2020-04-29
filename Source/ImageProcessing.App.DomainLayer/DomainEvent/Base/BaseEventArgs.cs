using System;

namespace ImageProcessing.App.DomainLayer.DomainEvent.Base
{
    public abstract class BaseEventArgs
    {
        public DateTime PublishedOn { get; }

        public BaseEventArgs()
            => PublishedOn = DateTime.UtcNow;
    }
}
