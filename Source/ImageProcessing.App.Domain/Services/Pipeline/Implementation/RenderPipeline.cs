using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

using MessageLoop.Common.Models.LongRun;
using MessageLoop.Common.Services.LongRun;
using MessageLoop.Service.Services.Message;

namespace ImageProcessing.App.Domain.Services.Pipeline.Implementation
{
    public class RenderPipeline : IRenderPipeline
    {
        private readonly ILongRunService<LongRunItem> _service;
        private readonly IMessageService<Task<object>> _message;
        private readonly Channel<Task<object>> _channel;
        private readonly CancellationTokenSource _source = new ();

        public RenderPipeline(
            IMessageService<Task<object>> message,
            ILongRunService<LongRunItem> service,
            BoundedChannelOptions options)
        {
            _message = message;
            _channel = Channel.CreateBounded<Task<object>>(options);
            _message.Add(nameof(RenderPipeline), _channel);
            _service = service;
        }

        public bool Any()
            => _channel.Reader.Count > 0;

        public void Register(IPipelineBlock output)
        {
            var task = new Task<object>(() => output.Process(_source.Token), _source.Token);
            task.Start();
            _message.SendMessage(nameof(RenderPipeline), task);
        }

        public void BeginRender()
        {
            _service.PutTask(async (token) =>
            {
                var source = CancellationTokenSource.CreateLinkedTokenSource(_source.Token);
                await foreach(var task in _channel.Reader.ReadAllAsync(source.Token))
                {
                    await task.ConfigureAwait(false);
                }

                return Task.CompletedTask;
            });
        }

        public void Dispose()
        {
            _source.Dispose();
            _message.Dispose();
        }
    }
}
