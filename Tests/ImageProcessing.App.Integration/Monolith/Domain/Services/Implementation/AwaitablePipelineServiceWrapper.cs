using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.Pipeline;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Interface;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Implementation
{
    internal class AwaitablePipelineServiceWrapper : IAwaitablePipelineServiceWrapper
    {
        private readonly IRenderPipeline _service;

        public AwaitablePipelineServiceWrapper(IRenderPipeline service)
        {
            _service = service;
        }

        public virtual bool Any()
            => _service.Any();

        public virtual Task<object> Render()
            => Task.FromResult(_service.Render().Result);

        public virtual void Dispose()
            => _service.Dispose();

        public virtual void Register(IPipelineBlock block)
            => _service.Register(block);
    }
}
