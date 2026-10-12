using System.Drawing;

namespace ImageProcessing.App.Presentation.DomainEvents.MainArgs.Toolbar
{
    public class MouseUpEventArgs(Point position) : BaseEventArgs
    {
        public Point Position { get; } = position;

    }
}
