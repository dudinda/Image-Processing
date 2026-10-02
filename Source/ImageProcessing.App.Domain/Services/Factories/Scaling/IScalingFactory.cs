using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Models.Scaling;

namespace ImageProcessing.App.Domain.Services.Factories.Scaling
{
    public interface IScalingFactory : IModelFactory<IScaling, ScalingMethod>
    {

    }
}
