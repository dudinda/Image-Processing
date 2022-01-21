using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;
using ImageProcessing.App.UILayer.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Forms.Scaling
{
    internal partial class ScalingForm : BaseForm,
        IScalingView, IScalingFormExposer
    {
        private readonly IMainFormExposer _main;
        private readonly IScalingFormEventBinder _binder;
        private readonly MetroTabPage _tab = new MetroTabPage();

        public ScalingForm(
            IMainView main,
            IScalingFormEventBinder binder)
        {
            InitializeComponent();
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

        public (string, string) Parameters
            => (XScaleTextBox.Text, YScaleTextBox.Text);

        public ScalingMethod Dropdown
        {
            get => ScalingComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<ScalingMethod>();
        }

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
               .Unsubscribe(typeof(ScalingPresenter), this);

            base.Dispose(true);
        }

        public MetroButton ScaleButton
            => ResizeButton;

        public void Tooltip(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
