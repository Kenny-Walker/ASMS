using Automated_Smart_Metering_System.Contracts;

namespace Automated_Smart_Metering_System.Entities
{
    public class Meter : AuditableEntity
    {
        public int? UserId { get; set; }
        public string MeterName { get; set; }
        public string Location { get; set; }
        public string UniqueMeterId { get; set; }
        public bool IsActive { get; set; }
        public double Units { get; set; }
    }
}
