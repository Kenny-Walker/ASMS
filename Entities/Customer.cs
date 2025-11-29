using Automated_Smart_Metering_System.Contracts;
using Automated_Smart_Metering_System.Entities.Identity;

namespace Automated_Smart_Metering_System.Entities
{
    public class Customer : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
