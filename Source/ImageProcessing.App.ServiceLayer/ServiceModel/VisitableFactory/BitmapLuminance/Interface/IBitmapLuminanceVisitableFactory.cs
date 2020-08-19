using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Factory.Interface
{
    internal interface IBitmapLuminanceVisitableFactory
        : IModelFactory<IBitmapLuminanceVisitable, RandomVariableInfo>
    {

    }
}
