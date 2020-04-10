using System.Threading.Tasks;

namespace ImageProcessing.ServiceLayer.Services.EventAggregator.Interface.Subscriber
{
    public interface ISubscriber<TEventType>
    {
        Task OnEventHandler(TEventType e);
    }
}
