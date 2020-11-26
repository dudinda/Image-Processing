using System;
using System.Diagnostics.Contracts;
using System.Linq;

using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.RandomVariable.Interface;
using ImageProcessing.Utility.DecimalMath.Code.Extensions.DecimalMathExtensions.RealAxis;
using ImageProcessing.Utility.DecimalMath.RealAxis;

namespace ImageProcessing.App.ServiceLayer.Services.Distribution.RandomVariable.Implementation
{
    /// <inheritdoc cref="IRandomVariableDistributionService"/>
    internal sealed class RandomVariableDistributionService : IRandomVariableDistributionService
    {
        /// <inheritdoc/>
        public decimal[] TransformToDecimal(decimal[] cdf, IDistribution distribution)
        {
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
            var result = new byte[256];

            //transform an array by a quantile function
            for (int index = 0; index < 256; ++index)
            {
                if (distribution.Quantile(cdf[index], out var pixel))
                {
                    if (pixel > 255)
                    {
                        pixel = 255;
                    }

                    if (pixel < 0)
                    {
                        pixel = 0;
                    }
                }

                result[index] = Convert.ToByte(pixel);
            }

            return result;
        }

        /// <inheritdoc/>
        public decimal GetExpectation(decimal[] pmf)
        {
            Contract.Requires(
                pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Contract.Requires(
                (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

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
            Contract.Requires(
                pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Contract.Requires(
                (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

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
            Contract.Requires(
                pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Contract.Requires(
                (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

            return GetVariance(pmf).Sqrt();
        }

        /// <inheritdoc/>
        public decimal GetConditionalExpectation((int x1, int x2) interval, decimal[] pmf)
        {
            Contract.Requires(
                pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Contract.Requires(
                (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

            var uvalue = 0.0M;
            var lvalue = 0.0M;

            for (var i = interval.x1; i <= interval.x2; ++i)
            {
                uvalue += (i * pmf[i]);
                lvalue += pmf[i];
            }

            if (uvalue == 0.0M && lvalue == 0.0M)
            {
                return 0;
            }

            return uvalue / lvalue;
        }

        /// <inheritdoc/>
        public decimal GetConditionalVariance((int x1, int x2) interval, decimal[] frequencies)
        {
            Contract.Requires(
                frequencies.Any(value => value > 0),
                "Frequencies are always positive.");

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
                return 0;
            }

            return uvalue / lvalue;
        }

        /// <inheritdoc/>
        public decimal[] GetCDF(decimal[] pmf)
        {
            Contract.Requires(
                pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Contract.Requires(
                (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

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

        /// <inheritdoc/>
        public decimal[] GetPMF(int[] frequencies)
        {
            Contract.Requires(
                frequencies.Any(value => value > 0),
                "Frequencies are always positive.");

            var total = frequencies.Sum();

            return frequencies
                .AsParallel()
                .Select(x => (decimal)x / total)
                .ToArray();
        }

        /// <inheritdoc/>
        public decimal GetEntropy(decimal[] pmf)
        {
            Contract.Requires(
                pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Contract.Requires(
                (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

            var entropy = 0.0M;

            for (var index = 0; index < 256; ++index)
            {
                entropy += (pmf[index] * pmf[index].Log(2));
            }

            return -entropy;
        }  
    }
}
