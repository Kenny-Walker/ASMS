using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("Create Transaction")]
        public async Task<IActionResult> CreateTransaction([FromForm] CreateTransactionDto createTransaction)
        {
            var transaction = await _transactionService.CreateTransaction(createTransaction);
            if(transaction.Success == true)
            {
                return Ok(transaction);
            }
            return Ok(transaction);
        }

        [HttpGet("GetTransactionById")]
        public async Task<IActionResult> GetTransactionById(int Id)
        {
            var transaction = await _transactionService.GetTransaction(Id);
            if (transaction.Success == true)
            {
                return Ok(transaction);
            }
            return Ok(transaction);
        }

        [HttpGet("GetTransactionsByUserId")]
        public async Task<IActionResult> GetTransactionsByUserId(int UserId)
        {
            var transaction = await _transactionService.GetTransactionByUserId(UserId);
            if (transaction.Success == true)
            {
                return Ok(transaction);
            }
            return Ok(transaction);
        }

        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transaction = await _transactionService.GetAllTransactions();
            if (transaction.Success == true)
            {
                return Ok(transaction);
            }
            return Ok(transaction);
        }

        [HttpGet("GetTransactionByReferenceNo")]
        public async Task<IActionResult> GetTransactionByReferenceNo(string refNo)
        {
            var transaction = await _transactionService.GetTransactionByReferenceNo(refNo);
            if (transaction.Success == true)
            {
                return Ok(transaction);
            }
            return Ok(transaction);
        }

        [HttpGet("GetTransactionByDateAdded")]
        public async Task<IActionResult> GetTransactionByDateAdded(DateTime dateAdded)
        {
            var transaction = await _transactionService.GetTransactionByDateAdded(dateAdded);
            if (transaction.Success == true)
            {
                return Ok(transaction);
            }
            return Ok(transaction);
        }

        [HttpGet("GetTransactionsWithinTimeFrame")]
        public async Task<IActionResult> GetTransactionsWithinTimeFrame(DateTime startDate, DateTime endDate)
        {
            var transaction = await _transactionService.GetTransactionsWithinTimeFrame(startDate, endDate);
            if (transaction.Success == true)
            {
                return Ok(transaction);
            }
            return Ok(transaction);
        }
    }
}
