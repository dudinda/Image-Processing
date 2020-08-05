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
        Image? SourceImageCopy { get; set; }
        Image? DestinationImageCopy { get; set; }
        PictureBox SourceBox { get; }
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
        /// Replace a destination container image by a source.
        /// </summary>
        ToolStripButton UndoButton { get; }
    }
}
