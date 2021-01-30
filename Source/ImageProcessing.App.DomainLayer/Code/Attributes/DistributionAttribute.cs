using System;

namespace ImageProcessing.App.DomainLayer.Code.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class DistributionAttribute : Attribute
    {
        public DistributionAttribute(
            string firstParameter)
        {
            FirstParamter = firstParameter;
        }

        public DistributionAttribute(
            string firstParameter,
            string secondParameter)
        {
            FirstParamter = firstParameter;
            SecondParamter = secondParameter;
        }

        public string? FirstParamter { get; }
        public string? SecondParamter { get; }
    }
}
