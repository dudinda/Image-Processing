using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcessing.ServiceLayer.Services.FileDialog.Interface
{
    public interface IFileDialogService
    {
        Task<Bitmap> OpenFileDialog(string filters);
        Task SaveFileAsDialog(Bitmap src, string filters);
    }
}
