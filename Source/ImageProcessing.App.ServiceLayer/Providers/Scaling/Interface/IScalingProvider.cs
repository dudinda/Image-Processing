using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface
{
    public interface IScalingProvider
    {
        Bitmap Scale(Bitmap bmp, double yScale, double xScale);
    }
}
