using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Convolution;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Forms.Convolution
{
    /// <inheritdoc cref="IConvolutionView"/>
    internal sealed partial class ConvolutionForm : BaseForm,
        IConvolutionFormExposer, IConvolutionView
    {
        private readonly IConvolutionFormEventBinder _binder;
        private readonly IMainFormExposer _main;
        private readonly TabPage _tab = new TabPage();

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
