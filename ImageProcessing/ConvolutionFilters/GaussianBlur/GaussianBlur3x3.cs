using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication4.ConvulationFilters;

namespace WindowsFormsApplication4.ConvolutionFilters.GaussianBlur
{
    class GaussianBlur3x3 : AbstractConvolutionFilter
    {
        public override double Bias
        {
            get
            {
                return bias;
            }
        }
        private double bias = 0.0;

        public override double Factor
        {
            get
            {
                return factor;
            }
        }

        public double factor = 1.0 / 16.0;

        public override string FilterName
        {
            get
            {
                return "Gaussian Blur 3 x 3";
            }
        }

        public override double[,] Kernel
        {
            get
            {
                return kernel;
            }
        }

        private double[,] kernel = new double[,] { {1, 2, 1 },
                                                   {2, 4, 2 },
                                                   {1, 2, 1 } };
        };
    }

