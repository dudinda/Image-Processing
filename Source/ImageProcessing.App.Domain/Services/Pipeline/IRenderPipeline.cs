using System;

namespace ImageProcessing.App.Domain.Services.Pipeline
{
    public interface IRenderPipeline : IDisposable
    {
        void Register(IPipelineBlock block);
        bool Any();
        void BeginRender();
    }
}
