using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormExposers;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Forms.Scaling
{
    internal sealed partial class ScalingForm : BaseForm,
        IScalingView, IScalingFormExposer
    {
        public ScalingForm()
        {
            InitializeComponent();
        }

        public (string, string) Parameters => throw new System.NotImplementedException();

        public ScalingMethod Dropdown => throw new System.NotImplementedException();

        public MetroButton ScaleButton => throw new System.NotImplementedException();

        public void Tooltip(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
