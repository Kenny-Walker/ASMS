namespace Automated_Smart_Metering_System.Models.DTOs.ResponseModels
{
    public class RoleResponse : BaseResponse
    {
        public List<GetRoleDto> Data { get; set; } = new List<GetRoleDto>();
    }
}
