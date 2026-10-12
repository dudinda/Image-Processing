using System.Drawing;

namespace ImageProcessing.App.Presentation.DomainEvents.MainArgs.Toolbar
{
    public class MouseDownEventArgs(Point start) : BaseEventArgs
    {
        public Point Start { get; } = start;
    }
}
