namespace Automated_Smart_Metering_System.Models.DTOs
{
    public class AddCardDto
    {
        public int UserId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime Month { get; set; }
        public DateTime Year { get; set; }
        public string CVV { get; set; }
    }
    public class GetCardDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime Month { get; set; }
        public DateTime Year { get; set; }
        public string CVV { get; set; }
    }
}
