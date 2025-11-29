namespace Automated_Smart_Metering_System.Models.DTOs
{
    public class AddMeterDataDto
    {
        public int MeterId { get; set; }
        public double CurrentPowerConsumed { get; set; }
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double Power { get; set; }
        public double TodayUsage { get; set; }
        public double AverageUsage { get; set; }
        public double OffPeakLoad { get; set; }
        public double PeakLoad { get; set; }
        public double BaseLoad { get; set; }
        public double PercentageChange { get; set; }
    }
    public class UpdateMeterDataDto
    {
        public int MeterId { get; set; }
        public double Power { get; set; }
        public double CurrentPowerConsumed { get; set; }
        public double TodayUsage { get; set; }
        public double AverageUsage { get; set; }
        public double PercentageChange { get; set; }
    }
    public class GetMeterDataDto
    {
        public int Id { get; set; }
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
