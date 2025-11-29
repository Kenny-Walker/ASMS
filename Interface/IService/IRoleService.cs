using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;
using Automated_Smart_Metering_System.Models.DTOs;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface IRoleService
    {
        Task<BaseResponse> AddRoleAsync(CreateRoleDto role);
        Task<RoleResponse> GetAllRoleAsync();
        Task<BaseResponse> DeleteRole(int Id);

    }
}
