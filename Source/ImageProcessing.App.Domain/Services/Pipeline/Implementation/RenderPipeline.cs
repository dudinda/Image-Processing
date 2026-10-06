using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

using MessageLoop.Service.Services.Message;

namespace ImageProcessing.App.Domain.Services.Pipeline.Implementation
{
    public class RenderPipeline : IRenderPipeline
    {
        private readonly IMessageService<Task<object>> _message;
        private readonly Channel<Task<object>> _channel;
        private readonly CancellationTokenSource _source = new ();

        public RenderPipeline(
            IMessageService<Task<object>> message,
            BoundedChannelOptions options)
        {
            _message = message;
            _channel = Channel.CreateBounded<Task<object>>(options);
            _message.Add(nameof(RenderPipeline), _channel);
        }

        public void Register(IPipelineBlock output)
        {
            var task = new Task<object>(() => output.Process(_source.Token), _source.Token);
            task.Start();
            _message.SendMessage(nameof(RenderPipeline), task);
        }

        public async Task<object> Render()
        {
            if (_channel.Reader.TryRead(out var task))
            {
                return await task.ConfigureAwait(false);
            }

            throw new InvalidOperationException();
        }

        public bool Any()
            => _channel.Reader.Count > 0;

        public void Dispose()
        {
            _source.Cancel();
            _message.Dispose();
            _source.Dispose();
        }
    }
}
