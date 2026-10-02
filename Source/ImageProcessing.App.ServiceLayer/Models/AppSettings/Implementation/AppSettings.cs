using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Models.AppSettings.Interface;

namespace ImageProcessing.App.DomainLayer.Models.AppSettings.Implementation
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
