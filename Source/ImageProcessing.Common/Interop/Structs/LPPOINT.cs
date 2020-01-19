using System.Drawing;
using System.Runtime.InteropServices;

namespace ImageProcessing.Common.Interop.Structs
{
    /// <summary>
    /// A struct, representing a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct LPPOINT
    {
        public int X;
        public int Y;
        public static explicit operator Point(LPPOINT point)
            => new Point(point.X, point.Y);
    }
}
