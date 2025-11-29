using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Interface.IRepository
{
    public interface IEmailRepository : IGenericRepository<Email>
    {
        Task<Email> GetEmailById(int id);
        Task<IList<Email>> GetEmailBySubject(string subject);
        Task<IList<Email>> GetAllEmails();
        Task<IList<Email>> GetEmailByReferenceNo(string referenceNo);
    }
}
