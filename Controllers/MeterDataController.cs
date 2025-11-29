using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterDataController : Controller
    {
        IMeterDataService _meterDataService;
        public MeterDataController(IMeterDataService meterDataService)
        {
            _meterDataService = meterDataService;
        }

        [HttpPost("CreateMeterData")]
        public async Task<IActionResult> AddMeterData(AddMeterDataDto addMeterData)
        {
            var meterData = await _meterDataService.CreateMeterData(addMeterData);
            if (meterData.Success == true)
            {
                return Ok(meterData);
            }
            return Ok(meterData);
        }
        [HttpPut("UpdateMeterData")]
        public async Task<IActionResult> UpdateMeterData([FromForm] UpdateMeterDataDto updateMeterData)
        {
            var meterData = await _meterDataService.UpdateMeter(updateMeterData);
            if (meterData.Success == true)
            {
                return Ok(meterData);
            }
            return Ok(meterData);
        }
        [HttpGet("GetMeterDataByMeterId")]
        public async Task<IActionResult> GetMeterDataByMeterId(int meterId)
        {
            var meterData = await _meterDataService.GetMeterDataByMeterId(meterId);
            if(meterData.Success == true)
            {
                return Ok(meterData);
            }
            return Ok(meterData);
        }
        [HttpGet("GetAllMeters")]
        public async Task<IActionResult> GetAllMeterData()
        {
            var meterData = await _meterDataService.GetAllMeterData();
            if(meterData.Success == true)
            {
                return Ok(meterData);
            }
            return Ok(meterData);
        }
    }
}
