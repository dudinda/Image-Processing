namespace ImageProcessing.RGBFilter.Abstract
{
    public interface IColor
    {
        unsafe void SetPixelColor(byte* ptr);
    }
}
