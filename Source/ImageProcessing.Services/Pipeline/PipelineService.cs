using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ImageProcessing.Core.Pipeline;

namespace ImageProcessing.Services.Pipeline
{
    public class PipelineService<TOutput> : IAwaitablePipeline<TOutput>
    {
        public Task<TOutput> Execute(object input)
        {
            throw new NotImplementedException();
        }
    }
}
