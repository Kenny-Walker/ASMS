namespace Automated_Smart_Metering_System.Models.DTOs
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
    public class UpdateUserRoleDto
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}
