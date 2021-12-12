using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;
using ImageProcessing.App.UILayer.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.App.UILayer.FormExposers.Transformation;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Forms.Transformation
{
    /// <inheritdoc cref="ITransformationView"/>
    internal sealed partial class TransformationForm : BaseForm,
        ITransformationFormExposer, ITransformationView
    {
        private readonly ITransformationFormEventBinder _binder;
        private readonly IMainFormExposer _main;
        private readonly TabPage _tab = new TabPage();

        public TransformationForm(
            IMainView main,
            ITransformationFormEventBinder binder) : base()
        {
            InitializeComponent();

            PopulateComboBox<AffTransform>(TransformationComboBox);

            _main = main as IMainFormExposer;

            TopLevel = false;
            Dock = DockStyle.Fill;
            Parent = _tab;

            _tab.Controls.Add(this);
            _tab.Text = Text;


            _binder = binder;
            _binder.OnElementExpose(this);
        }

        /// <inheritdoc/>
        public AffTransform Dropdown
        {
            get => TransformationComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<AffTransform>();
        }

        public new void Show()
        {
            _main.TabsCtrl.TabPages.Add(_tab);
            _main.TabsCtrl.SelectedTab = _tab;
            base.Show();
        }

        public new void Close()
        {
            _main.TabsCtrl.TabPages.Remove(_main.TabsCtrl.SelectedTab);
            base.Close();
        }

        public MetroButton ApplyButton
            => ApplyTransformation;

        public (string, string) Parameters
            => (XScaleTextBox.Text, YScaleTextBox.Text);

        /// <inheritdoc/>
        public void Tooltip(string message)
            => ErrorToolTip.Show(message, this, PointToClient(
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
                .Unsubscribe(typeof(TransformationPresenter), this);

            base.Dispose(true);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_binder.ProcessCmdKey(this, keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
