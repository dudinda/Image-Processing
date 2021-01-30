using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Interface
{
    public interface IScalingFactory : IModelFactory<IScaling, ScalingMethod>
    {

    }
}
