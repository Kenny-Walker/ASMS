using System.Security.Claims;
using System.Text;
using Automated_Smart_Metering_System.Models.DTOs;

namespace Automated_Smart_Metering_System.Authentication;

public interface IJWTAuthentication
{
    string GenerateToken(GetUserDto getUserDto);
}
