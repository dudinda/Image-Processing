using System;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Pipeline.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Pipeline.Implementation
{
    internal class AwaitablePipelineServiceWrapper : IAwaitablePipelineServiceWrapper
    {
        private readonly AwaitablePipeline _service
            = new AwaitablePipeline();

        public virtual bool Any()
            => _service.Any();

        public virtual async Task<object> AwaitResult()
            => await _service.AwaitResult().ConfigureAwait(false);

        public virtual void Dispose()
            => _service.Dispose();

        public virtual bool Register(IPipelineBlock block)
            => _service.Register(block);
    }
}
