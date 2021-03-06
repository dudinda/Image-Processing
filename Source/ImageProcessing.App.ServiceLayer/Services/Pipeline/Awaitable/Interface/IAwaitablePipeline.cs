using System;
using System.Threading.Tasks;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface
{
    public interface IAwaitablePipeline : IDisposable
    {
        bool Register(IPipelineBlock block);
        bool Any();
        Task<object> AwaitResult();
    }
}
