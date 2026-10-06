using System;
using System.Threading.Tasks;

namespace ImageProcessing.App.Domain.Services.Pipeline
{
    public interface IRenderPipeline : IDisposable
    {
        void Register(IPipelineBlock block);
        bool Any();
        Task<object> Render();
    }
}
