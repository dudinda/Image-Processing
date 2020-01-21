using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Utility.BitmapStack;

namespace ImageProcessing.UI.Control
{
    public class UndoRedoSplitContainer : SplitContainer
    {
        public FixedStack<(Bitmap changed, ImageContainer from)> Undo { get; }
        public FixedStack<(Bitmap returned, ImageContainer to)> Redo { get; }
    }
}
