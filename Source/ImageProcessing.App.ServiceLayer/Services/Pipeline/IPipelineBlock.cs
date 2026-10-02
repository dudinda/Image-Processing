using System;
using System.Linq.Expressions;
using System.Threading;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline
{
    public interface IPipelineBlock
    {
        IPipelineBlock Add<TIn, TOut>(Expression<Func<TIn, TOut>> step);
        IPipelineBlock Add<TIn>(Expression<Action<TIn>> step);
        object Process(CancellationToken token);
    }
}
