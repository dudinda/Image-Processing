
using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.EnumExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.DomainModel.EventArgs.Convolution;
using ImageProcessing.Presentation.Views.Convolution;

using MetroFramework.Forms;

namespace ImageProcessing.UI.Form.Convolution
{
    public partial class ConvolutionFilterForm : MetroForm, IConvolutionFilterView
    {
        private readonly IEventAggregator _eventAggregator;
        public ConvolutionFilterForm(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            var values = default(ConvolutionFilter).GetEnumValuesExceptDefault();
            ConvolutionFilterComboBox.Items.AddRange(Array.ConvertAll(values, item => (object)item));
            ConvolutionFilterComboBox.SelectedIndex = 0;

            _eventAggregator = Requires.IsNotNull(eventAggregator, nameof(eventAggregator));

            Apply.Click += (sender, args) => _eventAggregator.Publish(new ConvolutionFilterEventArgs());
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
