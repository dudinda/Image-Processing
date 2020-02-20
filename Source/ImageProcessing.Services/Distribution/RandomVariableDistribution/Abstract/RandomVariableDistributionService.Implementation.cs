using System.Linq;

using ImageProcessing.Common.Extensions.DecimalMathRealExtensions;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Services.DistributionServices.RandomVariableDistribution.Abstract
{
    public abstract class RandomVariableDistributionServiceImplementation
    {
        protected decimal GetExpectationImpl(decimal[] pmf)
        {
            var total = 0.0M;

            for (var i = 0; i < 256; ++i)
            {
                total += pmf[i] * i;
            }

            return total;
        }

        protected decimal GetVarianceImpl(decimal[] pmf)
        {
            var total = 0.0M;

            var mean = GetExpectationImpl(pmf);

            for (var i = 0; i < 256; ++i)
            {
                total += pmf[i] * (i - mean) * (i - mean);
            }

            return total;
        }

        protected decimal GetStandardDeviationImpl(decimal[] pmf)
        {
            return GetVarianceImpl(pmf).Sqrt();
        }

        protected decimal GetConditionalExpectationImpl((int x1, int x2) interval, decimal[] pmf)
        {
            var uvalue = 0.0M;
            var lvalue = 0.0M;

            for (var i = interval.x1; i <= interval.x2; ++i)
            {
                uvalue += (i * pmf[i]);
                lvalue += pmf[i];
            }

            return uvalue / lvalue;
        }

        protected decimal GetConditionalVarianceImpl((int x1, int x2) interval, decimal[] pmf)
        {
            var mean = GetConditionalExpectationImpl(interval, pmf);

            var uvalue = 0.0M;
            var lvalue = 0.0M;

            for (var i = interval.x1; i <= interval.x2; ++i)
            {
                uvalue += pmf[i] * ((i - mean) * (i - mean));
                lvalue += pmf[i];
            }

            return uvalue / lvalue;
        }

        protected decimal[] GetPMFImpl(int[] frequencies)
        {
            var total = frequencies.Sum();

            return frequencies.AsParallel().Select(x => (decimal)x / total).ToArray();
        }

        protected decimal[] GetCDFImpl(decimal[] pmf)
        {
            var cdf = pmf.Clone() as decimal[];

            for (int x = 1; x < cdf.Length; ++x)
            {
                cdf[x] += cdf[x - 1];

                if (cdf[x] > 1)
                {
                    cdf[x] = 1;
                }
            }

            return cdf;
        }

        protected decimal GetEntropyImpl(decimal[] pmf)
        {
            var entropy = 0.0M;

            for (var index = 0; index < 256; ++index)
            {
                entropy += (pmf[index] * pmf[index].Log(2));
            }

            return -entropy;
        }

        protected decimal[] TransformToImpl(decimal[] cdf, IDistribution distribution)
        {
            var result = new decimal[cdf.Length];

            //transform an array by a quantile function
            for (int index = 0; index < cdf.Length; ++index)
            {
                result[index] = distribution.Quantile(cdf[index]);
            }

            return result;
        }
    }
}
