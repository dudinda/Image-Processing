using ImageProcessing.App.CommonLayer.Enums;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposer.Settings
{
    internal interface ISettingsFormExposer
    {
        MetroComboBox LumaDropDown { get; }
        MetroComboBox ScalingDropDown { get; }
        MetroComboBox RotationDropDown { get; }

        Luma Rec { get; }
        RotationMethod Rotation { get; }
        ScalingMethod Scaling { get; }
    }
}
