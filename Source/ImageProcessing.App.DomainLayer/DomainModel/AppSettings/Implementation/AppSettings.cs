using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Settings.Implementation
{
    /// <inheritdoc cref="IAppSettings"/>
    public sealed class AppSettings : IAppSettings
    {
        /// <inheritdoc />
        public RotationMethod Rotation { get; set; }
            = RotationMethod.AreaMapping;

        /// <inheritdoc />
        public ScalingMethod Scaling { get; set; }
            = ScalingMethod.Bicubic;

        /// <inheritdoc />
        public Luma Rec { get; set; }
            = Luma.Rec709;
    }
}
