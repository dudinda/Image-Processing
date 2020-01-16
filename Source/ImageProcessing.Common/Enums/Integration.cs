using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Common.Enums
{
    public enum Integration
    {
        /// <summary>
        /// An unknown integration method
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Monte Carlo integration
        /// </summary>
        MonteCarlo = 1,

        /// <summary>
        /// Trapezoidal rule integration
        /// </summary>
        Trapezoidal = 2

    }
}
