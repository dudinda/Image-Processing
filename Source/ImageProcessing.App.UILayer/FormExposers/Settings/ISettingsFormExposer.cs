using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.Settings
{
    internal interface ISettingsFormExposer
    {
        MetroComboBox LumaDropDown { get; }
        MetroComboBox ScalingDropDown { get; }
        MetroComboBox RotationDropDown { get; }
    }
}