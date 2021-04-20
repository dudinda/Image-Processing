using ImageProcessing.App.UILayer.Forms.Settings;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.Settings
{
    /// <summary>
    /// Expose elements from the <see cref="SettingsForm"/>.
    /// </summary>
    internal interface ISettingsFormExposer
    {
        /// <summary>
        /// Luma drop down.
        /// </summary>
        MetroComboBox LumaDropDown { get; }

        /// <summary>
        /// Scailing method drop down.
        /// </summary>
        MetroComboBox ScalingDropDown { get; }

        /// <summary>
        /// Rotation drop down.
        /// </summary>
        MetroComboBox RotationDropDown { get; }
    }
}