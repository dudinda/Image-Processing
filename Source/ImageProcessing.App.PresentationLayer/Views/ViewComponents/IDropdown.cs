using System;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponents
{
    public interface IDropdown<TEnum>
        where TEnum : Enum
    {
        /// <summary>
        /// Dropdown from the <see cref="TEnum"/> description.
        /// </summary>
        TEnum Dropdown { get; }
    }

    public interface IDropdown<TEnum1, TEnum2>
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        /// <summary>
        /// Dropdown from the <see cref="TEnum1"/> description.
        /// </summary>
        TEnum1 FirstDropdown { get; }

        /// <summary>
        /// Dropdown from the <see cref="TEnum1"/> description.
        /// </summary>
        TEnum2 SecondDropdown { get; }
    }

    public interface IDropdown<TEnum1, TEnum2, TEnum3>
        where TEnum1 : Enum
        where TEnum2 : Enum
        where TEnum3 : Enum
    {
        /// <summary>
        /// Dropdown from the <see cref="TEnum1"/> description.
        /// </summary>
        TEnum1 FirstDropdown { get; }

        /// <summary>
        /// Dropdown from the <see cref="TEnum2"/> description.
        /// </summary>
        TEnum2 SecondDropdown { get; }

        /// <summary>
        /// Dropdown from the <see cref="TEnum3"/> description.
        /// </summary>
        TEnum3 ThirdDropdown { get; }
    }
}
