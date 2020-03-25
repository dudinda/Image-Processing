using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Color.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IColor"/>.
    /// </summary>
    public interface IColorFactory : IBaseFactory<IColor, RgbColors>
    {

    }
}
