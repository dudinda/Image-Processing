using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Transformation.Interface
{
    public interface ITransformationProvider
    {
        /// <summary>
        /// Choose the <see cref="AffTransform"/> implementation over
        /// the specified <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Apply(Bitmap bmp, double x, double y, AffTransform transform);
    }
}
