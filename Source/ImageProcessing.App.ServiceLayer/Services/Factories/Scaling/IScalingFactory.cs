using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Scaling;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Scaling
{
    public interface IScalingFactory : IModelFactory<IScaling, ScalingMethod>
    {

    }
}
