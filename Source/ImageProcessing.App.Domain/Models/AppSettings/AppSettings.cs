using ImageProcessing.App.Domain.Code.Enums;

namespace ImageProcessing.App.Domain.Models.AppSettings
{
    /// <inheritdoc cref="IAppSettings"/>
    public sealed class AppSettings 
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
