using System;
using System.Drawing;

using ImageProcessing.Interop.Api;

namespace ImageProcessing.Interop.Code.Wrapper
{
    /// <summary>
    /// Provides a wrapper over the native windows kernel
    /// method <see cref="NativeMethods.GetCursorPos(out Structs.LPPOINT)"/>
    /// </summary>
    public static class CursorPosition
    {
        /// <inheritdoc cref="NativeMethods.GetCursorPos(out Structs.LPPOINT)"/>
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
