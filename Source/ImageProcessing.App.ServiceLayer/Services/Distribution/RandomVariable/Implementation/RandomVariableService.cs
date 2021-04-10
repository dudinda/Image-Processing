using System;
using System.Linq;

using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;
using ImageProcessing.App.ServiceLayer.Code.Constants;
using ImageProcessing.App.ServiceLayer.Services.Distribution.RandomVariable.Interface;
using ImageProcessing.Utility.DecimalMath.Real;

using static ImageProcessing.Utility.DecimalMath.Real.DecimalReal;

namespace ImageProcessing.App.ServiceLayer.Services.Distribution.RandomVariable.Implementation
{
    /// <inheritdoc cref="IRandomVariableService"/>
    public sealed class RandomVariableService : IRandomVariableService
    {
        private readonly DecimalReal _real = new DecimalReal();

        /// <inheritdoc/>
        public decimal[] TransformToDecimal(decimal[] cdf, IDistribution distribution)
        {
            if (cdf is null) { throw new ArgumentNullException(nameof(cdf)); }
            if (distribution is null) { throw new ArgumentNullException(nameof(distribution)); }

            var result = new decimal[cdf.Length];

            //transform an array by a quantile function
            for (int index = 0; index < cdf.Length; ++index)
            {
                distribution.Quantile(cdf[index], out result[index]);
            }

            return result;
        }

        /// <inheritdoc/>
        public byte[] TransformToByte(decimal[] cdf, IDistribution distribution)
        {
            if (cdf is null) { throw new ArgumentNullException(nameof(cdf)); }
            if (distribution is null) { throw new ArgumentNullException(nameof(distribution)); }

            var result = new byte[256];

            //transform an array by a quantile function
            for (int index = 0; index < 256; ++index)
            {
                if (distribution.Quantile(cdf[index], out var pixel))
                {
                    if (pixel > 255M)
                    {
                        pixel = 255M;
                    }

                    if (pixel < 0M)
                    {
                        pixel = 0M;
                    }
                }

                result[index] = Convert.ToByte(pixel);
            }

            return result;
        }

        /// <inheritdoc/>
        public decimal GetExpectation(decimal[] pmf)
        {
            if (pmf is null) { throw new ArgumentNullException(nameof(pmf)); }
            if (pmf.Any(val => val < 0M))
            {
                throw new ArgumentException(RandomVariableErrors.PmfIsPositive);
            }
            if (_real.Abs(pmf.Sum() - 1.0M) > Epsilon)
            {
                throw new ArgumentException(RandomVariableErrors.PmfNotNormalized);
            }

            var total = 0.0M;

            for (var i = 0; i < 256; ++i)
            {
                total += pmf[i] * i;
            }

            return total;
        }

        /// <inheritdoc/>
        public decimal GetVariance(decimal[] pmf)
        {
            if (pmf is null) { throw new ArgumentNullException(nameof(pmf)); }
            if (pmf.Any(val => val < 0M))
            {
                throw new ArgumentException(RandomVariableErrors.PmfIsPositive);
            }
            if (_real.Abs(pmf.Sum() - 1.0M) > Epsilon)
            {
                throw new ArgumentException(RandomVariableErrors.PmfNotNormalized);
            }

            var total = 0.0M;

            var mean = GetExpectation(pmf);

            for (var i = 0; i < 256; ++i)
            {
                total += pmf[i] * (i - mean) * (i - mean);
            }

            return total;
        }

        /// <inheritdoc/>
        public decimal GetStandardDeviation(decimal[] pmf)
        {
            if(pmf is null) { throw new ArgumentNullException(nameof(pmf)); }
            if(pmf.Any(val => val < 0M))
            {
                throw new ArgumentException(RandomVariableErrors.PmfIsPositive);
            }
            if(_real.Abs(pmf.Sum() - 1.0M) > Epsilon)
            {
                throw new ArgumentException(RandomVariableErrors.PmfNotNormalized);
            }

            return _real.Sqrt(GetVariance(pmf));
        }

        /// <inheritdoc/>
        public decimal GetConditionalExpectation((int x1, int x2) interval, decimal[] pmf)
        {
            if (pmf is null) { throw new ArgumentNullException(nameof(pmf)); }
            if (pmf.Any(val => val < 0M))
            {
                throw new ArgumentException(RandomVariableErrors.PmfIsPositive);
            }
            if (_real.Abs(pmf.Sum() - 1.0M) > Epsilon)
            {
                throw new ArgumentException(RandomVariableErrors.PmfNotNormalized);
            }

            var uvalue = 0.0M;
            var lvalue = 0.0M;

            for (var i = interval.x1; i <= interval.x2; ++i)
            {
                uvalue += (i * pmf[i]);
                lvalue += pmf[i];
            }

            if (uvalue == 0.0M && lvalue == 0.0M)
            {
                return 0M;
            }

            return uvalue / lvalue;
        }

        /// <inheritdoc/>
        public decimal GetConditionalVariance((int x1, int x2) interval, decimal[] frequencies)
        {
            if (frequencies is null) { throw new ArgumentNullException(nameof(frequencies)); }
            if (frequencies.Any(val => val < 0M))
            {
                throw new ArgumentException(RandomVariableErrors.FrequenciesNotPositive);
            }

            var mean = GetConditionalExpectation(interval, frequencies);

            var uvalue = 0.0M;
            var lvalue = 0.0M;

            for (var i = interval.x1; i <= interval.x2; ++i)
            {
                uvalue += frequencies[i] * ((i - mean) * (i - mean));
                lvalue += frequencies[i];
            }

            if(uvalue == 0.0M && lvalue == 0.0M)
            {
                return 0M;
            }

            return uvalue / lvalue;
        }

        /// <inheritdoc/>
        public decimal[] GetCDF(decimal[] pmf)
        {
            if (pmf is null) { throw new ArgumentNullException(nameof(pmf)); }
            if (pmf.Any(val => val < 0M))
            {
                throw new ArgumentException(RandomVariableErrors.PmfIsPositive);
            }
            if (_real.Abs(pmf.Sum() - 1.0M) > Epsilon)
            {
                throw new ArgumentException(RandomVariableErrors.PmfNotNormalized);
            }

            var cdf = pmf.Clone() as decimal[];

            for (int x = 1; x < cdf.Length; ++x)
            {
                cdf[x] += cdf[x - 1];

                if (cdf[x] > 1M)
                {
                    cdf[x] = 1M;
                }
            }

            return cdf;
        }

        /// <inheritdoc/>
        public decimal[] GetPMF(int[] frequencies)
        {
            if (frequencies is null) { throw new ArgumentNullException(nameof(frequencies)); }
            if (frequencies.Any(val => val < 0M))
            {
                throw new ArgumentException(RandomVariableErrors.FrequenciesNotPositive);
            }

            var total = frequencies.Sum();

            return frequencies.Select(x => (decimal)x / total).ToArray();
        }

        /// <inheritdoc/>
        public decimal GetEntropy(decimal[] pmf)
        {
            if (pmf is null) { throw new ArgumentNullException(nameof(pmf)); }
            if (pmf.Any(val => val < 0M))
            {
                throw new ArgumentException(RandomVariableErrors.PmfIsPositive);
            }
            if (_real.Abs(pmf.Sum() - 1.0M) > Epsilon)
            {
                throw new ArgumentException(RandomVariableErrors.PmfNotNormalized);
            }

            var entropy = 0.0M;

            for (var index = 0; index < 256; ++index)
            {
                if (pmf[index] != 0M)
                {
                    entropy += pmf[index] * _real.Log(pmf[index], 2);
                }
            }

            return -entropy;
        }  
    }
}