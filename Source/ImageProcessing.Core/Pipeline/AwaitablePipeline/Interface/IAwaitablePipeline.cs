using System.Threading.Tasks;

namespace ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface
{
    public interface IAwaitablePipeline<TOutput>
    {
        bool Register(IPipelineBlock<TOutput> block);
        bool Any();
        Task<TOutput> AwaitResult();
    }
}
