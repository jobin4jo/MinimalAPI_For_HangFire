using MinimalAPI_For_HangFire.Models;

namespace MinimalAPI_For_HangFire.MailService
{
    public interface IEmailService
    {
        Task SendMail(MailRequest mailrequest);
    }
}
