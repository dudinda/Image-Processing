namespace ImageProcessing.Core.EventAggregator.Interface.Subscriber
{
    public interface ISubscriber<TEventType>
    {
        void OnEventHandler(TEventType e);
    }
}
