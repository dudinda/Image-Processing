using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.Transformation
{
    internal interface ITransformationFormExposer
    {
        MetroButton ApplyButton { get; }

        /// <inheritdoc/>
        (string, string) Parameters { get; }
    }
}
