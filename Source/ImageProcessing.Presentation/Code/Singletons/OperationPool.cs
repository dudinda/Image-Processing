using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessing.Presentation.Code.Singletons
{
    internal class OperationPool
    {
        private static OperationPool _instance;
        private List<Task<Bitmap>> _pool;

        private readonly static object _sync = new object();
       

        public bool IsEmpty
        {
            get
            {
                lock(_sync)
                {
                    return !_pool.Any();
                }
            }
        }
        private OperationPool()
        {
            _pool = new List<Task<Bitmap>>();
        }
        public static OperationPool Get()
        {
            if (_instance is null)
            {
                lock (_sync)
                {
                    if (_instance is null)
                    {
                        _instance = new  OperationPool();
                    }
                }
            }
            return _instance;
        }
        
        public void Add(Func<Bitmap> function)
        {
            lock (_sync)
            {
                var task = new Task<Bitmap>(function);
                _pool.Add(task);
                task.Start();
            }
        }

        public async Task<Bitmap> GetFirstCompleted()
        {
            if (IsEmpty) return null;

            var firstCompleted = await Task.WhenAny(_pool).ConfigureAwait(false);

            lock (_sync)
            {
              _pool = _pool.Where(x => x.Id != firstCompleted.Id).ToList();
            }

            return await firstCompleted.ConfigureAwait(false);
        }  
    }
}
