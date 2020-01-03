using System;

namespace ImageProcessing.Enum
{
    [Flags]
    public enum RGBColors
    {
        Red   = 1 << 0,
        Green = 1 << 1,
        Blue  = 1 << 2
    }
}
