using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.ColorSpaces
{
    public interface IConvert
    {
        List<Bitmap> FromRGB(Bitmap bmp);
        Bitmap ToRGB(List<Bitmap> bmp);
    }
}
