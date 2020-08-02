using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.UILayer.Control;

namespace ImageProcessing.App.UILayer.FormElements.Main
{
    internal interface IMainElementsExposer : IMainView
    {
        ToolStripMenuItem SaveAsMenu { get; }
        ToolStripMenuItem OpenFileMenu { get; }
        ToolStripMenuItem SaveFileMenu { get; }
        ToolStripButton ReplaceSrcByDstButton { get; }
        ToolStripButton ReplaceDstBySrcButton { get; }
        ZoomTrackBar ZoomSrcTrackBar { get; }
        ZoomTrackBar ZoomDstTrackBar { get; }
        ToolStripMenuItem ConvolutionMenu { get; }
        ToolStripMenuItem RgbMenu { get; }
    }
}
