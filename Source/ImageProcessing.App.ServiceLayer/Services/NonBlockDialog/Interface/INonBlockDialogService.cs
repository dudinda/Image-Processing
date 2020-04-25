using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface
{
    public interface INonBlockDialogService
    {
        Task<Bitmap?> NonBlockOpen(string filters);
        Task NonBlockSaveAs(Bitmap src, string filters);
    }
}
