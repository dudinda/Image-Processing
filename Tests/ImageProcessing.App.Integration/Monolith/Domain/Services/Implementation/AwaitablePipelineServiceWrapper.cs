using System;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Interface;
using ImageProcessing.App.Domain.Services.Pipeline;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Implementation
{
    internal class AwaitablePipelineServiceWrapper : IAwaitablePipelineServiceWrapper
    {
        private readonly AwaitablePipeline _service
            = new AwaitablePipeline();

        public virtual bool Any()
            => _service.Any();

        public virtual Task<object> AwaitResult()
            => Task.FromResult(_service.AwaitResult().Result);

        public virtual void Dispose()
            => _service.Dispose();

        public virtual bool Register(IPipelineBlock block)
            => _service.Register(block);
    }
}
