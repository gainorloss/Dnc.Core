using Dnc.Serializers;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dnc.Events
{
    public class MySqlEventStore : IEventStore
    {
        private readonly string _connectionString;
        private readonly IObjectSerializer _messageSerializer;
        public MySqlEventStore(IConfiguration configuration,
            IObjectSerializer messageSerializer)
        {
            _connectionString = configuration.GetConnectionString("event_store");
            _messageSerializer = messageSerializer;
        }
        public async Task SaveAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var paras = new List<MySqlParameter>
            {
                new MySqlParameter("@Version", @event.Version),
                new MySqlParameter("@Id", @event.Id),
                new MySqlParameter("@Seq", @event.Seq),
                new MySqlParameter("@Timestamp", @event.OccurredOn),
            };

            using (var myConn = new MySqlConnection(_connectionString))
            {
                await myConn.OpenAsync();
                string strSql = null;
                using (var cmd = new MySqlCommand(strSql, myConn))
                {
                    cmd.Parameters.AddRange(paras.ToArray());
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
