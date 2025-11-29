using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Entities.Enums;
using Automated_Smart_Metering_System.Entities.Identity;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Models.DTOs
{
    public class CreateUserDto
    {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
    }
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile? Picture { get; set; }
        public string AddressData { get; set; }
        public List<UserRoleDto> Roles { get; set; }
    }
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Picture { get; set; }
        public string AddressData { get; set; }
        public GetRoleDto Role { get; set; }
    }
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Delete
    {
        public int Id { get; set; }
    }
    public class UserLoginResponse : BaseResponse
    {
        public GetUserDto Data { get; set; }
    }
}



