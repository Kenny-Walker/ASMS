using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface IAdminService
    {
        Task<BaseResponse> GetAdmin(int adminId);
        Task<AdminResponse> GetAllAdmins();
        Task<BaseResponse> CreateAdmin(CreateAdminDto createAdmin);
        Task<BaseResponse> UpdateAdmin(UpdateAdminDto updateAdmin);
        Task<BaseResponse> DeleteAdmin(int Id);
        Task<AdminResponse> GetAdminByName(string name);
    }
}
