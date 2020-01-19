using System.Drawing;
using System.Runtime.InteropServices;

using ImageProcessing.Common.Interop.Structs;

namespace ImageProcessing.Common.Interop
{
    public static class CursorPosition
    {      
        [DllImport("user32.dll")]
        internal static extern bool GetCursorPos(out LPPOINT lpPoint);

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        public static Point GetCursorPosition()
        {
            LPPOINT lpPoint;
            GetCursorPos(out lpPoint);
            return (Point)lpPoint;
        }
    }
}
