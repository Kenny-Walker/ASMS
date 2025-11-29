using Automated_Smart_Metering_System.Context;

using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AutomatedSmartMeteringSystemContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Transaction>> GetAllTransactions()
        {
            return await _Context.Transactions.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            return await _Context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Transaction> GetTransactionByReferenceNo(string referenceNo)
        {
            return await _Context.Transactions.FirstOrDefaultAsync(x => x.ReferenceNo == referenceNo && x.IsDeleted == false);
        }

        public async Task<IList<Transaction>> GetTransactionsByDateAdded(DateTime dateAdded)
        {
            return await _Context.Transactions.OrderByDescending(x => x.CreatedOn <= dateAdded).ToListAsync();
        }


        public async Task<IList<Transaction>> GetTransactionsByUserId(int userId)
        {
            return await _Context.Transactions.Where(x => x.UserId == userId).ToListAsync();

        }

        public async Task<IList<Transaction>> GetTransactionsWithinTimeframe(DateTime startDate, DateTime endDate)
        {
            return await _Context.Transactions.OrderByDescending(x => x.CreatedOn >= startDate && x.CreatedOn <= endDate).ToListAsync();
        }
    }
}
