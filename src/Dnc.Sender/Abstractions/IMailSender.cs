using System;
using System.Threading.Tasks;
using Dnc;

namespace Dnc.Sender
{
    /// <summary>
    /// Constraint for sending email.
    /// </summary>
    public interface IMailSender
        :IDisposable
    {
        Task SendMailAsync(string to,string subject,string desc);
    }
}
