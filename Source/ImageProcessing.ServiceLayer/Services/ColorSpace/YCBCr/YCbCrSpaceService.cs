using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

using ImageProcessing.Core.ServiceLayer.Services.ColorSpace;

namespace ImageProcessing.ColorSpaces
{

    public class YCbCrSpaceSerivce : IConvert
    {
        public IList<Bitmap> From(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte R, G, B;

            var width = bitmap.Width;
            var height = bitmap.Height;

            var Ybitmap = new Bitmap(bitmap.Width, bitmap.Height);
            var Cbbitmap = new Bitmap(bitmap.Width, bitmap.Height);
            var Crbitmap = new Bitmap(bitmap.Width, bitmap.Height);

            var YbitmapData = Ybitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            var CbbitmapData = Cbbitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            var CrbitmapData = Crbitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                var ptr = (byte*)bitmapData.Scan0.ToPointer();
                var yPtr = (byte*)YbitmapData.Scan0.ToPointer();
                var cBPtr = (byte*)CbbitmapData.Scan0.ToPointer();
                var cRPtr = (byte*)CrbitmapData.Scan0.ToPointer();

                var nOffset = bitmapData.Stride - bitmap.Width * 3;

                var nWidth = bitmap.Width * 3;

                for (int y = 0; y < bitmap.Height; ++y, ptr += nOffset, yPtr += nOffset, cBPtr += nOffset, cRPtr += nOffset)
                {
                    for (int x = 0; x < bitmap.Width; ++x, ptr += 3, yPtr += 3, cBPtr +=3, cRPtr += 3)
                    {
                        B = ptr[0];
                        G = ptr[1];
                        R = ptr[2];

                         
                        yPtr[0]  = yPtr[1]  = yPtr[2]  = (byte)((0.299 * R) + (0.587 * G) + (0.114 * B));
                        cBPtr[0] = cBPtr[1] = cBPtr[2] = (byte)(128 - (0.168935 * R) - (0.331665 * G) + (0.50059 * B));
                        cRPtr[0] = cRPtr[1] = cRPtr[2] = (byte)(128 + (0.499813 * R) - (0.418531 * G) - (0.081282 * B));

                    }
                }

            }

            bitmap.UnlockBits(bitmapData);
            Ybitmap.UnlockBits(YbitmapData);
            Cbbitmap.UnlockBits(CbbitmapData);
            Crbitmap.UnlockBits(CrbitmapData);
        
            return new List<Bitmap>() { Ybitmap, Cbbitmap, Crbitmap };
        }

        public Bitmap To(IList<Bitmap> components)
        {

            var bitmap = new Bitmap(components[0].Width, components[0].Height);

            var YbitmapData = components[0].LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            var CbbitmapData = components[1].LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            var CrbitmapData = components[2].LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                var ptr   = (byte*)bitmapData.Scan0.ToPointer();
                var yPtr  = (byte*)YbitmapData.Scan0.ToPointer();
                var cBPtr = (byte*)CbbitmapData.Scan0.ToPointer();
                var cRPtr = (byte*)CrbitmapData.Scan0.ToPointer();



                var nOffset = bitmapData.Stride - bitmap.Width * 3;

                var nWidth = bitmap.Width * 3;

                for (int y = 0; y < bitmap.Height; ++y, ptr += nOffset, yPtr += nOffset, cBPtr += nOffset, cRPtr += nOffset)
                {
                    for (int x = 0; x < bitmap.Width; ++x, ptr += 3, yPtr += 3, cBPtr += 3, cRPtr += 3)
                    {
                        ptr[0] = (byte)(yPtr[0] + 1.769905 * (cBPtr[0] - 128) + 0.000013 * (cRPtr[0] - 128));
                        ptr[1] = (byte)(yPtr[0] - 0.343730 * (cBPtr[0] - 128) - 0.714401 * (cRPtr[0] - 128));
                        ptr[2] = (byte)(yPtr[0] + 1.402525 * (cRPtr[0] - 128));
                    }
                }


                bitmap.UnlockBits(bitmapData);
                components[0].UnlockBits(YbitmapData);
                components[1].UnlockBits(CbbitmapData);
                components[2].UnlockBits(CrbitmapData);

                return bitmap;

            }
        }
    }
}
