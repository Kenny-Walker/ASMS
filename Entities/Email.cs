using Automated_Smart_Metering_System.Contracts;

namespace Automated_Smart_Metering_System.Entities
{
    public class Email : AuditableEntity
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailRefNo { get; set; }



    }
}
