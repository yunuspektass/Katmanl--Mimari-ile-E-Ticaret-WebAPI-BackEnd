namespace Project.BLL.DesignPatterns.GenericRepository.BaseRep;

public interface IMailService
{
    Task SendEmailAsync(string email, string subject, string message);
}