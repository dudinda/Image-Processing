using System.Windows.Forms;

using ImageProcessing.App.UILayer.Forms.ColorMatrix;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.ColorMatrix
{
    /// <summary>
    /// Expose elements from the <see cref="ColorMatrixForm"/>
    /// </summary>
    internal interface IColorMatrixFormExposer
    {
        /// <summary>
        /// Apply a color matrix.
        /// </summary>
        MetroButton ApplyButton { get; }

        /// <summary>
        /// Apply a custom color matrix.
        /// </summary>
        MetroButton ApplyCustomButton { get; }

        /// <summary>
        /// Custom color matrix checkbox.
        /// </summary>
        MetroCheckBox CustomCheckBox { get; }

        /// <summary>
        /// Color matrix drop down.
        /// </summary>
        MetroComboBox ColorMatrixDropDown { get; }

        ///<inheritdoc cref="FormClosedEventHandler"/>
        event FormClosedEventHandler FormClosed;
    }
}
