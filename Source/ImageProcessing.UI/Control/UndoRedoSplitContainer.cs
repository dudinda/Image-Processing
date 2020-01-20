using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Utility.BitmapStack;

namespace ImageProcessing.UI.Control
{
    public class UndoRedoSplitContainer : SplitContainer
    {
        public BitmapStack<(Bitmap changed, ImageContainer from)> Undo { get; set; }
        public BitmapStack<(Bitmap returned, ImageContainer to)> Redo { get; set; }
    }
}
