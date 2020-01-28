namespace ImageProcessing.Core.EventAggregator.Interface
{
    public interface IEventAggregator
    {
        void Publish<TEventType>(TEventType publisher);

        void Subscribe(object subscriber);
    }
}
