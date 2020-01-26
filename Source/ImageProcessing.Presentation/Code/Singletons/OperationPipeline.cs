using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ImageProcessing.Presentation.Code.Singletons
{
    internal class OperationPipeline
    {
        private static readonly OperationPipeline _instance = new OperationPipeline();

        private ConcurrentQueue<Task<Bitmap>> _queue = new ConcurrentQueue<Task<Bitmap>>();

        static OperationPipeline()
        {
            
        }

        private OperationPipeline()
        {
            
        }

        public static OperationPipeline Instance => _instance;
        public bool IsEmpty => _queue.IsEmpty;

        public void Register(Func<Bitmap> function)
        {
            var task = new Task<Bitmap>(function);
            _queue.Enqueue(task);
            task.Start();
        }

        public async Task<Bitmap> GetFirstCompleted()
        {
            if (IsEmpty) return null;

            if(_queue.TryDequeue(out var task)) {
                return await task.ConfigureAwait(false);
            }

            throw new InvalidOperationException();
        }  
    }
}
