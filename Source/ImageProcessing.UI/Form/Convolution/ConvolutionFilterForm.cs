
using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Form.Base;
using ImageProcessing.Presentation.Views.Convolution;

namespace ImageProcessing.UI.Form.Convolution
{
    public partial class ConvolutionFilterForm : BaseForm, IConvolutionFilterView
    {
        public ConvolutionFilterForm(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            InitializeComponent();

            var values = default(ConvolutionFilter).GetEnumValuesExceptDefault();
            ConvolutionFilterComboBox.Items.AddRange(Array.ConvertAll(values, item => (object)item));
            ConvolutionFilterComboBox.SelectedIndex = 0;

            Bind();
        }

        public ConvolutionFilter SelectedFilter
        {
            get => ConvolutionFilterComboBox
                .SelectedItem
                .ToString()
                .GetEnumValueByName<ConvolutionFilter>();
        }

        public void ShowError()
        {
            throw new NotImplementedException();
        }
    }
}
