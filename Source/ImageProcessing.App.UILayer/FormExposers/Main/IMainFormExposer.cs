using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.UILayer.Control;

namespace ImageProcessing.App.UILayer.FormExposers.Main
{
    /// <summary>
    /// Expose elements from the main form.
    /// </summary>
    internal interface IMainFormExposer : IMainView
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
        /// The source image.
        /// </summary>
        Image DestinationImage { get; set; }

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
        ZoomTrackBar ZoomSrcTrackBar { get; }

        /// <summary>
        /// Zoom a destination image.
        /// </summary>
        ZoomTrackBar ZoomDstTrackBar { get; }

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
        /// Undo the last operation.
        /// </summary>
        ToolStripButton UndoButton { get; }

        /// <summary>
        /// Redo the last operation.
        /// </summary>
        ToolStripButton RedoButton { get; }
    }
}
