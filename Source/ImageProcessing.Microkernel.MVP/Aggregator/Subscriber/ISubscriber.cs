using System.Threading.Tasks;

namespace ImageProcessing.Microkernel.MVP.Aggregator.Subscriber
{
    public interface ISubscriber<TEventType>
    {
        Task OnEventHandler(TEventType e);
    }
}
