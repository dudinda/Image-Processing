using System.Threading.Tasks;

namespace ImageProcessing.Microkernel.MVP.Aggregator.Subscriber
{
    public interface ISubscriber<TEventArgs>
    {
        Task OnEventHandler(object publisher, TEventArgs e);
    }
}
