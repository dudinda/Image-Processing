using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ImageProcessing.Enum
{
    public enum Distribution
    {
        [Description("1 - λ")]
        Exponential = 0,

        [Description("1 - ")]
        Rayleigh    = 1,

        [Description("")]
        Cauchy      = 2,

        [Description("")]
        Laplace     = 3,

        [Description("")]
        Normal      = 4,

        [Description("")]
        Parabola    = 5,

        [Description("")]
        Uniform     = 6,

        [Description("")]
        Weibull     = 7
    }
}
