using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Presenters.ColorMatrix;
using ImageProcessing.App.PresentationLayer.Views.ColorMatrix;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions.EnumExt;
using ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormExposers.ColorMatrix;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Forms.ColorMatrix
{
    internal sealed partial class ColorMatrixForm : BaseForm,
        IColorMatrixView, IColorMatrixFormExposer
    {
        private readonly IColorMatrixEventBinder _binder;

        public ColorMatrixForm(
            IColorMatrixEventBinder binder) : base()
        {
            InitializeComponent();  
            PopulateComboBox<ClrMatrix>(ColorMatrixComboBox);

            _binder = binder;
            _binder.OnElementExpose(this);

            for (var row = 0; row < ColorMatrixGrid.ColumnCount; ++row)
            {
                ColorMatrixGrid.Rows.Add(0, 0, 0, 0, 0);
                ColorMatrixGrid.Rows[row].HeaderCell.Value = ColorMatrixGrid.Columns[row].HeaderCell.Value;
            }
        }
          
        public ClrMatrix Dropdown
        {
            get => ColorMatrixComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<ClrMatrix>();
        }

        /// <inheritdoc/>
        public MetroButton ApplyButton
            => ApplyColorMatrixButton;

        /// <inheritdoc/> 
        public MetroCheckBox CustomCheckBox
            => CustomColorMatrix;

        /// <inheritdoc/>
        public MetroComboBox ColorMatrixDropDown
            => ColorMatrixComboBox;

        /// <inheritdoc/>
        public MetroButton ApplyCustomButton
            => ApplyCustomColorMatrixButton;
          
        public void SetEnabledDropDown(bool isEnabled)
            => ColorMatrixComboBox.Enabled = isEnabled;

        public void SetVisibleApply(bool isVisible)
            => ApplyColorMatrixButton.Visible = isVisible;

        public void SetVisibleApplyCustom(bool isVisible)
            => ApplyCustomColorMatrixButton.Visible = isVisible;

        /// <inheritdoc/>
        public void Tooltip(string message)
            => ErrorToolTip.Show(message, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000);

        public void SetEnabledCells(bool isReadOnly)
        {
            var rows = ColorMatrixGrid.Rows.Count;
            var cols = ColorMatrixGrid.ColumnCount;

            for (var row = 0; row < rows; ++row)
            {
                for (var col = 0; col < cols; ++col)
                {
                    ColorMatrixGrid[col, row].ReadOnly = isReadOnly;
                }
            }
        }

        public void SetGrid(ReadOnly2DArray<double> matrix)
        {
            for (var row = 0; row < matrix.RowCount; ++row)
            {
                for (var col = 0; col < matrix.ColumnCount; ++col)
                {
                    ColorMatrixGrid[col, row].Value = matrix[row, col];
                }
            }
        }

        public ReadOnly2DArray<double> GetGrid()
        {
            var rows = ColorMatrixGrid.RowCount;
            var cols = ColorMatrixGrid.ColumnCount;

            var matrix = new double[rows, cols];

            for (var row = 0; row < rows; ++row)
            {
                for (var col = 0; col < cols; ++col)
                {
                    matrix[row, col] = Convert.ToDouble(ColorMatrixGrid[col, row].Value);
                }
            }

            return new ReadOnly2DArray<double>(matrix);
        }

        public new void Show()
        {
            Focus();
            base.Show();
        }

        /// <summary>
        /// Used by the generated <see cref="Dispose(bool)"/> call.
        /// Can be used by a DI container in a singleton scope on Release();
        public new void Dispose()
        {
            if (components != null)
            {
                components.Dispose();
            }

            Controller
               .Aggregator
               .Unsubscribe(typeof(ColorMatrixPresenter), this);

            base.Dispose(true);
        }
    }
}
