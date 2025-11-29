namespace Automated_Smart_Metering_System.Models.DTOs.ResponseModels
{
    public class DeviceResponse : BaseResponse
    {
        public List<GetDeviceDto> Data { get; set; } = new List<GetDeviceDto>();
    }
    public class SingleDeviceResponse : BaseResponse
    {
        public GetDeviceDto Data { get; set; } = new GetDeviceDto();
    }
}
