using System.Threading.Tasks;

namespace ImageProcessing.App.ServiceLayer.Services.EventAggregator.Interface.Subscriber
{
    public interface ISubscriber<TEventType>
    {
        Task OnEventHandler(TEventType e);
    }
}
