using Automated_Smart_Metering_System.Contracts;

namespace Automated_Smart_Metering_System.Entities
{
    public class Device: AuditableEntity
    {
        public string DeviceName { get; set; }
        public int MeterId { get; set; }
        public double PowerConsumed { get; set; }
        public string DeviceKey { get; set; }
        public bool IsActive { get; set; }
    }
}
