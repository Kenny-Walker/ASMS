using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        // GET: api/<AdminController>
        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin([FromForm] CreateAdminDto createAdminDto)
        {
            var admin = await _adminService.CreateAdmin(createAdminDto);
            if (admin.Success == true)
            {
                return Ok(admin);
            }
            return Ok(admin);
        }
        // PUT : UpdateAdmin
        [HttpPut("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin([FromForm] UpdateAdminDto updateAdminDto)
        {
            var admin = await _adminService.UpdateAdmin(updateAdminDto);
            if (admin.Success == true)
            {
                return Ok(admin);
            }
            return Ok(admin);
        }

        // GET : GetAdminById
        [HttpGet("GetAdminById")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _adminService.GetAdmin(id);
            if (admin.Success == true)
            {
                return Ok(admin);
            }
            return Ok(admin);
        }

        // GET : DisplayAdmins
        [HttpGet("DisplayAllAdmins")]
        public async Task<IActionResult> DisplayAdmins()
        {
            var admins = await _adminService.GetAllAdmins();
            if (admins.Success == true)
            {
                return Ok(admins);
            }
            return Ok(admins);
        }

        // GET : DeleteAdmin
        [HttpDelete("DeleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _adminService.DeleteAdmin(id);
            if (admin.Success == true)
            {
                return Ok(admin);
            }
            return Ok(admin);
        }

        // GET : GetAdmin
        [HttpGet("GetAdminByName")]
        public async Task<IActionResult> GetAdmin(string name)
        {
            var admin = await _adminService.GetAdminByName(name);
            if (admin.Success == true)
            {
                return Ok(admin);
            }
            return Ok(admin);
        }
    }
}
