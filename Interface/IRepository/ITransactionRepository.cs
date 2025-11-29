using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Interface.IRepository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<Transaction> GetTransactionByReferenceNo(string referenceNo);
        Task<Transaction> GetTransactionById(int id);
        Task<IList<Transaction>> GetTransactionsByDateAdded(DateTime dateAdded);
        Task<IList<Transaction>> GetTransactionsWithinTimeframe(DateTime startDate, DateTime endDate);
        Task<IList<Transaction>> GetTransactionsByUserId(int userId);
        Task<IList<Transaction>> GetAllTransactions();

    }
}
