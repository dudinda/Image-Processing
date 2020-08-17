using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo
{
    internal interface IMainFormUndoRedoCommand 
    {
        void Add(ImageContainer to, Bitmap bmp);
        (Bitmap Bmp, ImageContainer To)? Pop();
    }
}
