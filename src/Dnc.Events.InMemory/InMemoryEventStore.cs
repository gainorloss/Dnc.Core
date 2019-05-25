using Dnc.Serializers;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly string _connectionString;
        private readonly IMessageSerializer _messageSerializer;
        public InMemoryEventStore(IConfiguration configuration,
            IMessageSerializer messageSerializer)
        {
            _connectionString = configuration.GetConnectionString("event_store");
            _messageSerializer = messageSerializer;
        }
        public async Task SaveAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new FileNotFoundException($"event store file path is null or empty.");

            using (var sw = new StreamWriter(_connectionString, true))
            {
                await sw.WriteLineAsync(_messageSerializer.SerializeObject(@event));
            }
        }
    }
}
