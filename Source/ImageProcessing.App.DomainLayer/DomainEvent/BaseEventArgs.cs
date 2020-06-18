using System;

namespace ImageProcessing.App.DomainLayer.DomainEvent.Base
{
    /// <summary>
    /// The base class for classes containing event metadata.
    /// </summary>
    public abstract class BaseEventArgs
    {
        public DateTime PublishedOn { get; }

        public BaseEventArgs()
            => PublishedOn = DateTime.UtcNow;
    }
}
