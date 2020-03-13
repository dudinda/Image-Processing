using System;
using System.Threading.Tasks;

namespace ImageProcessing.Core.ServiceLayer.Services.STATask
{
    public interface ISTATaskService : IDisposable
    {
        Task<TArg> StartSTATask<TArg>(Func<TArg> func) 
            where TArg : class;
        Task StartSTATask(Action func);
    }
}
