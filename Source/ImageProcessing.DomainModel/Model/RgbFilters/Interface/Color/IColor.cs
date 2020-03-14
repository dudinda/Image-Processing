namespace ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color
{
    public interface IColor
    {
        unsafe void SetPixelColor(byte* pixelPtr);
    }
}
