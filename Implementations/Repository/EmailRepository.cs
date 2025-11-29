using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        public EmailRepository(AutomatedSmartMeteringSystemContext Context) 
        { 
            _Context= Context;
        }

        public async Task<IList<Email>> GetAllEmails()
        {
            return await _Context.Emails.ToListAsync();
        }

        public async Task<Email> GetEmailById(int id)
        {
            return await _Context.Emails.Include(email => email.UserId).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Email>> GetEmailByReferenceNo(string referenceNo)
        {
            return await _Context.Emails.Include(email => email.UserId).Where(x => x.EmailRefNo == referenceNo).ToListAsync();
        }

        public async Task<IList<Email>> GetEmailBySubject(string subject)
        {
            return await _Context.Emails.Include(email => email.UserId).Where(x => x.EmailSubject == subject).ToListAsync();
        }
    }
}
