using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Models.DTOs
{
    public class CreateMeterDto
    {
        public int? UserId { get; set; }
    }
    public class UpdateMeterDto
    {
        public string MeterName { get; set; }
        public string Location { get; set; }
        public int UserId { get; set; }
        public string UniquemeterId { get; set; }
    }
    public class GetMeterDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string MeterName { get; set; }
        public string Location { get; set; }
        public string UniqueMeterId { get; set; }
        public bool IsActive { get; set; }
        public double Units { get; set; }
        public GetUserDto UserDto { get; set; }
    }
    public class ActivateMeterDto
    {
        public bool IsActive { get; set; }
    }

    public class GetMeterStatusDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }

}
