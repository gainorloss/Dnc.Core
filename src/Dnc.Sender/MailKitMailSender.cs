using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Sender
{
    public class MailKitMailSender
        : IMailSender
    {
        #region Private member.
        private SmtpClient _smtpClient;
        private readonly MailSenderOptions _options;
        private readonly ILogger<IMailSender> _logger;
        #endregion

        #region Ctor.
        public MailKitMailSender(MailSenderOptions options, ILogger<IMailSender> logger)
        {
            _options = options;
            _logger = logger;
        }
        #endregion

        #region Methods for sending mail.
        public async Task SendMailAsync(string to, string subject, string desc)
        {
            if (_smtpClient == null)
                _smtpClient = new SmtpClient();

            var name = _options.Name;
            var address = _options.Address;
            var password = _options.Password;

            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(name, address));
            msg.To.Add(new MailboxAddress("", to));
            msg.Subject = subject;

            #region content template.
            var sb = new StringBuilder();
            sb.AppendFormat(@"<table dir='ltr'>");
            sb.AppendFormat(@"      <tbody><tr><td id='i1' style='padding:0; font-family:'Microsoft Yahei', Verdana, Simsun, sans-serif; font-size:17px; color:#707070;'>{0} 帐户</td></tr>",name);
            sb.AppendFormat(@"      <tr><td id='i2' style='padding:0; font-family:'Microsoft Yahei', Verdana, Simsun, sans-serif; font-size:41px; color:#2672ec;'>{0}</td></tr>",subject);
            sb.AppendFormat(@"      <tr><td id='i3' style='padding:0; padding-top:25px; font-family:'Microsoft Yahei', Verdana, Simsun, sans-serif; font-size:14px; color:#2a2a2a;'>");
            sb.AppendFormat(@"                请为 {0} 帐户 <a dir='ltr' id='iAccount' class='link' style='color:#2672ec; text-decoration:none' href='mailto:{2}' rel='noopener' target='_blank'>{2}</a> 使用以下{1}。",name,subject,to);
            sb.AppendFormat(@"             </td></tr>");
            sb.AppendFormat(@"      <tr><td id='i4' style='padding:0; padding-top:25px; font-family:'Microsoft Yahei', Verdana, Simsun, sans-serif; font-size:14px; color:#2a2a2a;'>");
            sb.AppendFormat(@"                {0}：<span style='font-family:'Microsoft Yahei', Verdana, Simsun, sans-serif; font-size:14px; font-weight:bold; color:#2a2a2a;'>{1}</span>",subject,desc);
            sb.AppendFormat(@"            </td></tr>");
            sb.AppendFormat(@"      <tr><td id='i5' style='padding:0; padding-top:25px; font-family:'Microsoft Yahei', Verdana, Simsun, sans-serif; font-size:14px; color:#2a2a2a;'>");
            sb.AppendFormat(@"                如果你无法识别 {0} 帐户 <a dir='ltr' id='iAccount' class='link' style='color:#2672ec; text-decoration:none' href='mailto:{1}' rel='noopener' target='_blank'>{1}</a>，可以<a id='iLink2' class='link' style='color:#2672ec; text-decoration:none' href='mailto:{2}' rel='noopener' target='_blank'>单击此处</a>从该帐户删除你的电子邮件地址。", subject,to,address);
            sb.AppendFormat(@"            </td></tr>");
            sb.AppendFormat(@"      <tr><td id='i6' style='padding:0; padding-top:25px; font-family:'Microsoft Yahei', Verdana, Simsun, sans-serif; font-size:14px; color:#2a2a2a;'>谢谢!</td></tr>");
            sb.AppendFormat(@"      <tr><td id='i7' style='padding:0; font-family:'Microsoft Yahei', Verdana, Simsun, sans-serif; font-size:14px; color:#2a2a2a;'>{0} 帐户团队</td></tr>",name);
            sb.AppendFormat(@"</tbody></table>");
            #endregion

            var multipart = new Multipart("mixed")
            {
                new TextPart(TextFormat.Html)
                {
                    Text = sb.ToString()
                }
            };
            msg.Body = multipart;

            if (!_smtpClient.IsConnected)
                _smtpClient.Connect("smtp.qq.com", 587, false);

            if (!_smtpClient.IsAuthenticated)
                await _smtpClient.AuthenticateAsync(address, password);

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
