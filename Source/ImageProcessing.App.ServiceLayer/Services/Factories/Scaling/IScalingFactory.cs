using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Scaling;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Scaling
{
    public interface IScalingFactory : IModelFactory<IScaling, ScalingMethod>
    {

    }
}
