using System;
using System.Linq;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.Common.Extensions.EnumExtensions;
using ImageProcessing.Utility.Interop.Code.Wrapper;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.ServiceLayer.Services.EventAggregator.Interface;
using ImageProcessing.App.UILayer.Form.Base;

namespace ImageProcessing.App.UILayer.Form.Convolution
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
