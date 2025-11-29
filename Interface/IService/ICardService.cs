using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface ICardService
    {
        Task<BaseResponse> AddCard(AddCardDto addCard);
        Task<BaseResponse> GetCardId(int Id);
        Task<CardResponse> GetCardByUserId(int userId);
        Task<CardResponse> GetAllCard();
        Task<BaseResponse> DeleteCard(int Id);
    }
}
