using MinimalAPI_For_HangFire.MailService;
using MinimalAPI_For_HangFire.Models;

namespace MinimalAPI_For_HangFire.Recurring_Jobs
{
    public class Recurring_jobs
    {
        private readonly IEmailService emailService;
        public Recurring_jobs(IEmailService emailService)
        {
            this.emailService = emailService; 
        }

        public async Task Pushmail()
        {
            MailRequest mailreq = new MailRequest();
            mailreq.ToMail = "YourSendmail";
            mailreq.Subject = "Valid Offer Ending Soon";
            mailreq.Body = GetHtml();
            await emailService.SendMail(mailreq);
        }
        private string GetHtml()
        {
            string emailContent = @"
     <div style=""width: 80%; margin: auto; padding: 20px; border: 1px solid #ccc; border-radius: 5px;"">
    <h1 style=""color: #333;"">Hurry! Limited Time Offer Ending Soon!</h1>
    <p style=""color: #666;"">Dear User,</p>
    <p style=""color: #666;"">We hope this email finds you well.</p>
    <p style=""color: #666;"">This is a friendly reminder that our special offer on Minimal API is ending soon.</p>
    <p style=""color: #666;"">Offer Details:</p>
    <ul style=""color: #666;"">
        <li>Discount: 50%</li>
        <li>Validity: 5 Days</li>
    </ul>
    <p style=""color: #666;"">Don't miss out on this opportunity to enroll in Minimal API  at a discounted rate.</p>
    <p style=""color: #666;"">Act fast and secure your spot before the offer expires on 14-04-2024.</p>
    <p style=""color: #666;"">For more information or to enroll, visit C#corner.</p>
    <p style=""color: #666;"">Thank you for choosing C# Corner!</p>
    <p style=""color: #666;"">Best Regards,</p>
    <p style=""color: #666;"">JobinS<br>Content creator<br>C# Corner</p>
    </div>";
            return emailContent;
        }
    }
}
