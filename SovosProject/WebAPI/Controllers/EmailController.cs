using Microsoft.AspNetCore.Mvc;
using SovosProject.Application.Email;
using SovosProject.Application.Interfaces;
using SovosProject.Application.Models;

namespace WebAPI.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
       private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService=emailService;
        }

        [HttpPost("sendMail")]
        public async Task<IActionResult> SendEmail(MailLogDto value)
        {

            await _emailService.SendEmailAsync(value);
            return Ok(new { Message = "E-posta başarıyla gönderildi." });

        }
    }
}
