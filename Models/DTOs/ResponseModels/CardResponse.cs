namespace Automated_Smart_Metering_System.Models.DTOs.ResponseModels
{
    public class CardResponse : BaseResponse
    {
        public List<GetCardDto> Data { get; set; } = new List<GetCardDto>();
    }
    public class SingleCardResponse : BaseResponse
    {
        public GetCardDto Data { get; set; } = new GetCardDto();
    }
}
