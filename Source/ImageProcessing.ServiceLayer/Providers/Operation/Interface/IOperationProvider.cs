using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcessing.ServiceLayer.Providers.Operation.Interface
{
    public interface INonBlockDialogProvider
    {
        Task<Bitmap> NonBlockOpen(string filters);
        Task NonBlockSaveAs(Bitmap src, string filters);
    }
}
