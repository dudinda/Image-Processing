using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;
using ImageProcessing.App.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.App.UILayer.FormExposers.Settings;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Forms.Settings
{
    internal partial class SettingsForm : BaseForm,
        ISettingsView, ISettingsFormExposer
    {
        private readonly ISettingsFormEventBinder _binder;
        private readonly IMainFormExposer _main;
        private readonly MetroTabPage _tab = new MetroTabPage();

        public SettingsForm(
            IMainView main,
            ISettingsFormEventBinder binder) : base()
        {
            InitializeComponent();

            PopulateComboBox<Luma>(LumaComboBox);
            PopulateComboBox<RotationMethod>(RotationComboBox);
            PopulateComboBox<ScalingMethod>(ScalingComboBox);

            _main = main as IMainFormExposer;

            TopLevel = false;
            Dock = DockStyle.Fill;
            AutoSize = false;
            Parent = _tab;

            _tab.Controls.Add(this);
            _tab.Text = Text;

            _binder = binder;
            _binder.OnElementExpose(this);

            BringToFront();
        }
          
        public RotationMethod FirstDropdown
        {
            get => RotationComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<RotationMethod>();
        }

        public ScalingMethod SecondDropdown
        {
            get => ScalingComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<ScalingMethod>();
        }

        public Luma ThirdDropdown
        {
            get => LumaComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<Luma>();
        }

        public MetroComboBox LumaDropDown
            => LumaComboBox;

        public MetroComboBox ScalingDropDown
            => ScalingComboBox;

        public MetroComboBox RotationDropDown
            => RotationComboBox;

        public new void Show()
        {
            if (!_main.TabsCtrl.TabPages.Contains(_tab))
            {
                _main.TabsCtrl.TabPages.Add(_tab);
                _main.TabsCtrl.SelectedTab = _tab;
            }

            base.Show();
        }

        public new void Hide()
        {
            var idx = _main.TabsCtrl.SelectedIndex;

            if (_main.TabsCtrl.SelectedIndex != 0)
            {
                _main.TabsCtrl.SelectedTab = _main.TabsCtrl.TabPages[idx - 1];
            }

            _main.TabsCtrl.TabPages.RemoveAt(idx);

            base.Hide();
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
        }

        /// <summary>
        /// Used by a DI container to dispose the singleton form
        /// on Release().
        public new void Dispose()
        {
            if (components != null)
            {
                components.Dispose();
            }

            base.Dispose(true);
        }

        /// <summary>
        /// Restrict the generated <see cref="Dispose(bool)"/> call
        /// on a non-context form closing.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}

