using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.Core.Factory.Morphology;
using ImageProcessing.Core.ServiceLayer.Providers.Morphology;
using ImageProcessing.Core.ServiceLayer.Services.Morphology;

namespace ImageProcessing.ServiceLayer.Providers.Morphology
{
    public class MorphologyServiceProvider : IMorphologyServiceProvider
    {
        private readonly IMorphologyService _morphologyService;
        private readonly IMorphologyFactory _morphologyFactory;

        public MorphologyServiceProvider(IMorphologyService morphologyService,
                                         IMorphologyFactory morphologyFactory)
        {
            _morphologyService = morphologyService;
            _morphologyFactory = morphologyFactory;
        }

        public Bitmap ApplyBinary(Bitmap lvalue, Bitmap rvalue, MorphologyOperator filter)
            => _morphologyService
                .ApplyOperator(lvalue, rvalue,
                    _morphologyFactory.BinaryFilter(filter)
                );

        public Bitmap ApplyUnary(Bitmap bmp, BitMatrix kernel, MorphologyOperator filter)
            => _morphologyService
                .ApplyOperator(bmp, kernel,
                    _morphologyFactory.GetFilter(filter)
                );

    }
}
