using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Scaling;

namespace ImageProcessing.App.DomainLayer.Factories.Scaling.Interface
{
    public interface IScalingFactory : IModelFactory<IScaling, ScalingMethod>
    {

    }
}
