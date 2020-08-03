using System;

namespace ImageProcessing.App.DomainLayer.DomainEvent.Base
{
    /// <summary>
    /// The base class for classes containing event metadata.
    /// </summary>
    public abstract class BaseEventArgs
    {
        public DateTime PublishedOn { get; }

        public object Publisher { get; }
            = null!;

        public BaseEventArgs()
        {
            PublishedOn = DateTime.UtcNow;
        }

        public BaseEventArgs(object publisher) : base()
        {
            Publisher = publisher;
        }
           
    }
}
