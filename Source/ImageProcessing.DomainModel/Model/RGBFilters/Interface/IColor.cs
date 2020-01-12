namespace ImageProcessing.RGBFilters.Interface
{
    public interface IColor
    {
        unsafe void SetPixelColor(byte* pixelPtr);
    }
}
