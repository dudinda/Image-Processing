using System;
using System.Threading;

namespace ImageProcessing.Core.Pipeline
{
    public interface IPipelineBlock<TOutput>
    {

        IPipelineBlock<TOutput> Add<TStepIn, TStepOut>(Func<TStepIn, TStepOut> stepFunc);
        TOutput Process(CancellationToken token);
    }
}
