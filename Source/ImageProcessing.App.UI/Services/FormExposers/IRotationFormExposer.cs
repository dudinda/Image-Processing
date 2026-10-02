using System.Windows.Forms;

using ImageProcessing.App.UI.Forms.Rotation;

using MetroFramework.Controls;

namespace ImageProcessing.App.UI.Services.FormExposers
{
    /// <summary>
    /// Expose elements from the <see cref="RotationForm"/>.
    /// </summary>
    internal interface IRotationFormExposer
    {
        /// <summary>
        /// Apply a rotation button.
        /// </summary>
        MetroButton RotateButton { get; }

        ///<inheritdoc cref="FormClosedEventHandler"/>
        event FormClosedEventHandler FormClosed;
    }
}
