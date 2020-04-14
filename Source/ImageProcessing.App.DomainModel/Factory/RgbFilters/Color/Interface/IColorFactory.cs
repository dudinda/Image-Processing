using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Interface.Color;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainModel.Factory.RgbFilters.Color.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IColor"/>.
    /// </summary>
    public interface IColorFactory : IModelFactory<IColor, RgbColors>
    {

    }
}
