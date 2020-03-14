using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.DomainModel.Factory.Morphology.Interface;
using ImageProcessing.ServiceLayer.Providers.Interface.Morphology;
using ImageProcessing.ServiceLayer.Services.Morphology.Interface;

namespace ImageProcessing.ServiceLayer.Providers.Implementation.Morphology
{
    public sealed class MorphologyServiceProvider : IMorphologyServiceProvider
    {
        private readonly IMorphologyService _morphologyService;
        private readonly IMorphologyFactory _morphologyFactory;

        public MorphologyServiceProvider(IMorphologyService morphologyService,
                                         IMorphologyFactory morphologyFactory)
        {
            _morphologyService = Requires.IsNotNull(
                morphologyService, nameof(morphologyService)
            );

            _morphologyFactory = Requires.IsNotNull(
                morphologyFactory, nameof(morphologyFactory)
            );
        }

        public Bitmap ApplyBinary(Bitmap lvalue, Bitmap rvalue, MorphologyOperator filter)
        {
            Requires.IsNotNull(lvalue, nameof(lvalue));
            Requires.IsNotNull(rvalue, nameof(rvalue));

            return _morphologyService
                      .ApplyOperator(lvalue, rvalue,
                          _morphologyFactory.BinaryFilter(filter)
                   );
        }

        public Bitmap ApplyUnary(Bitmap bmp, BitMatrix kernel, MorphologyOperator filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));
            Requires.IsNotNull(kernel, nameof(kernel));

            return _morphologyService
                      .ApplyOperator(bmp, kernel,
                          _morphologyFactory.GetFilter(filter)
                   );
        }
      

    }
}
