using System.Drawing;

namespace ImageProcessing.App.UILayer.FormCommands.Main
{
    internal interface IMainFormContainerCommand 
    {
        bool ImageIsDefault();
        void Refresh();
        Image? GetCopy();
        void SetCopy(Image image);
        void SetImage(Image image);
        void ResetTrackBarValue(int value = 0);
        Image ZoomImage();
        void SetZoomImage(Image image);
    }
}
