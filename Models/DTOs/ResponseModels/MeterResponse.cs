namespace Automated_Smart_Metering_System.Models.DTOs.ResponseModels
{
    public class MeterResponse : BaseResponse
    {
        public List<GetMeterDto> Data { get; set; } = new List<GetMeterDto>();
    }
    public class SingleMeterResponse : BaseResponse
    {
        public GetMeterDto Data { get; set; } = new GetMeterDto();
    }
    public class MeterStatusResponse : BaseResponse
    {
        public GetMeterStatusDto Data { get; set; } = new GetMeterStatusDto(); 
    }
}
