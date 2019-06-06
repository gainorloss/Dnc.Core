namespace Dnc.Redis
{
    /// <summary>
    /// Redis configuration options.
    /// </summary>
    public class RedisOptions
    {
        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 6379;
        public string Password { get; set; } = "p@ssw0rd";

        public string InstanceName { get; set; } = "default";
        public int AvalanchePreventionSeconds { get; set; } = 30;
    }
}
