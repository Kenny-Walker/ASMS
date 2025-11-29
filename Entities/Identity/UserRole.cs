using Automated_Smart_Metering_System.Contracts;

namespace Automated_Smart_Metering_System.Entities.Identity
{
    public class UserRole : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
