using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.Settings;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions.EnumExt;
using ImageProcessing.App.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.UILayer.FormExposers.Settings;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Forms.Settings
{
    internal sealed partial class SettingsForm : BaseForm,
        ISettingsView, ISettingsFormExposer
    {
        private readonly ISettingsFormEventBinder _binder;

        public SettingsForm(
            IAppController controller,
            ISettingsFormEventBinder binder) : base(controller)
        {
            InitializeComponent();

            PopulateComboBox<Luma>(LumaComboBox);
            PopulateComboBox<RotationMethod>(RotationComboBox);
            PopulateComboBox<ScalingMethod>(ScalingComboBox);

            _binder = binder;
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

