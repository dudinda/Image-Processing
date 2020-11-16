using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Presenters.ColorMatrix;
using ImageProcessing.App.PresentationLayer.Views.ColorMatrix;
using ImageProcessing.App.UILayer.FormEventBinder.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormExposer.ColorMatrix;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Form.ColorMatrix
{
    internal sealed partial class ColorMatrixForm : BaseForm,
        IColorMatrixView, IColorMatrixFormExposer
    {
        private readonly IColorMatrixEventBinder _binder;

        public ColorMatrixForm(
            IAppController controller,
            IColorMatrixEventBinder binder) : base(controller)
        {
            InitializeComponent();  
            PopulateComboBox<ClrMatrix>(ColorMatrixComboBox);

            _binder = binder;
            _binder.OnElementExpose(this);

            for(var row = 0; row < ColorMatrixGrid.ColumnCount; ++row)
            {
                ColorMatrixGrid.Rows.Add(0, 0, 0, 0, 0);
                ColorMatrixGrid.Rows[row].HeaderCell.Value = row.ToString();
            }
        }
          
        public ClrMatrix Dropdown
        {
            get => ColorMatrixComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<ClrMatrix>();
        }

        public MetroButton ApplyButton
            => ApplyColorMatrixButton;

        public MetroCheckBox CustomCheckBox
            => CustomColorMatrix;

        public void SetEnabledCells(bool isReadOnly)
        {
            var rows = ColorMatrixGrid.Rows.Count;
            var cols = ColorMatrixGrid.ColumnCount;

            for(var row = 0; row < rows; ++row)
            {
                for(var col = 0; col < cols; ++col)
                {
                    ColorMatrixGrid[col, row].ReadOnly = isReadOnly;
                }
            } 
        }
           
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

        /// <inheritdoc/>
        public void Tooltip(string message) { }
    }
}

