namespace ImageProcessing.Core.Model.RGBFilters
{
    public interface IColor
    {
        unsafe void SetPixelColor(byte* pixelPtr);
    }
}
