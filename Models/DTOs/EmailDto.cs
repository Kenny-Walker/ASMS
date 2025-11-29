using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;
using Automated_Smart_Metering_System.Entities.Enums;

namespace Automated_Smart_Metering_System.Models.DTOs;
public class CreateEmailDto
{
    public int UserId { get; set; }
    public string EmailAddress { get; set; }
    public string EmailBody { get; set; }
    public string EmailRefNo { get; set; }
    public string EmailSubject { get; set; }
}
public class GetEmailDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string EmailAddress { get; set; }
    public string EmailBody { get; set; }
    public string EmailRefNo { get; set; }
    public string EmailSubject { get; set; }
}
