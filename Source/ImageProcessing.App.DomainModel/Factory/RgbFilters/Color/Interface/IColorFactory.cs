using ImageProcessing.App.Common.Enums;
using ImageProcessing.Framework.Core.MVP.Model;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Interface.Color;

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
