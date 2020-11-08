using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.PresentationLayer.Views.Settings;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.App.UILayer.FormEventBinder.Settings.Interface;
using ImageProcessing.App.UILayer.FormExposer.Settings;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Form.Settings
{
    internal sealed partial class SettingsForm : BaseForm,
        ISettingsView, ISettingsFormExposer
    {
        private readonly IAppSettings _settings;
        private readonly ISettingsFormEventBinder _binder;

        public SettingsForm(
            IAppController controller,
            ISettingsFormEventBinder binder,
            IAppSettings settings) : base(controller)
        {
            InitializeComponent();

            PopulateComboBox<Luma>(LumaComboBox);
            PopulateComboBox<RotationMethod>(RotationComboBox);
            PopulateComboBox<ScalingMethod>(ScalingComboBox);

            _binder = binder;
            _settings = settings;

            _binder.OnElementExpose(this);
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

        public Luma Rec
            => ThirdDropdown;

        public RotationMethod Rotation
            => FirstDropdown;

        public ScalingMethod Scaling
            => SecondDropdown;

        public new void Show()
        {
            Focus();
            base.Show();
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

