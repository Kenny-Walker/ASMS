namespace Automated_Smart_Metering_System.Models.DTOs.ResponseModels
{
    public class CustomerResponse : BaseResponse
    {
        public List<GetCustomerDto> Data { get; set; } = new List<GetCustomerDto>();
    }
    public class SingleCustomerResponse : BaseResponse
    {
        public GetCustomerDto Data { get; set; } = new GetCustomerDto();
    }
}
