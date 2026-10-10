using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.Pipeline;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Interface;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Implementation
{
    internal class RenderPipelineServiceWrapper : IAwaitablePipelineServiceWrapper
    {
        private readonly IRenderPipeline _service;

        public RenderPipelineServiceWrapper(IRenderPipeline service)
        {
            _service = service;
        }

        public virtual bool Any()
            => _service.Any();

        public virtual void BeginRender()
            => _service.BeginRender();
      

        public virtual void Dispose()
            => _service.Dispose();

        public virtual void Register(IPipelineBlock block)
            => _service.Register(block);
    }
}
