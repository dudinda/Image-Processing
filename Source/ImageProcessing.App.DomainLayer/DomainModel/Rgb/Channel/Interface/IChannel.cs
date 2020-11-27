namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.Channel.Interface
{
    /// <summary>
    /// Specifies a channel of an RGB pixel.
    /// </summary>
    public interface IChannel
    {
        /// <summary>
        /// Change the source pixel rgb components.
        /// </summary>
        /// <param name="pixelPtr">The source pixel.</param>
        unsafe void GetChannel(byte* pixelPtr);
    }
}
