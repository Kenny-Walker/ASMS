using Automated_Smart_Metering_System.Contracts;

namespace Automated_Smart_Metering_System.Entities.Identity
{
    public class Role : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
