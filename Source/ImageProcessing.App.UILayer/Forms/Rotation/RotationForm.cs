using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;
using ImageProcessing.App.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Forms.Rotation
{
    internal sealed partial class RotationForm : BaseForm,
        IRotationView, IRotationFormExposer
    {
        private readonly IRotationEventBinder _binder;

        public RotationForm(IRotationEventBinder binder)
        {
            InitializeComponent();

            _binder = binder;
            _binder.OnElementExpose(this);
        }

        public new void Show()
        {
            Focus();
            base.Show();
        }

        public RotationMethod Dropdown
        {
            get => RotationComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<RotationMethod>();
        }

        public MetroButton RotateButton
            => ApplyRotation;

        public double Radians
            => Math.PI * Convert.ToDouble(DegreesText) / 180;

        public void Tooltip(string message)
            => ShowToolTip.Show(message, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000);

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
               .Unsubscribe(typeof(RotationPresenter), this);

            base.Dispose(true);
        }

    }
}
