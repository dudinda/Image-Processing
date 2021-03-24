
using System.Drawing;

using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Services.ColorMatrix.Interface;
using ImageProcessing.App.ServiceLayer.Services.ColorMatrix.Implementation;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Services.ColorMatrix.Implementation
{
    internal class ColorMatrixServiceWrapper : IColorMatrixServiceWrapper
    {
        private readonly ColorMatrixService _service
            = new ColorMatrixService();

        public virtual Bitmap Apply(Bitmap source, ReadOnly2DArray<double> mtx)
            => _service.Apply(source, mtx);
    }
}
