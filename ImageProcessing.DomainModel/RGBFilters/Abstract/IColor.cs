namespace ImageProcessing.RGBFilters.Abstract
{
    public interface IColor
    {
        unsafe void SetPixelColor(byte* ptr);
    }
}
