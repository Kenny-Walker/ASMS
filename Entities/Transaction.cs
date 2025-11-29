using Automated_Smart_Metering_System.Contracts;
using Automated_Smart_Metering_System.Entities.Identity;

namespace Automated_Smart_Metering_System.Entities
{
    public class Transaction : AuditableEntity
    {
        public int UserId { get; set; }
        public int MeterId { get; set; }
        public int Units { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool PaymentStatus { get; set; }
        public string ReferenceNo { get; set; }

    }
}
