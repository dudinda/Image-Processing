using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.View;

namespace ImageProcessing.Presentation.Views.Main
{
    public interface IMainView : IView
    {
        (string, string) Parameters { get; }

        string PathToFile { get; set; }
        Image SrcImage { get; set; }
        Image DstImage { get; set; }
        Image SrcImageCopy { get; set; }
        Image DstImageCopy { get; set; }
        bool IsGreenChannelChecked { get; set; }
        bool IsRedChannelChecked { get; set; }
        bool IsBlueChannelChecked { get; set; }

        void AddToUndoContainer((Bitmap changed, ImageContainer from) action);
        RGBColors GetSelectedColors(RGBColors color);
        void ShowInfo(string info);
        void ShowError(string message);
        Image GetImageCopy(ImageContainer container);
        void SetImageCopy(ImageContainer container, Image copy);
        void SetImage(ImageContainer container, Image image);
        bool ImageIsNull(ImageContainer container);
        void ResetTrackBarValue(ImageContainer container, int value = 0, bool isEnabled = true);
        Image ZoomImage(ImageContainer container);
        void SetImageToZoom(ImageContainer container, Image image);
        void SetCursor(CursorType cursor);

        void Refresh(ImageContainer container);
    }
}
