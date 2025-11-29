using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Implementations.Repository;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class EmailService : IEmailService
    {
        private IUserRepository _userRepository;
        private IEmailRepository _emailRepository;

        public EmailService(IUserRepository userRepository, IEmailRepository emailRepository)
        {
            _userRepository = userRepository;
            _emailRepository = emailRepository;
        }

        public async Task<EmailResponse> GetAllEmails()
        {
            var email = await _emailRepository.GetAllEmails();
            if(email == null)
            {
                return new EmailResponse()
                {
                    Data = null,
                    Message = "Email doesn't exist",
                    Success = false,
                };
            }
            var emailList = new List<GetEmailDto>();
            foreach (var x in email) emailList.Add(await GetEmailDetails(x));
            return new EmailResponse
            {
                Data = emailList,
                Success = true,
                Message = "Email Retrieved"
            };
        }

        public async Task<BaseResponse> GetEmail(int Id)
        {
            var email = await _emailRepository.GetEmailById(Id);
            if(email == null)
            {
                return new SingleEmailResponse()
                {
                    Data = null,
                    Message = "Email not found",
                    Success = false,
                };
            }
            return new SingleEmailResponse
            { 
                Data = await GetEmailDetails(email),
                Message = "Email Retrieved",
                Success = true,
            };



        }

        public async Task<EmailResponse> GetEmailByReferenceNo(string referenceNo)
        {
            var email = await _emailRepository.GetEmailByReferenceNo(referenceNo);
            if(email == null)
            {
                return new EmailResponse()
                { 
                    Data = null,
                    Message = "Email doesn't exist",
                    Success = false,
                };
            }
            var emailList = new List<GetEmailDto>();
            foreach (var x in email) emailList.Add(await GetEmailDetails(x));
            return new EmailResponse
            {
                Data = emailList,
                Success = true,
                Message = "Email Retrieved"
            };
        }

        public async Task<BaseResponse> SendEmail(CreateEmailDto createEmail)
        {
            var email = await _userRepository.GetAsync(x =>x.Id == createEmail.UserId);
            if(email == null)
            {
                return new BaseResponse()
                {
                    Message = "User not found",
                    Success = false,
                };
            }
            var emails = new Email
            {
                EmailAddress = createEmail.EmailAddress,
                EmailSubject = createEmail.EmailSubject,
                EmailBody = createEmail.EmailBody,
                EmailRefNo = "Email" + Guid.NewGuid().ToString("N").Substring(0, 8),
            };
            await _emailRepository.CreateAsync(emails);
            return new BaseResponse()
            {
                Message = "Email Sent Successfully",
                Success = true
            };
        }
        public async Task<GetEmailDto> GetEmailDetails(Email x)
        {
            var email = await _emailRepository.GetAsync(c => c.Id == x.Id);
            return new GetEmailDto()
            {
                Id = x.Id,
                UserId = x.UserId,
                EmailAddress = x.EmailAddress,
                EmailBody = x.EmailBody,
                EmailSubject= x.EmailSubject,
                EmailRefNo = x.EmailRefNo,
            };
        }
    }
}
