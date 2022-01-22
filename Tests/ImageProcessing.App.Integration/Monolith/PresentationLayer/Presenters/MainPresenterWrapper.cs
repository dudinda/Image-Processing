using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.PresentationLayer.Views;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Pipeline.Interface;
using ImageProcessing.App.PresentationLayer.Code.Constants;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Container;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Code.Extensions;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Presenters
{
    internal class MainPresenterWrapper : BasePresenter<IMainViewWrapper>,
        ISubscriber<AttachBlockToRendererEventArgs>, ISubscriber<ShowConvolutionMenuEventArgs>,
        ISubscriber<ShowDistributionMenuEventArgs>, ISubscriber<ShowRgbMenuEventArgs>,
        ISubscriber<ShowSettingsMenuEventArgs>, ISubscriber<ShowTransformationMenuEventArgs>,
        ISubscriber<OpenFileDialogEventArgs>, ISubscriber<SaveAsFileDialogEventArgs>,
        ISubscriber<SaveWithoutFileDialogEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<ReplaceImageEventArgs>, ISubscriber<TrackBarEventArgs>,
        ISubscriber<UndoRedoEventArgs>, ISubscriber<FormIsClosedEventArgs>,
        ISubscriber<ShowRotationMenuEventArgs>, ISubscriber<ShowScalingMenuEventArgs>
    {
        public ICacheServiceWrapper Cache { get; }
        public INonBlockDialogServiceWrapper Dialog { get; }
        public IAwaitablePipelineServiceWrapper Pipeline { get; }
        public IAsyncOperationLockerWrapper Locker { get; }
        public IScalingProviderWrapper Scaling { get; }
        public IRotationProviderWrapper Rotation { get; }
        public ILoggerServiceWrapper Logger { get; }

        public MainPresenterWrapper(
            ICacheServiceWrapper cache,
            INonBlockDialogServiceWrapper dialog,
            IAwaitablePipelineServiceWrapper pipeline,
            IAsyncOperationLockerWrapper locker,
            ILoggerServiceWrapper logger,
            IScalingProviderWrapper scaling,
            IRotationProviderWrapper rotation) 
        {
            Cache = cache;
            Dialog = dialog;
            Pipeline = pipeline;
            Locker = locker;
            Scaling = scaling;
            Logger = logger;
            Rotation = rotation;
        }

        public virtual  Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="SaveAsFileDialogEventArgs"/>
        public Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="SaveWithoutFileDialogEventArgs"/>
        public virtual Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowRgbMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowScalingMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowScalingMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowRotationMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowRotationMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowDistributionMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowDistributionMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowConvolutionMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowTransformationMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowTransformationMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowSettingsMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowSettingsMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="AttachBlockToRendererEventArgs"/>
        public virtual Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ReplaceImageEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ReplaceImageEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="TrackBarEventArgs"/>
        public virtual Task OnEventHandler(object publisher, TrackBarEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="UndoRedoEventArgs"/>
        public virtual Task OnEventHandler(object publisher, UndoRedoEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
