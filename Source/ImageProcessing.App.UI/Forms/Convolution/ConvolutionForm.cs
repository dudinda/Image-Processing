using System.Windows.Forms;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Code.Extensions;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.App.UI.Code.Extensions;
using ImageProcessing.App.UI.Services.FormEventBinders.Convolution;
using ImageProcessing.App.UI.Services.FormExposers;
using ImageProcessing.Utility.Interop.Models.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UI.Forms.Convolution
{
    /// <inheritdoc cref="IConvolutionView"/>
    internal partial class ConvolutionForm : BaseForm,
        IConvolutionFormExposer, IConvolutionView
    {
        private readonly IConvolutionFormEventBinder _binder;
        private readonly IMainFormExposer _main;
        private readonly MetroTabPage _tab = new MetroTabPage();

        public ConvolutionForm(
            IMainView main,
            IConvolutionFormEventBinder binder) : base()
        {
            InitializeComponent();
            PopulateComboBox<ConvKernel>(ConvolutionFilterComboBox);
            _main = main as IMainFormExposer;

            TopLevel = false;
            Dock = DockStyle.Fill;
            Parent = _tab;

            _tab.Controls.Add(this);
            _tab.Text = Text;

            _binder = binder;
            _binder.OnElementExpose(this);

            BringToFront();
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

        /// <inheritdoc/>
        public ConvKernel Dropdown
        {
            get => ConvolutionFilterComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<ConvKernel>();
        }

        public void EnableControls(bool isEnabled)
        {
            Write(() => ConvoltuionButtonPanel.Enable(isEnabled));
        }

        public MetroButton ApplyButton
            => Apply;

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
                .Unsubscribe(typeof(ConvolutionPresenter), this);

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
