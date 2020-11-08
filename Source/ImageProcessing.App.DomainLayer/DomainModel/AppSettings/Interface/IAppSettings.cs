using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.Services.Settings.Interface
{
    /// <summary>
    /// The settings of the application.
    /// </summary>
    public interface IAppSettings
    {
        /// <inheritdoc cref="RotationMethod"/>
        RotationMethod Rotation { get; set; }

        /// <inheritdoc cref="ScalingMethod"/>
        ScalingMethod Scaling { get; set; }

        /// <inheritdoc cref="Luma"/>
        Luma Rec { get; set; }
    }
}
