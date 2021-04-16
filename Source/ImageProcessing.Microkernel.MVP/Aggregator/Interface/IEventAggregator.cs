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
        /// with <typeparamref name="TEventArgs"/> event args.
        /// </summary>
        void PublishFrom<TEventArgs>(object publisher, TEventArgs args);

        /// <summary>
        /// Publish a message to all subscribers from all the publishers
        /// with <typeparamref name="TEventArgs"/> event args. Can be used to
        /// send a message from presenter to presenter.
        /// </summary>
        void PublishFromAll<TEventArgs>(object publisher, TEventArgs args);

        /// <summary>
        /// Subscribe the specified <paramref name="subscriber"/>
        /// with the message handlers from the <paramref name="publisher"/>.
        /// </summary>
        void Subscribe(object subscriber, object publisher);

        /// <summary>
        /// Unsubscribe <paramref name="publisher"/> from the specified <paramref name="subscriber"/>.
        /// </summary>
        void Unsubscribe(Type subscriber, object publisher);
    }
}
