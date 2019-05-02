using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Senders
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
