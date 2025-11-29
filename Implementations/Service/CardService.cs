using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Implementations.Repository;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;
using System.Numerics;

namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class CardService : ICardService
    {
        private IUserRepository _userRepository;
        private ICardRepository _cardRepository;


        public CardService(IUserRepository userRepository,ICardRepository cardRepository)
        {
            _userRepository = userRepository;
            _cardRepository = cardRepository;
        }

        public async Task<BaseResponse> AddCard(AddCardDto addCard)
        {
            var card = await _userRepository.GetAsync(x => x.Id == addCard.UserId);
            if (card != null)
            {
                return new BaseResponse()
                {
                    Message = "User Doesn't Exists",
                    Success = false,
                };
            }
            var cards = new Card
            {
                UserId = addCard.UserId,
                CardHolderName = addCard.CardHolderName,
                CardNumber= addCard.CardNumber,
                CVV = addCard.CVV,
                Month= addCard.Month,
                Year = addCard.Year,

            };
            await _cardRepository.CreateAsync(cards);
            return new BaseResponse()
            {
                Message = "Card Created Successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteCard(int Id)
        {
            var card = await _cardRepository.GetCardById(Id);
            if (card == null)
            {
                return new BaseResponse()
                {
                    Message = "Card does not exist",
                    Success = false
                };
            }
            card.IsDeleted = true;
            await _cardRepository.UpdateAsync(card);
            return new BaseResponse()
            {
                Message = "Card deleted",
                Success = true,
            };
        }

        public async Task<CardResponse> GetAllCard()
        {
            var card = await _cardRepository.GetAllCards();
            var cardList = new List<GetCardDto>();
            foreach (var x in card) cardList.Add(await GetCardDetails(x));
            return new CardResponse()
            {
                Data = cardList,
                Message = "Cards Retrieved",
                Success = true,
            };
        }

        public async Task<CardResponse> GetCardByUserId(int userId)
        {
            var card = await _cardRepository.GetCardsByUserId(userId);
            if(card == null)
            {
                return new CardResponse()
                {
                    Data = null,
                    Message = "Cards do not exist",
                    Success = false
                };
            }
            var cardList = new List<GetCardDto>();
            foreach (var x in card) cardList.Add(await GetCardDetails(x));
            return new CardResponse
            {
                Data = cardList,
                Success = true,
                Message = "Card Retrieved"
            };
        }

        public async Task<BaseResponse> GetCardId(int Id)
        {
            var card = await _cardRepository.GetCardById(Id);
            if(card == null)
            {
                return new SingleCardResponse()
                {
                    Data = null,
                    Message = "Card doesn't exist",
                    Success = false
                };
            }
            return new SingleCardResponse()
            {
                Data = await GetCardDetails(card),
                Message = "Card Found",
                Success = true,
            };
        }
        public async Task<GetCardDto> GetCardDetails(Card x)
        {
            var card = await _cardRepository.GetAsync(c => c.Id == x.Id);
            return new GetCardDto()
            {
                Id = x.Id,
                UserId = x.UserId,
                CardHolderName= x.CardHolderName,
                CardNumber= x.CardNumber,
                CVV = x.CVV,
                Month= x.Month,
                Year= x.Year,
            };
        }
    }
}
