using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories.Convolution.Implementation;
using ImageProcessing.App.ServiceLayer.UnitTests.CaseFactory;
using ImageProcessing.App.ServiceLayer.Services.Factories.Convolution;

using NUnit.Framework;

using static ImageProcessing.App.ServiceLayer.UnitTests.CaseFactory.ServiceLayerFactoriesCaseFactory;

namespace ImageProcessing.App.ServiceLayer.UnitTests.Factory.Convolution
{
    [TestFixture]
    internal sealed class ConvolutionFilterFactoryTests
    {
        private IConvolutionFactory _convolutionFactory;

        [SetUp]
        public void SetUp()
        {
            _convolutionFactory = new ConvolutionFactory();
        }

        [Test, TestCaseSource(
               typeof(ServiceLayerFactoriesCaseFactory),
               nameof(ConvolutionFactoryTestCases))]
        public void FactoryReturnsBoxBlur3x3ByEnumValue((ConvKernel Input, Type Result) args)
            => Assert.That(_convolutionFactory.Get(args.Input), Is.TypeOf(args.Result));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotImplementedException>(
                () => _convolutionFactory.Get(ConvKernel.Unknown)
            );
    }
}
