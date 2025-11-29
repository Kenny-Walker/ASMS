using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Entities.Identity;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class TransactionService : ITransactionService
    {
        private IUserRepository _userRepository;
        private IMeterRepository _meterRepository;
        private ITransactionRepository _transactionRepository;
        public TransactionService(IUserRepository userRepository, IMeterRepository meterRepository, ITransactionRepository transactionRepository)
        {
            _userRepository = userRepository;
            _meterRepository = meterRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<BaseResponse> CreateTransaction(CreateTransactionDto createTransaction)
        {
            var user = await _userRepository.GetAsync(x => x.Id == createTransaction.UserId);
            var meter = await _meterRepository.GetAsync(x => x.Id == createTransaction.MeterId);
            if(user == null || meter == null)
            {
                return new BaseResponse()
                {
                    Message = "User or meter does not exist",
                    Success = false
                };

            }
            var transaction = new Transaction
            {
                UserId = createTransaction.UserId,
                MeterId = createTransaction.MeterId,
                Units = createTransaction.Units,
                PaymentStatus = true,
                ReferenceNo = "TX" + Guid.NewGuid().ToString("N").Substring(0, 8),

            };
            await _transactionRepository.CreateAsync(transaction);
            meter.Units += createTransaction.Units;
            await _meterRepository.UpdateAsync(meter);
            return new BaseResponse
            {
                Message = "Transaction Successful",
                Success = true
            };
            

        }

        public async Task<TransactionResponse> GetAllTransactions()
        {
            var transaction = await _transactionRepository.GetAllTransactions();
            if (transaction == null)
            {
                return new TransactionResponse
                {
                    Data = null,
                    Message = "Transactions unavailable",
                    Success = false,
                };
            }
            var transactionList = new List<GetTransactionDto>();
            foreach (var x in transaction) transactionList.Add(await GetTransactionDetails(x));
            return new TransactionResponse
            {
                Data = transactionList,
                Success = true,
                Message = "Meters Retrieved"
            };
        }

        public async Task<BaseResponse> GetTransaction(int Id)
        {
            var transaction = await _transactionRepository.GetTransactionById(Id);
            if (transaction == null)
            {
                return new SingleTransactionResponse()
                {
                    Data = null,
                    Message = "Transaction not found",
                    Success = false,
                };

            }
            return new SingleTransactionResponse
            {
                Data = await GetTransactionDetails(transaction),
                Message = "Transaction Found",
                Success = true
            };
        }

        public async Task<TransactionResponse> GetTransactionByDateAdded(DateTime dateAdded)
        {
            var transaction = await _transactionRepository.GetTransactionsByDateAdded(dateAdded);
            if (transaction == null)
            {
                return new TransactionResponse
                {
                    Data = null,
                    Message = "Transactions do not exist",
                    Success = false,
                };
            }
            var transactionList = new List<GetTransactionDto>();
            foreach (var x in transaction) transactionList.Add(await GetTransactionDetails(x));
            return new TransactionResponse
            {
                Data = transactionList,
                Success = true,
                Message = "Meters Retrieved"
            };

        }

        public async Task<BaseResponse> GetTransactionByReferenceNo(string referenceNo)
        {
            var transaction = await _transactionRepository.GetTransactionByReferenceNo(referenceNo);
            if(transaction == null)
            {
                return new SingleTransactionResponse()
                {
                    Data = null,
                    Message = "Transaction not found",
                    Success = false,
                };

            }
            return new SingleTransactionResponse
            {
                Data = await GetTransactionDetails(transaction),
                Message = "Transaction Found",
                Success = true
            };
        }

        public async Task<TransactionResponse> GetTransactionByUserId(int userId)
        {
            var transaction = await _transactionRepository.GetTransactionsByUserId(userId);
            if (transaction == null)
            {
                return new TransactionResponse
                {
                    Data = null,
                    Message = "Transactions unavailable",
                    Success = false,
                };
            }
            var transactionList = new List<GetTransactionDto>();
            foreach (var x in transaction) transactionList.Add(await GetTransactionDetails(x));
            return new TransactionResponse
            {
                Data = transactionList,
                Success = true,
                Message = "Transactions Retrieved"
            };
        }

        public async Task<TransactionResponse> GetTransactionsWithinTimeFrame(DateTime startDate, DateTime endDate)
        {
            var transaction = await _transactionRepository.GetTransactionsWithinTimeframe(startDate, endDate);
            if (transaction == null)
            {
                return new TransactionResponse
                {
                    Data = null,
                    Message = "Transactions unavailable",
                    Success = false,
                };
            }
            var transactionList = new List<GetTransactionDto>();
            foreach (var x in transaction) transactionList.Add(await GetTransactionDetails(x));
            return new TransactionResponse
            {
                Data = transactionList,
                Success = true,
                Message = "Transactions Retrieved"
            };
        }
        public async Task<GetTransactionDto> GetTransactionDetails(Transaction x)
        {
            var transaction = await _transactionRepository.GetAsync(c => c.Id == x.Id);
            return new GetTransactionDto()
            {
                Id = x.Id,
                UserId = x.UserId,
                Units = x.Units,
                ReferenceNo= x.ReferenceNo,
                PurchaseDate= x.PurchaseDate,
                PaymentStatus= x.PaymentStatus,
                MeterId = x.MeterId,
            };
        }
    }
}
