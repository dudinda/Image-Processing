using System;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormExposers.ColorMatrix;
using ImageProcessing.App.UILayer.Forms.ColorMatrix;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UILayer.Forms
{
    internal class ColorMatrixFormWrapper : IColorMatrixView, IColorMatrixFormExposer
    {
        private readonly ColorMatrixForm _form;

        public ColorMatrixFormWrapper(
            IMainView main,
            IColorMatrixFormEventBinderWrapper binder)
        {
            _form = new ColorMatrixForm(main, binder);
        }

        public ClrMatrix Dropdown => throw new NotImplementedException();

        public MetroButton ApplyButton => throw new NotImplementedException();

        public MetroButton ApplyCustomButton => throw new NotImplementedException();

        public MetroCheckBox CustomCheckBox => throw new NotImplementedException();

        public MetroComboBox ColorMatrixDropDown => throw new NotImplementedException();

        public event FormClosedEventHandler FormClosed;

        public void Close()
        {
            throw new NotImplementedException();
        }

        public bool Focus()
        {
            throw new NotImplementedException();
        }

        public ReadOnly2DArray<double> GetGrid()
        {
            throw new NotImplementedException();
        }

        public void SetEnabledCells(bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public void SetEnabledDropDown(bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public void SetGrid(ReadOnly2DArray<double> matrix)
        {
            throw new NotImplementedException();
        }

        public void SetVisibleApply(bool isVisible)
        {
            throw new NotImplementedException();
        }

        public void SetVisibleApplyCustom(bool isVisible)
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Tooltip(string message)
        {
            throw new NotImplementedException();
        }
    }
}
