using System;
using System.Linq;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Presenters.Convolution;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Convolution;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Form.Convolution
{
    /// <inheritdoc cref="IConvolutionView"/>
    internal sealed partial class ConvolutionForm
        : BaseForm, IConvolutionFormExposer
    {
        private readonly IConvolutionFormEventBinder _binder;

        public ConvolutionForm(
            IAppController controller,
            IConvolutionFormEventBinder binder) : base(controller)
        {
            InitializeComponent();

            var values = default(ConvolutionFilter)
                .GetAllEnumValues()
                .Select(val => val.GetDescription())
                .ToArray();

            ConvolutionFilterComboBox.Items.AddRange(
                 Array.ConvertAll(values, item => (object)item)
             );

            ConvolutionFilterComboBox.SelectedIndex = 0;

            _binder = binder;

            _binder.OnElementExpose(this);
        }

        /// <inheritdoc/>
        public ConvolutionFilter Dropdown
        {
            get => ConvolutionFilterComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<ConvolutionFilter>();
        }

        public MetroButton ApplyButton
            => Apply;

        /// <inheritdoc/>
        public void Tooltip(string message)
             => ErrorToolTip.Show(message, this, PointToClient(
                 CursorPosition.GetCursorPosition()), 2000
             );

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
                .Unsubscribe(typeof(ConvolutionPresenter), this);

            base.Dispose(true);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_binder.ProcessCmdKey(this, keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
