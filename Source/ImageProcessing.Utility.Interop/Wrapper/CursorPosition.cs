using System;
using System.Drawing;

using ImageProcessing.Utility.Interop.Code.Structs;
using ImageProcessing.Utility.Interop.Api;

namespace ImageProcessing.Utility.Interop.Wrapper
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
