using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Models.DTOs
{
    public class CreateTransactionDto
    {
        public int UserId { get; set; }
        public int MeterId { get; set; }
        public int Units { get; set; }

    }
    public class GetTransactionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MeterId { get; set; }
        public int Units { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool PaymentStatus { get; set; }
        public string ReferenceNo { get; set; }
    }

}
