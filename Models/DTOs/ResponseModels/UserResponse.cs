
namespace Automated_Smart_Metering_System.Models.DTOs.ResponseModels
{
    
    public class UserResponse : BaseResponse
    {
        public GetUserDto Data { get; set; } = new GetUserDto();
    }
}
