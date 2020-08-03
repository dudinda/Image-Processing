using System;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.Dropdown
{
    public interface IDropdown<TEnum>
        where TEnum : Enum
    {
        TEnum Dropdown { get; }
    }
}
