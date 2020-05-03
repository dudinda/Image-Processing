using System;
using System.Linq;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.UILayer.Form.Base;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

namespace ImageProcessing.App.UILayer.Form.Convolution
{
    /// <inheritdoc cref="IConvolutionFilterView"/>
    internal sealed partial class ConvolutionFilterForm : BaseForm, IConvolutionFilterView
    {
        public ConvolutionFilterForm(IAppController controller)
            : base(controller)
        {
            InitializeComponent();

            var values = default(ConvolutionFilter)
                .GetEnumValuesExceptDefault()
                .Select(val => val.GetDescription())
                .ToArray();

            ConvolutionFilterComboBox.Items.AddRange(
                Array.ConvertAll(values, item => (object)item)
            );

            ConvolutionFilterComboBox.SelectedIndex = 0;

            Bind();
        }

        /// <inheritdoc/>
        public ConvolutionFilter SelectedFilter
        {
            get => ConvolutionFilterComboBox
                .SelectedItem
                .ToString()
                .GetValueFromDescription<ConvolutionFilter>();
        }

        /// <inheritdoc/>
        public void ShowError(string error)
             => ErrorToolTip.Show(error, this, PointToClient(
                 CursorPosition.GetCursorPosition()), 2000
             );

        public new void Dispose()
        {
            if (components != null)
            {
                components.Dispose();
            }

            base.Dispose(true);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
