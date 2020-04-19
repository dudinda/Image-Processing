 namespace ImageProcessing.Microkernel.MVP.Aggregator.Interface
{
    /// <summary>
    /// Responds to any event from a source object
    /// by propagating that event to target objects.
    /// </summary>
    public interface IEventAggregator
    {
        /// <summary>
        /// Publish a message to all subscribers
        /// with <typeparamref name="TEventType"/> event args.
        /// </summary>
        void Publish<TEventType>(TEventType publisher);

        /// <summary>
        /// Subscribe a specified object with handlers
        /// to all messages with <typeparamref name="TEventType"/>  args.
        /// </summary>
        void Subscribe(object subscriber);
    }
}
