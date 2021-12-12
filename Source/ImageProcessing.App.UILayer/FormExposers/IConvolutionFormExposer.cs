using System.Windows.Forms;

using ImageProcessing.App.UILayer.Forms.Convolution;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.Convolution
{
    /// <summary>
    /// Expose elements from the <see cref="ConvolutionForm"/>.
    /// </summary>
    internal interface IConvolutionFormExposer 
    {
        /// <summary>
        /// Apply a convolution filter.
        /// </summary>
        MetroButton ApplyButton { get; }

        ///<inheritdoc cref="FormClosedEventHandler"/>
        event FormClosedEventHandler FormClosed;
    }
}