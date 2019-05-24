using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

namespace Dnc.Sender
{
    public class MailKitMailSender
        : IMailSender
    {
        #region Private member.
        private SmtpClient _smtpClient;
        private readonly ILogger<IMailSender> _logger;
        #endregion

        #region Ctor.
        public MailKitMailSender(ILogger<IMailSender> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Methods for sending mail.
        public async Task SendMailAsync(string to, string subject, string desc)
        {
            if (_smtpClient == null)
                _smtpClient = new SmtpClient();

            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("gainorloss", "519564415@qq.com"));
            msg.To.Add(new MailboxAddress("", to));
            msg.Subject = subject;

            var multipart = new Multipart("mixed")
            {
                new TextPart(TextFormat.Html)
                {
                    Text = $"<p>hi,{to}:<p/><p>{subject}</p><p>{desc}</p><p>Good luck.</p>"
                }
            };
            msg.Body = multipart;

            _smtpClient.Connect("smtp.qq.com", 587, false);
            await _smtpClient.AuthenticateAsync("519564415@qq.com", "xollwmwczuxwbhcb");
            await _smtpClient.SendAsync(msg);
            _logger.LogInformation("Mail is sent successfully.");
        }
        #endregion

        #region Dispose.
        public void Dispose()
        {
            _smtpClient.Disconnect(true);
            _smtpClient.Dispose();
        }
        #endregion
    }
}
