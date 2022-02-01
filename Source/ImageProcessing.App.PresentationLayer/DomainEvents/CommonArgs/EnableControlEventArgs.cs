using ImageProcessing.App.PresentationLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs
{
    public sealed class EnableControlEventArgs : BaseEventArgs
    {
        public MenuBtnState State { get; }

        public EnableControlEventArgs(MenuBtnState state) 
        {
            State = state;
        }
    }
}
