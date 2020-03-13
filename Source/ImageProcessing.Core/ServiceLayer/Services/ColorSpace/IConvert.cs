using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessing.Core.ServiceLayer.Services.ColorSpace
{
    public interface IConvert
    {
        IList<Bitmap> From(Bitmap bitmap);
        Bitmap To(IList<Bitmap> bitmap);
    }
}
