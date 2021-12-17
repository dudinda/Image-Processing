using System;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;
using ImageProcessing.App.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Forms.Rotation
{
    internal partial class RotationForm : BaseForm,
        IRotationView, IRotationFormExposer
    {
        private readonly IRotationFormEventBinder _binder;
        private readonly IMainFormExposer _main;
        private readonly MetroTabPage _tab = new MetroTabPage();

        public RotationForm(
            IMainView main,
            IRotationFormEventBinder binder)
        {
            InitializeComponent();
            PopulateComboBox<RotationMethod>(RotationComboBox);

            _main = main as IMainFormExposer;

            TopLevel = false;
            Dock = DockStyle.Fill;
            Parent = _tab;

            _tab.Controls.Add(this);
            _tab.Text = Text;

            _binder = binder;
            _binder.OnElementExpose(this);
        }

        public new void Show()
        {
            _main.TabsCtrl.TabPages.Add(_tab);
            _main.TabsCtrl.SelectedTab = _tab;

            base.Show();
        }

        public new void Close()
        {
            var idx = _main.TabsCtrl.SelectedIndex;

            if (_main.TabsCtrl.SelectedIndex != 0)
            {
                _main.TabsCtrl.SelectedTab = _main.TabsCtrl.TabPages[idx - 1];
            }

            _main.TabsCtrl.TabPages.RemoveAt(idx);

            base.Close();
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
            => Math.PI * Convert.ToDouble(DegreesTextBox.Text) / 180;

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
