using Automated_Smart_Metering_System.Contracts;

namespace Automated_Smart_Metering_System.Entities
{
    public class MeterData: AuditableEntity
    {
        public int MeterId { get; set; }
        public double CurrentPowerConsumed { get; set; }
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double Power { get; set; }
        public double TodayUsage { get; set; }
        public double AverageUsage { get; set; }
        public double PercentageChange { get; set; } 
        public double OffPeakLoad { get; set; }
        public double PeakLoad { get; set; }
        public double BaseLoad { get; set; }
    }
}
