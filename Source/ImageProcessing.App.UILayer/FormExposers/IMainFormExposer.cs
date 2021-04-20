using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.UILayer.Control;
using ImageProcessing.App.UILayer.FormControl.TrackBar;
using ImageProcessing.App.UILayer.Forms.Main;

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
        /// Container with the images to undo/redo. 
        /// </summary>
        UndoRedoSplitContainer SplitContainerCtr { get; }

        /// <summary>
        /// The destination image.
        /// </summary>
        Image SourceImage { get; set; }

        /// <summary>
        /// The source image copy.
        /// </summary>
        Image SrcImageCopy { get; set; }

        /// <summary>
        /// The source image.
        /// </summary>
        Image DestinationImage { get; set; }

        /// <summary>
        /// The destination image copy.
        /// </summary>
        Image DstImageCopy { get; set; }

        /// <summary>
        /// The source picture box.
        /// </summary>
        PictureBox SourceBox { get; }

        /// <summary>
        /// The destination picture box.
        /// </summary>
        PictureBox DestinationBox { get; }

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
        /// Replace a source container image by a destination. 
        /// </summary>
        ToolStripButton ReplaceSrcByDstButton { get; }

        /// <summary>
        /// Replace a destination container image by a source.
        /// </summary>
        ToolStripButton ReplaceDstBySrcButton { get; }

        /// <summary>
        /// Zoom a source image.
        /// </summary>
        ScaleTrackBar ZoomSrcTrackBar { get; }

        /// <summary>
        /// Zoom a destination image.
        /// </summary>
        ScaleTrackBar ZoomDstTrackBar { get; }

        /// <summary>
        /// Rotate a source image.
        /// </summary>
        RotationTrackBar RotationSrcTrackBar { get; }

        /// <summary>
        /// Rotate a destination image.
        /// </summary>
        RotationTrackBar RotationDstTrackBar { get; }

        /// <summary>
        /// Show the convolution control panel.
        /// </summary>
        ToolStripMenuItem ConvolutionMenuButton { get; }

        /// <summary>
        /// Show the rgb control panel.
        /// </summary>
        ToolStripMenuItem RgbMenuButton { get; }

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

        ///<inheritdoc cref="FormClosedEventHandler"/>
        event FormClosedEventHandler FormClosed;
    }
}