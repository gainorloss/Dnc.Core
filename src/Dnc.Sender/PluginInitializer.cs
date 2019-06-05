using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dnc.Sender
{
    public class PluginInitializer
        : IPluginInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = Fx.Construction.Configuration;

            var options = new MailSenderOptions();
            configuration.GetSection(nameof(MailSenderOptions)).Bind(options);

            services.AddScoped<IMailSender>(sp => new MailKitMailSender(options, sp.GetRequiredService<ILogger<IMailSender>>()));
        }
    }
}
