using Automated_Smart_Metering_System.Contracts;
using Automated_Smart_Metering_System.Entities.Enums;
namespace Automated_Smart_Metering_System.Entities.Identity
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public string Picture { get; set; } = "";
        public Admin Admin { get; set; }
        public Customer Customer { get; set; }
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
