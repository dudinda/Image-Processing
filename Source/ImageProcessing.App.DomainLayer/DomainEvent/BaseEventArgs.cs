using System;

namespace ImageProcessing.App.DomainLayer.DomainEvent
{
    /// <summary>
    /// The base class for classes containing event metadata.
    /// </summary>
    public abstract class BaseEventArgs
    {
        private object? _publisher;

        public DateTime PublishedOn { get; }

        public object Publisher
        {
            get => _publisher ??
                new ArgumentNullException(nameof(_publisher));
            
        }

        public BaseEventArgs()
        {
            PublishedOn = DateTime.UtcNow;
        }

        public BaseEventArgs(object publisher) : base()
        {
            _publisher = publisher;
        }
           
    }
}
