using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Color.Interface
{
    public interface IColorFactory : IBaseFactory<IColor, RgbColors>
    {

    }
}
