using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;
using ImageProcessing.App.UILayer.Code.Extensions;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.App.UILayer.FormExposers.Rgb;
using ImageProcessing.Utility.Interop.Wrapper;

using MetroFramework.Controls;

using static ImageProcessing.App.DomainLayer.Code.Enums.RgbChannels;

namespace ImageProcessing.App.UILayer.Forms.Rgb
{
    internal partial class RgbForm : BaseForm,
        IRgbFormExposer, IRgbView
    {
        private readonly IRgbFormEventBinder _binder;
        private readonly IMainFormExposer _main;
        private readonly MetroTabPage _tab = new MetroTabPage();

        public RgbForm(
            IMainView main,
            IRgbFormEventBinder binder) : base()
        {
            InitializeComponent();
            PopulateComboBox<RgbFltr>(RgbFilterComboBox);

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

        /// <inheritdoc/>
        public RgbFltr Dropdown
        {
            get => RgbFilterComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<RgbFltr>();
        }

        /// <inheritdoc/>
        public MetroCheckBox RedButton
            => RedColor;

        /// <inheritdoc/>
        public MetroCheckBox GreenButton
            => GreenColor;

        /// <inheritdoc/>
        public MetroCheckBox BlueButton
            => BlueColor;

        /// <inheritdoc/>
        public MetroButton ApplyFilterButton
            => ApplyFilter;

        /// <inheritdoc/>
        public MetroButton ColorMatrixMenuButton
            => ColorMatrixMenu;
             
        /// <inheritdoc/>
        public void Tooltip(string message)
           => ShowToolTip.Show(message, this, PointToClient(
                 CursorPosition.GetCursorPosition()), 2000);

        /// <inheritdoc/>
        public RgbChannels GetSelectedChannels()
        {
            var result = Unknown;

            if (RedButton.Checked) { result |= Red; }
            if (BlueButton.Checked) { result |= Blue; }
            if (GreenButton.Checked) { result |= Green; }

            if (result == Unknown)
            {
                result |= Green | Blue | Red;
            }

            return result;
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

        public void EnableControls(bool isEnabled)
        {
            Write(() => RgbButtonsPanel.Enable(isEnabled));
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
               .Unsubscribe(typeof(RgbPresenter), this);

            base.Dispose(true);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(_binder.ProcessCmdKey(this, keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
