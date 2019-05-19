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
        :IDisposable,IPlugin
    {
        Task SendMailAsync(string to,string subject,string desc);
    }
}
