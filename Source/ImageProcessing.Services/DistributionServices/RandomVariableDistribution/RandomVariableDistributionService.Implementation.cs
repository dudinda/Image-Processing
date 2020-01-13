using System;
using System.Linq;

using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Services.DistributionServices.RandomVariableDistribution.Implementation
{
    public partial class RandomVariableDistributionService
    {
        protected double GetExpectationImpl(double[] pmf)
        {
            var total = 0.0;

            for (var i = 0; i < 256; ++i)
            {
                total += pmf[i] * i;
            }

            return total;
        }

        protected double GetVarianceImpl(double[] pmf)
        {
            var total = 0.0;

            var mean = GetExpectationImpl(pmf);

            for (var i = 0; i < 256; ++i)
            {
                total += pmf[i] * (i - mean) * (i - mean);
            }

            return total;
        }

        protected double GetStandardDeviationImpl(double[] pmf)
        {
            return Math.Sqrt(GetVarianceImpl(pmf));
        }

        protected double GetConditionalExpectationImpl((int x1, int x2) interval, double[] pmf)
        {
            var uvalue = 0.0;
            var lvalue = 0.0;

            for (var i = interval.x1; i <= interval.x2; ++i)
            {
                uvalue += (i * pmf[i]);
                lvalue += pmf[i];
            }

            return uvalue / lvalue;
        }

        protected double GetConditionalVarianceImpl((int x1, int x2) interval, double[] pmf)
        {
            var mean = GetConditionalExpectationImpl(interval, pmf);

            var uvalue = 0.0;
            var lvalue = 0.0;

            for (var i = interval.x1; i <= interval.x2; ++i)
            {
                uvalue += pmf[i] * ((i - mean) * (i - mean));
                lvalue += pmf[i];
            }

            return uvalue / lvalue;
        }

        protected double[] GetPMFImpl(int[] frequencies, uint total)
        {
            return frequencies.AsParallel().Select(x => (double)x / (double)total).ToArray();
        }

        protected double[] GetCDFImpl(double[] pmf)
        {
            var cdf = pmf.Clone() as double[];

            for (int x = 1; x < cdf.Length; ++x)
            {
                cdf[x] += cdf[x - 1];
            }

            return cdf;
        }

        protected double GetEntropyImpl(double[] pmf)
        {
            var entropy = 0.0;

            for (var index = 0; index < 256; ++index)
            {
                if (pmf[index] > Double.Epsilon)
                {
                    entropy += (pmf[index] * Math.Log(pmf[index], 2));
                }
            }

            return -entropy;
        }

        private double[] TransformToImpl(double[] cdf, IDistribution distribution)
        {
            var result = new double[cdf.Length];

            //transform an array by a quantile function
            for (int index = 0; index < cdf.Length; ++index)
            {
                result[index] = distribution.Quantile(cdf[index]);
            }

            return result;
        }
    }
}
