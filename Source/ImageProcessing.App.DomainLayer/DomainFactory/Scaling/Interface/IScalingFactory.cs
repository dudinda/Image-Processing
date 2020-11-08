using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Interface
{
    public interface IScalingFactory : IModelFactory<IScaling, ScalingMethod>
    {

    }
}
