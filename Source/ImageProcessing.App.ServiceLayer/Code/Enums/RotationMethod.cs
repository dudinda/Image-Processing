using System.ComponentModel;

namespace ImageProcessing.App.DomainLayer.Code.Enums
{
    public enum RotationMethod
    {
        [Description("Rotation by Area Mapping")]
        AreaMapping = 0,

        [Description("Rotation by Shear")]
        Shear       = 1,

        [Description("Rotation by Sampling")]
        Sampling    = 2
    }
}
