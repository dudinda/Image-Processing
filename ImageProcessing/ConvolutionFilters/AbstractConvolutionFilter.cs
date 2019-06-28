using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4.ConvulationFilters
{
    public abstract class AbstractConvolutionFilter
    {
        public abstract string FilterName { get; }

        public abstract double Factor { get; }

        public abstract double[,] Kernel { get; }

        public abstract double Bias { get; }
              
    }
}
