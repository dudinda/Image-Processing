using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessing.ColorSpaces
{
    public interface IConvert
    {
        List<Bitmap> FromRGB(Bitmap bmp);
        Bitmap ToRGB(List<Bitmap> bmp);
    }
}
