using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.DomainLayer.Models.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.Factories.Scaling.Interface
{
    public interface IScalingFactory : IModelFactory<IScaling, ScalingMethod>
    {

    }
}
