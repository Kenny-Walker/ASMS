using Automated_Smart_Metering_System.Entities.Enums;
using Automated_Smart_Metering_System.Entities.Identity;

namespace Automated_Smart_Metering_System.Models.DTOs
{
    public class CreateCustomerDto
    {  
        public CreateUserDto CreateUserDto { get; set; }
    }
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public UpdateUserDto UpdateUserDto { get; set; }
    }
    public class GetCustomerDto
    {
        public int Id { get; set; }
        public GetUserDto GetUserDto { get; set; }
    }
}
