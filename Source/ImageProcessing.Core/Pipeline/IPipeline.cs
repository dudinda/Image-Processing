using System.Threading.Tasks;

namespace ImageProcessing.Core.Pipeline
{
    public interface IAwaitablePipeline<TOutput>
    {
        Task<TOutput> Execute(object input);
    }
}
