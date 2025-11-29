using Automated_Smart_Metering_System.Authentication;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        // private readonly IJWTAuthentication _auth;
        private IWebHostEnvironment _webHostEnvironment;
        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            // _auth = auth;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.Login(email, password);
            if (user.Success == true)
            {
                // var token = _auth.GenerateToken(user.Data);
                var response = new UserLoginResponse()
                {
                    Data = user.Data,
                    // Token = token,
                    Success = true
                };
                return Ok(response);
            }
            return Ok(user);
        }
    }
}
