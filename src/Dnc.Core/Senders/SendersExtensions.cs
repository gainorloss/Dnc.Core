using Dnc.Senders;
using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dnc
{
    public static class SendersExtensions
    {
        /// <summary>
        /// Gets it from a <see cref="IMailSender"/>
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction UseMailSender(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<SmtpClient>();
            construction.Services.AddSingleton<IMailSender,MailKitMailSender>();
            return construction;
        } 
    }
}
