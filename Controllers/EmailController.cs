using Automated_Smart_Metering_System.Implementations.Service;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromForm] CreateEmailDto createEmail)
        {
            var email = await _emailService.SendEmail(createEmail);
            if (email.Success == true)
            {
                return Ok(email);
            }
            return Ok(email);
        }

        [HttpGet("GetAllEmails")]
        public async Task<IActionResult> GetAllEmails()
        {
            var email = await _emailService.GetAllEmails();
            if (email.Success == true)
            {
                return Ok(email);
            }
            return Ok(email);
        }

        [HttpGet("GetEmailByReferenceNumber")]
        public async Task<IActionResult> GetEmailByReferenceNumber(string referenceNumber) 
        {
            var email = await _emailService.GetEmailByReferenceNo(referenceNumber);
            if (email.Success == true)
            {
                return Ok(email);
            }
            return Ok(email);
        }

        [HttpGet("GetEmail")]
        public async Task<IActionResult> GetEmail(int Id)
        {
            var email = await _emailService.GetEmail(Id);
            if (email.Success == true)
            {
                return Ok(email);
            }
            return Ok(email);
        }
    }
}
