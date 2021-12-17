using System;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.PresentationLayer.Views;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormExposers.ColorMatrix;
using ImageProcessing.App.UILayer.Forms.ColorMatrix;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UILayer.Forms
{
    internal class ColorMatrixFormWrapper : IColorMatrixViewWrapper, IColorMatrixFormExposer
    {
        private class NonUIColorMatrixForm : ColorMatrixForm
        {
            public NonUIColorMatrixForm(
                IMainViewWrapper main,
                IColorMatrixFormEventBinderWrapper binder) : base(main, binder)
            {
                
            }

            protected override void Write(Action action)
                => action();
            protected override TElement Read<TElement>(Func<object> func)
                => (TElement)func();
        }

        private readonly NonUIColorMatrixForm _form;
 
        public ColorMatrixFormWrapper(
            IMainViewWrapper main,
            IColorMatrixFormEventBinderWrapper binder)
        {
            _form = new NonUIColorMatrixForm(main, binder);
        }

        public virtual ClrMatrix Dropdown
            => _form.Dropdown;

        public virtual MetroButton ApplyButton
            => _form.ApplyButton;

        public virtual MetroButton ApplyCustomButton
            => _form.ApplyCustomButton;

        public virtual MetroCheckBox CustomCheckBox
            => _form.CustomCheckBox;

        public virtual MetroComboBox ColorMatrixDropDown
            => _form.ColorMatrixDropDown;

        public virtual event FormClosedEventHandler FormClosed
        {
            add
            {
                _form.FormClosed += value;
            }
            remove
            {
                _form.FormClosed -= value;
            }
        }

        public virtual void Close()
            => _form.Close();

        public virtual bool Focus()
            => _form.Focus();

        public virtual ReadOnly2DArray<double> GetGrid()
            => _form.GetGrid();

        public virtual void SetEnabledCells(bool isEnabled)
            => _form.SetEnabledCells(isEnabled);

        public virtual void SetEnabledDropDown(bool isEnabled)
            => _form.SetEnabledDropDown(isEnabled);

        public virtual void SetGrid(ReadOnly2DArray<double> matrix)
            => _form.SetGrid(matrix);

        public virtual void SetVisibleApply(bool isVisible)
            => _form.SetVisibleApply(isVisible);

        public virtual void SetVisibleApplyCustom(bool isVisible)
            => _form.SetVisibleApplyCustom(isVisible);
 
        public virtual void Show()
        {
            
        }

        public virtual void Tooltip(string message)
            => _form.Tooltip(message);
    }
}
