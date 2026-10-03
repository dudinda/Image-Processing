using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories.Convolution.Implementation;
using ImageProcessing.App.Domain.UnitTests.CaseFactory;
using ImageProcessing.App.Domain.Services.Factories.Convolution;

using NUnit.Framework;

using static ImageProcessing.App.Domain.UnitTests.CaseFactory.DomainFactoriesCaseFactory;

namespace ImageProcessing.App.Domain.UnitTests.Factory.Convolution
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
               typeof(DomainFactoriesCaseFactory),
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
