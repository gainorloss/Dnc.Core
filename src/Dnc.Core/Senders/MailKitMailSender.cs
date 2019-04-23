using Dnc.Senders;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Senders
{
    public class MailKitMailSender
        : IMailSender
    {
        #region Private member.
        private readonly SmtpClient _smtpClient;
        private readonly ILogger<IMailSender> _logger;
        #endregion

        #region Ctor.
        public MailKitMailSender(SmtpClient smtpClient,
            ILogger<IMailSender> logger)
        {
            _smtpClient = smtpClient;
            _logger = logger;
        }
        #endregion

        #region Methods for sending mail.
        public async Task SendMailAsync(string to, string subject, string desc)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("gainorloss", "519564415@qq.com"));
            msg.To.Add(new MailboxAddress("", to));
            msg.Subject = subject;

            var multipart = new Multipart("mixed");
            multipart.Add(new TextPart(TextFormat.Html)
            {
                Text=$"<p>hi,{to}:<p/><p>{subject}</p><p>{desc}</p><p>Good luck.</p>"
            });
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
