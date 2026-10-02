using System;
using System.Threading.Tasks;

namespace ImageProcessing.App.Domain.Services.Pipeline
{
    public interface IAwaitablePipeline : IDisposable
    {
        bool Register(IPipelineBlock block);
        bool Any();
        Task<object> AwaitResult();
    }
}
