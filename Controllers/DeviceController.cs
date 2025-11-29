using Automated_Smart_Metering_System.Implementations.Service;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : Controller
    {
        IDeviceService _deviceService;
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost("AddDevice")]
        public async Task<IActionResult> AddDevice([FromForm] AddDeviceDto addDeviceDto)
        {
            var device = await _deviceService.AddDevice(addDeviceDto);
            if (device.Success == true)
            {
                return Ok(device);
            }
            return Ok(device);
        }

        [HttpPost("UpdateDevice")]
        public async Task<IActionResult> UpdateDevice([FromForm] UpdateDeviceDto updateDeviceDto)
        {
            var device = await _deviceService.UpdateDevice(updateDeviceDto);
            if (device.Success == true)
            {
                return Ok(device);
            }
            return Ok(device);
        }
        [HttpGet("GetDeviceByMeterId")]
        public async Task<IActionResult> GetDeviceByMeterId(int meterId)
        {
            var device = await _deviceService.GetDeviceByMeterId(meterId);
            if (device.Success == true)
            {
                return Ok(device);
            }
            return Ok(device);
        }
        [HttpGet("ActivateDevice")]
        public async Task<IActionResult> ActivateDevice(int Id, bool isActive)
        {
            var device = await _deviceService.ActivateDevice(Id, isActive);
            if (device.Success == true)
            {
                return Ok(device);
            }
            return Ok(device);
        }
        [HttpDelete("DeleteDevice")]
        public async Task<IActionResult> DeleteDevice(int Id)
        {
            var device = await _deviceService.DeleteDevice(Id);
            if (device.Success == true)
            {
                return Ok(device);
            }
            return Ok(device);
        }
    }
}
