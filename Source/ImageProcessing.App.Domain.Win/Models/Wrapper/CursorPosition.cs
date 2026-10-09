using System;
using System.Drawing;

using ImageProcessing.App.Domain.Win.Services.Api;

namespace ImageProcessing.App.Domain.Win.Models.Wrapper
{
    /// <summary>
    /// Provides a wrapper over the native windows kernel
    /// method <see cref="NativeMethods.GetCursorPos(out LPPOINT)"/>.
    /// </summary>
    public static class CursorPosition
    {
        /// <inheritdoc cref="NativeMethods.GetCursorPos(out LPPOINT)"/>
        public static Point GetCursorPosition()
        {
            if (NativeMethods.GetCursorPos(out var lpPoint))
            {
                return (Point)lpPoint;
            }

            throw new InvalidOperationException("Can't get the current cursor position.");
        }
    }
}
