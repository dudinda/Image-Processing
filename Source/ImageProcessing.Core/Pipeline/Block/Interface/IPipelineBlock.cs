using System;
using System.Threading;

namespace ImageProcessing.Core.Pipeline
{
    public interface IPipelineBlock<TOutput>
    {

        void Add<TStepIn, TStepOut>(Func<TStepIn, TStepOut> stepFunc);

        TOutput Process(CancellationToken token);
    }
}
