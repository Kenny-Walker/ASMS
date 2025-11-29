namespace Automated_Smart_Metering_System.Models.DTOs
{
    public class AddDeviceDto
    {
        public string DeviceName { get; set; }
        public int MeterId { get; set; }
        public string DeviceKey { get; set; }
    }
    public class GetDeviceDto
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public int MeterId { get; set; }
        public double PowerConsumed { get; set; }
        public string DeviceKey { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateDeviceDto
    {
        public int Id { get; set; }
        public double PowerConsumed { get; set; }
    }
    public class ActivateDeviceDto
    {
        public bool IsActive { get; set; }
    }

}
