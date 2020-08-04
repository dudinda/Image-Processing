using System;

namespace ImageProcessing.Microkernel.MVP.Aggregator.Interface
{
    /// <summary>
    /// Responds to any event from a source object
    /// by propagating that event to target objects.
    /// </summary>
    public interface IEventAggregator
    {
        /// <summary>
        /// Publish a message to all subscribers from a concrete <paramref name="publisher"/>
        /// with <typeparamref name="TEventType"/> event args.
        /// </summary>
        void PublishFromForm<TEventArgs>(object publisher, TEventArgs args);

        /// <summary>
        /// Publish a message to all subscribers from all the publishers
        /// with <typeparamref name="TEventType"/> event args.
        /// </summary>
        void PublishFromPresenter<TEventArgs>(object publisher, TEventArgs args);

        /// <summary>
        /// Subscribe a specified object with handlers
        /// to all messages with <typeparamref name="TEventType"/>  args.
        /// </summary>
        void Subscribe(object subscriber, object publisher);

        /// <summary>
        /// Unsubscribe from the specified <paramref name="subscriber"/>.
        /// </summary>
        void Unsubscribe(Type subscriber, object publisher);
    }
}
