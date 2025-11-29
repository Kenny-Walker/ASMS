using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface ITransactionService
    {
        Task<BaseResponse> CreateTransaction(CreateTransactionDto createTransaction);
        Task<BaseResponse> GetTransaction(int Id);
        Task<TransactionResponse> GetTransactionByUserId(int userId);
        Task<TransactionResponse> GetAllTransactions();
        Task<BaseResponse> GetTransactionByReferenceNo(string referenceNo);
        Task<TransactionResponse> GetTransactionByDateAdded(DateTime dateAdded);
        Task<TransactionResponse> GetTransactionsWithinTimeFrame(DateTime startDate, DateTime endDate);
    }
}
