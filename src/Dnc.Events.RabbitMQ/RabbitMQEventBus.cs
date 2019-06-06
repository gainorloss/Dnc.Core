using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public class RabbitMQEventBus
        : IEventBus
    {
        private readonly IEventHandlerExecutionContext _ctx;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;
        private readonly string _exchangeName = Guid.NewGuid().ToString("N");
        public RabbitMQEventBus(IEventHandlerExecutionContext ctx, IConfiguration configuration)
        {
            _ctx = ctx;
            var options = new RabbitMQOptions();
            configuration.GetSection(nameof(RabbitMQOptions)).Bind(options);
            _connectionFactory = new ConnectionFactory()
            {
                HostName = options.HostName,
                Port = options.Port,
                UserName = options.UserName,
                Password = options.Password,
                VirtualHost = options.VirtualHost,
            };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _queueName = _channel.QueueDeclare().QueueName;
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (sender, e) =>
            {
                var json = Encoding.UTF8.GetString(e.Body);
                var @event = (IEvent)JsonConvert.DeserializeObject(json);
                await _ctx.HandleAsync(@event);
            };
            _channel.BasicConsume(_queueName, true, consumer);
        }

        public Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));
            _channel.BasicPublish(_exchangeName, @event.GetType().FullName, null, bytes);
            return Task.CompletedTask;
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : IEvent
            where TEventHandler : IEventHandler<TEvent>
        {
            if (_ctx.HandlerRegistered<TEvent, TEventHandler>())
                return;
            _ctx.RegisterHandler<TEvent, TEventHandler>();
            _channel.QueueBind(_queueName, _exchangeName, typeof(TEvent).FullName);
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _channel.Dispose();
                    _connection.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose() => Dispose(true);
        #endregion
    }
}
