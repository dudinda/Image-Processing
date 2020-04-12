using ImageProcessing.Common.Enums;
using ImageProcessing.Core.MVP.Model;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Color.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IColor"/>.
    /// </summary>
    public interface IColorFactory : IModelFactory<IColor, RgbColors>
    {

    }
}
