using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.Form.Base;
using ImageProcessing.Microkernel.DI.Code.Attributes;
using ImageProcessing.Microkernel.DI.Code.Extensions;
using ImageProcessing.Microkernel.DI.Controller.Interface;
using ImageProcessing.Utility.Interop.Code.Wrapper;

namespace ImageProcessing.App.UILayer.Form.Main
{
    internal sealed partial class MainForm : BaseMainForm, IMainView
    {
        private static readonly Dictionary<string, CommandAttribute>
            _command = typeof(MainForm).GetCommands();

        public MainForm(ApplicationContext context,
                        IAppController controller)
            : base(context, controller)
        {
            InitializeComponent();
            Bind();
        }

        public Image SrcImageCopy { get; set; }
        public Image DstImageCopy { get; set; }

        public Image SrcImage
        {
            get => Src.Image;
            set => Src.Image = value;
        }

        public Image DstImage
        {
            get => Dst.Image;
            set => Dst.Image = value;
        }

        public string PathToFile
        {
            get => PathToImage.Text;
            set => PathToImage.Text = value;
        }

        public (string, string) Parameters
            => (FirstParam.Text, SecondParam.Text);

        public new void Show()
        {
            Context.MainForm = this;
            Application.Run(Context);
        }

        public void AddToUndoMainMetaInfo((Bitmap changed, ImageContainer from) action)
            => Container.Add(action);

        public (Bitmap changed, ImageContainer from)? UndoAction()
            => Container.Undo();

        public (Bitmap changed, ImageContainer from)? RedoAction()
            => Container.Redo();

        public RgbColors GetSelectedColors(RgbColors color)
        {
            var result = default(RgbColors);

            _command[
                 color.ToString()
            ].Method.Invoke(this, null);

            if (ColorFilterRed.Checked) result   |= RgbColors.Red;
            if (ColorFilterBlue.Checked) result  |= RgbColors.Blue;
            if (ColorFilterGreen.Checked) result |= RgbColors.Green;

            return result;
        }

        public void ShowInfo(string info)
            => RandomVariableInformation.Show(info, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        public void ShowError(string error)
            => ErrorToolTip.Show(error, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        public void AddToQualityMeasureMainMetaInfo(Bitmap transformed)
            => QualityMeasure.Add(transformed);

        public void ResetTrackBarValue(ImageContainer container, int value = 0, bool isEnabled = true)
            => _command[
                container.ToString() + nameof(MainViewAction.ResetTrackBar)
                ].Method.Invoke(this, new object[] { value, isEnabled });

        public Image ZoomImage(ImageContainer container)
            => _command[
                container.ToString() + nameof(MainViewAction.Zoom)
                ].Method.Invoke(this, null) as Image;

        public void SetImageToZoom(ImageContainer container, Image image)
         => _command[
                container.ToString() + nameof(MainViewAction.SetToZoom)
                ].Method.Invoke(this, new object[] { image });

        public Image GetImageCopy(ImageContainer container)
          => _command[
                container.ToString() + nameof(MainViewAction.GetCopy)
                ].Method.Invoke(this, null) as Image;

        public void SetImageCopy(ImageContainer container, Image copy)
            => _command[
                container.ToString() + nameof(MainViewAction.SetCopy)
                ].Method.Invoke(this, new object[] { copy });

        public void SetImage(ImageContainer container, Image image)
        => _command[
                container.ToString() + nameof(MainViewAction.SetImage)
                ].Method.Invoke(this, new object[] { image });

        public bool ImageIsNull(ImageContainer container)
        => (bool)_command[
                container.ToString() + nameof(MainViewAction.ImageIsNull)
                ].Method.Invoke(this, null);

        public void Refresh(ImageContainer container)
         => _command[
                container.ToString() + nameof(MainViewAction.Refresh)
                ].Method.Invoke(this, null);

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.ImageIsNull))]
        private bool SourceImageIsNull()
            => Src.Image is null;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ImageIsNull))]
        private bool DestinationImageIsNull()
            => Dst.Image is null;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.Refresh))]
        private void RefreshSource()
            => Src.Refresh();

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.Refresh))]
        private void RefreshDestination()
            => Dst.Refresh();

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.GetCopy))]
        private Image GetSourceCopy()
            => SrcImageCopy;

        [Command(
           nameof(ImageContainer.Source) +
           nameof(MainViewAction.SetCopy))]
        private void SetSourceCopy(Image image)
           => SrcImageCopy = image;

        [Command(
           nameof(ImageContainer.Destination) +
           nameof(MainViewAction.SetCopy))]
        private void SetDestinationCopy(Image image)
           => DstImageCopy = image;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.GetCopy))]
        private Image GetDestinationCopy()
            => DstImageCopy;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.SetImage))]
        private void SetSourceImage(Image image)
        {
            SrcImage = image;
            Undo.Enabled = true;
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.SetImage))]
        private void SetDestinationImage(Image image)
        {
            DstImage = image;
            Undo.Enabled = true;
        }

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetSourceTrackBarValue(int value = 0, bool isEnabled = true)
        {
            SrcZoom.TrackBarValue = value;
            SrcZoom.Enabled = isEnabled;
            SrcZoom.Focus();
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetDestinationTrackBarValue(int value = 0, bool isEnabled = true)
        {
            DstZoom.TrackBarValue = value;
            DstZoom.Enabled = isEnabled;
            DstZoom.Focus();
        }

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.Zoom))]
        private Image ZoomSourceImage()
            => SrcZoom.Zoom();

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.Zoom))]
        private Image ZoomDestinationImage()
           => DstZoom.Zoom();

        [Command(nameof(CursorType.Wait))]
        private void SetWaitCursor()
            => Application.UseWaitCursor = true;

        [Command(nameof(CursorType.Default))]
        private void SetDefaultCursor()
            => Application.UseWaitCursor = false;


        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.SetToZoom))]
        private Image SetToZoomSourceImage(Image image)
            => SrcZoom.ImageToZoom = image;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.SetToZoom))]
        private Image SetToZoomDestinationImage(Image image)
           => DstZoom.ImageToZoom = image;

        public void AddToUndoContainer((Bitmap changed, ImageContainer from) action)
        {
            
        }

        public void AddToQualityMeasureContainer(Bitmap transformed)
        {
            
        }

        public void SetCursor(CursorType cursor)
         => _command[
                cursor.ToString()
                ].Method.Invoke(this, null);
    }
}
