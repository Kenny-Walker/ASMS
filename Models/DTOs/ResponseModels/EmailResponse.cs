namespace Automated_Smart_Metering_System.Models.DTOs.ResponseModels
{

        public class SingleEmailResponse : BaseResponse
        {
            public GetEmailDto Data { get; set; }
        }
        public class EmailResponse : BaseResponse
        {
            public List<GetEmailDto> Data { get; set; } = new List<GetEmailDto>();
        }
}
