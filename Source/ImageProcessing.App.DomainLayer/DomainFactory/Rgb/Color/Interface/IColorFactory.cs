using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Color.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IColor"/>.
    /// </summary>
    public interface IColorFactory : IModelFactory<IColor, RgbColors>
    {

    }
}
