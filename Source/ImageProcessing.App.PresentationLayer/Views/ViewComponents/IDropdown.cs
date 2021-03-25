using System;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.Dropdown
{
    public interface IDropdown<TEnum>
        where TEnum : Enum
    {
        TEnum Dropdown { get; }
    }

    public interface IDropdown<TEnum1, TEnum2>
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        TEnum1 FirstDropdown { get; }
        TEnum2 SecondDropdown { get; }
    }

    public interface IDropdown<TEnum1, TEnum2, TEnum3>
        where TEnum1 : Enum
        where TEnum2 : Enum
        where TEnum3 : Enum
    {
        TEnum1 FirstDropdown { get; }
        TEnum2 SecondDropdown { get; }
        TEnum3 ThirdDropdown { get; }
    }
}
