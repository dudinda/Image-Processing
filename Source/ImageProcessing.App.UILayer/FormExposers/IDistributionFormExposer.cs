using System.Windows.Forms;

using ImageProcessing.App.UILayer.Forms.Distribution;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.Distribution
{
    /// <summary>
    /// Expose elements from the <see cref="DistributionForm"/>.
    /// </summary>
    internal interface IDistributionFormExposer 
    {
        /// <summary>
        /// Apply an rgb filter.
        /// </summary>
        MetroButton ApplyTransformButton { get; }

        /// <summary>
        /// Show CDF of the source image.
        /// </summary>
        ToolStripButton CdfButton { get; }

        /// <summary>
        /// Show PMF of the source image.
        /// </summary>
        ToolStripButton PmfButton { get; }

        /// <summary>
        /// Show E[X] of the source image.
        /// </summary>
        ToolStripButton ExpectactionButton { get; }

        /// <summary>
        /// Show Var[X] of the source image.
        /// </summary>
        ToolStripButton VarianceButton { get; }

        /// <summary>
        /// Show 
        /// </summary>
        ToolStripButton DeviationButton { get; }

        /// <summary>
        /// Show H[X] of the source image.
        /// </summary>
        ToolStripButton EntropyButton { get; }

        /// <summary>
        /// Shuffle the source image.
        /// </summary>
        ToolStripButton ShuffleButton { get; }

        /// <summary>
        /// Show quality measure historgram after transforming
        /// the source grayscale by distributions.
        /// </summary>
        ToolStripButton QualityButton { get; }

        /// <summary>
        /// Get the specified parameters for a <see cref="PrDistribution"/>.
        /// </summary>
       (string, string) Parameters { get; }
    }
}