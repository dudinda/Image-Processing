using System.Drawing;

namespace ImageProcessing.App.Presentation.DomainEvents.CommonArgs
{
    public class AreaSelectedEventArgs : BaseEventArgs
    {
        public Rectangle Area { get; }

        public AreaSelectedEventArgs(Rectangle area)
        {
            Area = area;
        }
    }
}
