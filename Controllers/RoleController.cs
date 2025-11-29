using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController: Controller
    {
        IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromForm] CreateRoleDto createRole)
        {
            var role = await _roleService.AddRoleAsync(createRole);
            if (role.Success == true)
            {
                return Ok(role);
            }
            return Ok(role);
        }

        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(int Id)
        {
            var role = await _roleService.DeleteRole(Id);
            if(role.Success == true)
            {
                return Ok(role);
            }
            return Ok(role);
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var role = await _roleService.GetAllRoleAsync();
            if (role.Success == true)
            {
                return Ok(role);
            }
            return Ok(role);
        }

    }
}
