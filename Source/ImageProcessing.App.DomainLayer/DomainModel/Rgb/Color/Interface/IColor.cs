namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Interface
{
    /// <summary>
    /// Specifies a color alteration of an RGB pixel.
    /// </summary>
    public interface IColor
    {
        /// <summary>
        /// Change the source pixel rgb components.
        /// </summary>
        /// <param name="pixelPtr">The source pixel.</param>
        unsafe void SetPixelColor(byte* pixelPtr);
    }
}
