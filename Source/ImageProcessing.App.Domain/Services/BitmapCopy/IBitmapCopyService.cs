using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface
{
    public interface IBitmapCopyService
    {
        Task<Bitmap> GetCopy();
        Task SetCopy(Bitmap bmp);
    }
}
