using System.Collections.Generic;
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
        private readonly LongRunContext _context;
        private HashSet<LongRunToken> _renders = new();
  

        public RenderPipeline(
            IMessageService<Task<object>> message,
            ILongRunService<LongRunItem> service,
            LongRunContext context,
            BoundedChannelOptions options)
        {
            _message = message;
            _context = context;
            _service = service;
            _channel = Channel.CreateBounded<Task<object>>(options);
            _message.Add(nameof(RenderPipeline), _channel);
            _context.Cancellation?.Value = new CancellationTokenSource();
        }

        public bool Any()
            => _channel.Reader.Count > 0;

        public void Register(IPipelineBlock output)
        {
            var token = _context.Cancellation.Value.Token;
            var task = new Task<object>(() => output.Process(token), token);
            _message.SendMessage(nameof(RenderPipeline), task);
        }

        public void BeginRender()
        {
            var token = _service.PutTask(async (token) =>
            {
                await foreach(var task in _channel.Reader.ReadAllAsync(token))
                {
                    task.Start();
                    await task.ConfigureAwait(false);
                }

                return Task.CompletedTask;
            });
            _renders.Add(token);
        }

        public void Dispose()
        {
            foreach(var render in _renders)
            {
                _service.Abort(render);
            }
            _message.Dispose();
        }
    }
}
