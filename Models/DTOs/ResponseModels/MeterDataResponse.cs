namespace Automated_Smart_Metering_System.Models.DTOs.ResponseModels
{
    public class MeterDataResponse : BaseResponse
    {
        public List<GetMeterDataDto> Data { get; set; } = new List<GetMeterDataDto>();
    }
    public class SingleMeterDataResponse : BaseResponse
    {
        public GetMeterDataDto Data { get; set; } = new GetMeterDataDto();
    }

}
