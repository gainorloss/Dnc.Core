using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dnc
{
    /// <summary>
    /// Email helpr.
    /// </summary>
    public class EmailHelper
    {

        public static async Task SendMailAsync(string smtpserver, 
            bool enableSsl,
            string userName,
            string pwd,
            string nickName,
            string fromMail,
            string toMail, 
            string subj,
            string bodys)
        {
            try
            {

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
                smtpClient.Host = smtpserver;//指定SMTP服务器
                smtpClient.Credentials = new NetworkCredential(userName, pwd);//用户名和密码
                smtpClient.EnableSsl = enableSsl;
                MailAddress fromAddress = new MailAddress(fromMail, nickName);
                MailAddress toAddress = new MailAddress(toMail);
                MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
                mailMessage.Subject = subj;//主题
                mailMessage.Body = bodys;//内容
                mailMessage.BodyEncoding = Encoding.Default;//正文编码
                mailMessage.IsBodyHtml = true;//设置为HTML格式
                mailMessage.Priority = MailPriority.Normal;//优先级
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
