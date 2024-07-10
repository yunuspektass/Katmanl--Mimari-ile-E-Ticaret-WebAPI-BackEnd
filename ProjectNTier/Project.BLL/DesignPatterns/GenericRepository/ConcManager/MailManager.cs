using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.BLL.ServiceSettings;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcManager;

public class MailManager : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailManager(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        
        var client = new SmtpClient(_mailSettings.Host , _mailSettings.Port)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(_mailSettings.UserName, _mailSettings.Password)
        };
        var mailMessage = new MailMessage
        {

            From = new MailAddress(_mailSettings.SenderEmail),
            Subject = subject,
            Body = message,
            IsBodyHtml = false
        }; 
        
             mailMessage.To.Add(new MailAddress(email));
        
           return client.SendMailAsync(mailMessage);
       
    }

    
        
        /*return client.SendMailAsync(
            new MailMessage(from : _mailSettings.SenderEmail ,
                           to : email,
                           subject,
                   message));*/
    }


