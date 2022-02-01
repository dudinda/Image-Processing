using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.UILayer.Controls;
using ImageProcessing.App.UILayer.Forms.Main;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.FormExposers.Main
{
    /// <summary>
    /// Expose elements from the <see cref="MainForm"/>.
    /// </summary>
    internal interface IMainFormExposer 
    {
        /// <summary>
        /// Image by default.
        /// </summary>
        Image? DefaultImage { get; }

        /// <summary>
        /// The destination image.
        /// </summary>
        Image SourceImage { get; set; }

        /// <summary>
        /// The source image copy.
        /// </summary>
        Image SrcImageCopy { get; set; }

        /// <summary>
        /// The source picture box.
        /// </summary>
        PictureBox SourceBox { get; }

        /// <summary>
        /// Save as dialog.
        /// </summary>
        ToolStripMenuItem SaveAsMenu { get; }

        /// <summary>
        /// Open file dialog.
        /// </summary>
        ToolStripMenuItem OpenFileMenu { get; }

        /// <summary>
        /// Save the file by its location.
        /// </summary>
        ToolStripMenuItem SaveFileMenu { get; }

        /// <summary>
        /// Zoom a source image.
        /// </summary>
        ScaleTrackBar ZoomSrcTrackBar { get; }

        /// <summary>
        /// Rotate a source image.
        /// </summary>
        RotationTrackBar RotationSrcTrackBar { get; }

        /// <summary>
        /// Show the convolution control panel.
        /// </summary>
        ToolStripMenuItem ConvolutionMenuButton { get; }

        /// <summary>
        /// Show the rgb control panel.
        /// </summary>
        ToolStripMenuItem RgbMenuButton { get; }

        /// <summary>
        /// Show the rotation control panel.
        /// </summary>
        ToolStripMenuItem RotationMenuButton { get; }

        /// <summary>
        /// Show the scaling control panel.
        /// </summary>
        ToolStripMenuItem ScalingMenuButton { get; }

        /// <summary>
        /// Show the distribution control panel.
        /// </summary>
        ToolStripMenuItem DistributionMenuButton { get; }

        /// <summary>
        /// Show the affine transformation control panel.
        /// </summary>
        ToolStripMenuItem AffineTransformationMenuButton { get; }

        /// <summary>
        /// Show the settings control panel.
        /// </summary>
        ToolStripMenuItem SettingsMenuButton { get; }

        /// <summary>
        /// Undo the last operation.
        /// </summary>
        ToolStripButton UndoButton { get; }

        /// <summary>
        /// Redo the last operation.
        /// </summary>
        ToolStripButton RedoButton { get; }

        /// <summary>
        /// Set source image button.
        /// </summary>
        ToolStripButton SetSourceButton { get; }

        MetroTabControl TabsCtrl { get; }

        ///<inheritdoc cref="FormClosedEventHandler"/>
        event FormClosedEventHandler FormClosed;
    }
}