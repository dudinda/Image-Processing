using System;
using System.Drawing;

using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.Presentation.Views
{
    /// <summary>
    /// Represents the base behavior
    /// of the main window.
    /// </summary>
    public interface IMainView : IView, ITrackBarContainer,
        ITooltip, IBitmapContainer, IToolbarContainer,
        ICursor, IDisposable
    {
        /// <summary>
        /// Default an image inside a picturebox./>
        /// </summary>
        void SetDefaultImage();

        /// <summary>
        /// Set the path to the loaded image.
        /// </summary>
        void SetPathToFile(string path);

        /// <summary>
        /// Get the path of the loaded image.
        /// </summary>
        string GetPathToFile();

        /// <summary>
        /// Center a picturebox after a scaling.
        /// </summary>
        void SetImageCenter(Size size);

        /// <summary>
        /// Set the state for the main view buttons.
        /// </summary>
        void SetMenuState(MenuBtnState state);
    }
}
