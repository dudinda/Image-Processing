using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.UnitTests.CaseFactory;

using NUnit.Framework;

using static ImageProcessing.App.DomainLayer.UnitTests.CaseFactory.DomainLayerFactoriesCaseFactory;

namespace ImageProcessing.App.DomainLayer.UnitTests.Factory.Convolution
{
    [TestFixture]
    internal sealed class ConvolutionFilterFactoryTests
    {
        private IConvolutionFilterFactory _convolutionFactory;

        [SetUp]
        public void SetUp()
        {
            _convolutionFactory = new ConvolutionFilterFactory();
        }

        [Test, TestCaseSource(
               typeof(DomainLayerFactoriesCaseFactory),
               nameof(ConvolutionFactoryTestCases))]
        public void FactoryReturnsBoxBlur3x3ByEnumValue(ConvolutionFilter filter, Type returnType)
            => Assert.That(_convolutionFactory.Get(filter), Is.TypeOf(returnType));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotImplementedException>(
                () => _convolutionFactory.Get(ConvolutionFilter.Unknown)
            );
    }
}
