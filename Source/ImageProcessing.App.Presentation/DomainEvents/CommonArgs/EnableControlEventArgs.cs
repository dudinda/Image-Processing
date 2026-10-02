using ImageProcessing.App.Presentation.Code.Enums;

namespace ImageProcessing.App.Presentation.DomainEvents.CommonArgs
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
