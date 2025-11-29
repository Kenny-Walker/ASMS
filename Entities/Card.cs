using Automated_Smart_Metering_System.Contracts;

namespace Automated_Smart_Metering_System.Entities
{
    public class Card : AuditableEntity
    {
        public int UserId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime Month { get; set; }
        public DateTime Year { get; set; }
        public string CVV { get; set; }
    }
}
