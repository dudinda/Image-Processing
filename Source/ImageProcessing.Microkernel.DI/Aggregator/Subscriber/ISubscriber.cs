using System.Threading.Tasks;

namespace ImageProcessing.Microkernel.DI.Aggregator.Subscriber
{
    public interface ISubscriber<TEventType>
    {
        Task OnEventHandler(TEventType e);
    }
}
