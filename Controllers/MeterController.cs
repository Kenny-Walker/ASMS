using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;

namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterController : Controller
    {
        IMeterService _meterService;
        public MeterController(IMeterService meterService)
        {
            _meterService = meterService;
        }
        // GET: api/<MeterController>
        [HttpPost("AddMeter")]
        public async Task<IActionResult> AddMeter([FromForm] CreateMeterDto createMeterDto)
        {
            var meter = await _meterService.CreateMeter(createMeterDto);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }
        [HttpPut("SelectMeter")]
        public async Task<IActionResult> SelectMeter(int UserId, string UniquemeterId, UpdateMeterDto updateMeterDto)
        {
            var meter = await _meterService.SelectMeter(UserId, UniquemeterId, updateMeterDto);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }

        // GET : DisplayAdmins
        [HttpGet("DisplayAllMeters")]
        public async Task<IActionResult> DisplayAllMeters()
        {
            var meter = await _meterService.GetAllMeters();
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }

        [HttpGet("DisplayAllMetersByUserId")]
        public async Task<IActionResult> DisplayAllMetersByUserId(int userId)
        {
            var meter = await _meterService.GetAllMetersByUserId(userId);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }

        // GET : DeleteMeter
        [HttpDelete("DeleteMeter")]
        public async Task<IActionResult> DeleteMeter(int UserId, int meterId)
        {
            var meter = await _meterService.DeleteMeter(UserId, meterId);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }

        // GET : GetMeterByUniqueId
        [HttpGet("GetMeterByUniqueId")]
        public async Task<IActionResult> GetMeterByUniqueId(string UniqueId)
        {
            var meter = await _meterService.GetMeterByUniqueId(UniqueId);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }
        //GET : GetMeterById
        [HttpGet("GetMeterById")]
        public async Task<IActionResult> GetMeterById(int meterId)
        {
            var meter = await _meterService.GetMeter(meterId);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }
        [HttpPost("Activate Meter")]
        public async Task<IActionResult> ActivateMeter(int meterId)
        {
            var meter = await _meterService.ActivateMeter(meterId);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }
        [HttpPost("Deactivate Meter")]
        public async Task<IActionResult> DeactivateMeter(int meterId)
        {
            var meter = await _meterService.DeactivateMeter(meterId);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }
        [HttpGet("GetMeterByIsActive")]
        public async Task<IActionResult> GetMeterByIsActive(bool IsActive)
        {
            var meter = await _meterService.GetActiveMeters(IsActive);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }
        [HttpGet("GetMeterStatus")]
        public async Task<IActionResult> GetMeterStatus(int meterId)
        {
            var meter = await _meterService.GetMeterStatus(meterId);
            if (meter.Success == true)
            {
                return Ok(meter);
            }
            return Ok(meter);
        }
    }
}
