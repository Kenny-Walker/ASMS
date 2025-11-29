using Automated_Smart_Metering_System.Implementations.Service;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Smart_Metering_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : Controller
    {
        ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("AddCard")]
        public async Task<IActionResult> AddCard([FromForm] AddCardDto addCardDto)
        {
            var card = await _cardService.AddCard(addCardDto);
            if (card.Success == true)
            {
                return Ok(card);
            }
            return Ok(card);
        }

        // GET : DisplayAdmins
        [HttpGet("DisplayAllcards")]
        public async Task<IActionResult> DisplayAllcards()
        {
            var card = await _cardService.GetAllCard();
            if (card.Success == true)
            {
                return Ok(card);
            }
            return Ok(card);
        }

        [HttpGet("DisplayAllcardsByUserId")]
        public async Task<IActionResult> DisplayAllcardsByUserId(int userId)
        {
            var card = await _cardService.GetCardByUserId(userId);
            if (card.Success == true)
            {
                return Ok(card);
            }
            return Ok(card);
        }
        // GET : Deletecard
        [HttpDelete("Deletecard")]
        public async Task<IActionResult> Deletecard(int cardId)
        {
            var card = await _cardService.DeleteCard(cardId);
            if (card.Success == true)
            {
                return Ok(card);
            }
            return Ok(card);
        }
        //GET : GetcardById
        [HttpGet("GetcardById")]
        public async Task<IActionResult> GetCardById(int cardId)
        {
            var card = await _cardService.GetCardId(cardId);
            if (card.Success == true)
            {
                return Ok(card);
            }
            return Ok(card);
        }
    }
}
