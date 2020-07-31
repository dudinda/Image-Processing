using System;
using System.Linq;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Presenters.Convolution;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
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
                .GetAllEnumValues()
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
                .SelectedItem.ToString()
                .GetValueFromDescription<ConvolutionFilter>();
        }

        /// <inheritdoc/>
        public void ShowError(string error)
             => ErrorToolTip.Show(error, this, PointToClient(
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

            Controller.Aggregator
                .Unsubscribe(typeof(ConvolutionFilterPresenter), this);

            base.Dispose(true);
        }
    }
}
