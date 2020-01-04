using System.Drawing;

namespace ImageProcessing.DomainModel.Services.Distribution
{
    public interface IDistributionService
    {
        Bitmap Distribute(Bitmap bitmap, IDistribution distribution)
    }
}
