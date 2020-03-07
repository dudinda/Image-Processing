using System;
using System.Drawing;

using ImageProcessing.Common.Interop.Api;

namespace ImageProcessing.Common.Interop
{
    /// <summary>
    /// Provides a wrapper over the native windows kernel
    /// method <see cref="NativeMethods.GetCursorPos(out Structs.LPPOINT)"/>
    /// </summary>
    public static class CursorPosition
    {      
        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
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
