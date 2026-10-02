using System.ComponentModel;

namespace ImageProcessing.App.ServiceLayer.Code.Enums
{
    public enum ScalingMethod
    {
        [Description("Bicubic interpolation")]
        Bicubic  = 0,

        [Description("Bilinear interpolation")]
        Bilinear = 1,

        [Description("Proximal interpolation")]
        Proximal = 2
    }
}
