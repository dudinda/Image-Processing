
using System;
using System.Runtime.CompilerServices;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Form.Base;
using ImageProcessing.Presentation.Views.Convolution;

[assembly: InternalsVisibleTo("ImageProcessing.Tests")]
namespace ImageProcessing.UI.Form.Convolution
{
    internal sealed partial class ConvolutionFilterForm : BaseForm, IConvolutionFilterView
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
