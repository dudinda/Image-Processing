using System;
using System.Linq;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Interop.Code.Wrapper;
using ImageProcessing.PresentationLayer.Views.Convolution;
using ImageProcessing.UILayer.Form.Base;

namespace ImageProcessing.UILayer.Form.Convolution
{
    internal sealed partial class ConvolutionFilterForm : BaseForm, IConvolutionFilterView
    {
        public ConvolutionFilterForm(IEventAggregator eventAggregator)
            : base(eventAggregator)
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

        public ConvolutionFilter SelectedFilter
        {
            get => ConvolutionFilterComboBox
                .SelectedItem
                .ToString()
                .GetValueFromDescription<ConvolutionFilter>();
        }

        public void ShowError(string error)
             => ErrorToolTip.Show(error, this, PointToClient(
                 CursorPosition.GetCursorPosition()), 2000
             );
    }
}
