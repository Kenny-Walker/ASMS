using BCrypt.Net;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserLoginResponse> Login(string email, string password)
        {
            var user = await _userRepository.GetAsync(x => x.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return new UserLoginResponse()
                {
                    Data = new GetUserDto()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Name = user.Name,
                        //AddressData = user.Address.AddressInformation,
                        Picture = user.Picture
                    },
                    Success = true,

                };
                
            }
            return new UserLoginResponse()
            {
                Data = null,
                Success = false,
            };
        }

        public async Task<BaseResponse> DeleteUser(int Id)
        {

            var user = await _userRepository.GetAsync(x => x.Id == Id);
            if (user.IsDeleted == false)
            {
                user.IsDeleted = true;
                await _userRepository.UpdateAsync(user);
            }
            return new BaseResponse()
            {

                Message = "User was Successfully Deleted",
                Success = true,

            };
        }
    }
}
