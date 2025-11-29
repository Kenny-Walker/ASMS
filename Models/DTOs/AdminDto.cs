using Automated_Smart_Metering_System.Entities.Enums;
using Automated_Smart_Metering_System.Entities.Identity;

namespace Automated_Smart_Metering_System.Models.DTOs
{
    public class CreateAdminDto
    {
        public CreateUserDto CreateUserDto { get; set; }

    }
    public class UpdateAdminDto
    {
        public int Id { get; set; }
        public UpdateUserDto UpdateUserDto { get; set; }
    }
    public class GetAdminDto
    {
        public int Id { get; set; }
        public GetUserDto GetUserDto { get; set; }
    }
}
