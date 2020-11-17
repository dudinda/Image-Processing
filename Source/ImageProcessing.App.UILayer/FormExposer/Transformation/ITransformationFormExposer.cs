using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposer.Transformation
{
    internal interface ITransformationFormExposer
    {
        MetroButton ApplyButton { get; }

        /// <inheritdoc/>
        (string, string) Parameters { get; }
    }
}
