using System;
using System.Threading.Tasks;

namespace ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface
{
    public interface IAwaitablePipeline : IDisposable
    {
        bool Register(IPipelineBlock block);
        bool Any();
        Task<object> AwaitResult();
    }
}
