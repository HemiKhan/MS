using MS_Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.Mail
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailTemplate model);
        Task SendEmailAsync1(string toEmail, string subject, string Content);
    }
}
