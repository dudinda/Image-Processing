using System.Threading.Tasks;

namespace ImageProcessing.Core.EventAggregator.Interface.Subscriber
{
    public interface ISubscriber<TEventType>
    {
        Task OnEventHandler(TEventType e);
    }
}
