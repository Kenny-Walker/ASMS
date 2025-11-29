using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface IUserService
    {
        Task<UserLoginResponse> Login(string email, string password);
        Task<BaseResponse> DeleteUser(int Id);
    }
}
