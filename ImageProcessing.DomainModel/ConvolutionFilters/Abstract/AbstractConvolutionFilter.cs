namespace ImageProcessing.ConvulationFilters
{
    public abstract class AbstractConvolutionFilter
    {
        public abstract string FilterName { get; }
        public abstract double Factor { get; }
        public abstract double[,] Kernel { get; }
        public abstract double Bias { get; }
              
    }
}
