using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

namespace colorTextBackend
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ContactFormController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("contact")]
        public async Task<IActionResult> ProcessContactRequest([FromBody] ContactRequest contactRequest)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Contact Form", _configuration["EmailSettings:SenderEmail"]));
            email.To.Add(new MailboxAddress("John Ansley", _configuration["EmailSettings:ReceiverEmail"]));
            email.Subject = $"Portfolio Contact from {contactRequest.Name}";
            email.Body = new TextPart("plain")
            {
                Text = $"Name: {contactRequest.Name}\nEmail: {contactRequest.Email}\nMessage: {contactRequest.Message}"
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_configuration["EmailSettings:SmtpHost"], int.Parse(_configuration["EmailSettings:SmtpPort"]), false);
            await smtp.AuthenticateAsync(_configuration["EmailSettings:SenderEmail"], _configuration["EmailSettings:SenderPassword"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

            return Ok();
        }

    }

    public class ContactRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
