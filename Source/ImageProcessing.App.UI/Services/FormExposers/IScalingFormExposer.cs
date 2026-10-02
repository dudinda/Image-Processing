using System.Windows.Forms;

using ImageProcessing.App.UI.Forms.Scaling;

using MetroFramework.Controls;

namespace ImageProcessing.App.UI.Services.FormExposers
{
    /// <summary>
    /// Expose elements from the <see cref="ScalingForm"/>.
    /// </summary>
    internal interface IScalingFormExposer
    {
        /// <summary>
        /// Apply a scaling method button.
        /// </summary>
        MetroButton ScaleButton { get; }

        /// <summary>
        /// Input paramteres of a scale method.
        /// </summary>
        (string, string) Parameters { get; }

        ///<inheritdoc cref="FormClosedEventHandler"/>
        event FormClosedEventHandler FormClosed;
    }
}
