
using System.Drawing;

using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Services.ColorMatrix.Interface;
using ImageProcessing.App.Domain.Services.ColorMatrix.Implementation;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Services.ColorMatrix.Implementation
{
    internal class ColorMatrixServiceWrapper : IColorMatrixServiceWrapper
    {
        private readonly ColorMatrixService _service
            = new ColorMatrixService();

        public virtual Bitmap Apply(Bitmap source, ReadOnly2DArray<double> mtx)
            => _service.Apply(source, mtx);
    }
}
