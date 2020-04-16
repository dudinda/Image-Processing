using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.Form.Base;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Code.Wrapper;

namespace ImageProcessing.App.UILayer.Form.Main
{
    /// <inheritdoc cref="IMainView"/>
    internal sealed partial class MainForm : BaseMainForm, IMainView
    {
        public MainForm(ApplicationContext context,
                        IAppController controller)
            : base(context, controller)
        {
            InitializeComponent();
            Bind();
        }

        /// <inheritdoc/>
        public Image SrcImageCopy { get; set; }

        /// <inheritdoc/>
        public Image DstImageCopy { get; set; }

        /// <inheritdoc/>
        public Image SrcImage
        {
            get => Src.Image;
            set => Src.Image = value;
        }

        /// <inheritdoc/>
        public Image DstImage
        {
            get => Dst.Image;
            set => Dst.Image = value;
        }

        /// <inheritdoc/>
        public string PathToFile
        {
            get => PathToImage.Text;
            set => PathToImage.Text = value;
        }

        /// <inheritdoc/>
        public (string, string) Parameters
            => (FirstParam.Text, SecondParam.Text);

        /// <inheritdoc/>
        public new void Show()
        {
            Context.MainForm = this;
            Application.Run(Context);
        }

        /// <inheritdoc/>
        public void AddToUndoMainMetaInfo((Bitmap changed, ImageContainer from) action)
            => Container.Add(action);

        /// <inheritdoc/>
        public (Bitmap changed, ImageContainer from)? UndoAction()
            => Container.Undo();

        /// <inheritdoc/>
        public (Bitmap changed, ImageContainer from)? RedoAction()
            => Container.Redo();

        /// <inheritdoc/>
        public RgbColors GetSelectedColors(RgbColors color)
        {
            _command[
                 color.ToString()
            ].Method.Invoke(this, null);

            return (RgbColors)_command[
                 nameof(MainViewAction.GetColor)
            ].Method.Invoke(this, null);
        }

        /// <inheritdoc/>
        public void ShowInfo(string info)
            => RandomVariableInformation.Show(info, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        /// <inheritdoc/>
        public void ShowError(string error)
            => ErrorToolTip.Show(error, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        /// <inheritdoc/>
        public void AddToQualityMeasureMainMetaInfo(Bitmap transformed)
            => QualityMeasure.Add(transformed);

        /// <inheritdoc/>
        public void ResetTrackBarValue(ImageContainer container, int value = 0, bool isEnabled = true)
            => _command[
                container.ToString() + nameof(MainViewAction.ResetTrackBar)
            ].Method.Invoke(this, new object[] { value, isEnabled });

        /// <inheritdoc/>
        public Image ZoomImage(ImageContainer container)
            => _command[
                container.ToString() + nameof(MainViewAction.Zoom)
            ].Method.Invoke(this, null) as Image;

        /// <inheritdoc/>
        public void SetImageToZoom(ImageContainer container, Image image)
            => _command[
                container.ToString() + nameof(MainViewAction.SetToZoom)
            ].Method.Invoke(this, new object[] { image });

        /// <inheritdoc/>
        public Image GetImageCopy(ImageContainer container)
            => _command[
                container.ToString() + nameof(MainViewAction.GetCopy)
            ].Method.Invoke(this, null) as Image;

        /// <inheritdoc/>
        public void SetImageCopy(ImageContainer container, Image copy)
            => _command[
                container.ToString() + nameof(MainViewAction.SetCopy)
            ].Method.Invoke(this, new object[] { copy });

        /// <inheritdoc/>
        public void SetImage(ImageContainer container, Image image)
            => _command[
                container.ToString() + nameof(MainViewAction.SetImage)
            ].Method.Invoke(this, new object[] { image });

        /// <inheritdoc/>
        public bool ImageIsNull(ImageContainer container)
            => (bool)_command[
                container.ToString() + nameof(MainViewAction.ImageIsNull)
            ].Method.Invoke(this, null);

        /// <inheritdoc/>
        public void Refresh(ImageContainer container)
             => _command[
                 container.ToString() + nameof(MainViewAction.Refresh)
             ].Method.Invoke(this, null);

        /// <inheritdoc/>
        public void SetCursor(CursorType cursor)
            => _command[
                cursor.ToString()
            ].Method.Invoke(this, null);

        /// <inheritdoc/>
        public void AddToUndoContainer((Bitmap changed, ImageContainer from) action)
            => Container.Add(action);

        /// <inheritdoc/>
        public void AddToQualityMeasureContainer(Bitmap transformed)
            =>  QualityMeasure.Add(transformed);     
    }
}
