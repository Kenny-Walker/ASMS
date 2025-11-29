using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface IEmailService
    {
        Task<BaseResponse> SendEmail(CreateEmailDto createEmail);
        Task<EmailResponse> GetAllEmails();
        Task<EmailResponse> GetEmailByReferenceNo(string referenceNo);
        Task<BaseResponse> GetEmail(int Id);
    }
}
