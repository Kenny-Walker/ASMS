using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        public CardRepository(AutomatedSmartMeteringSystemContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Card>> GetAllCards()
        {
            return await _Context.Cards.Where(x=> x.IsDeleted == false).ToListAsync();
        }

        public async Task<Card> GetCardById(int id)
        {
            return await _Context.Cards.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<IList<Card>> GetCardsByUserId(int userId)
        {
            return await _Context.Cards.Where(x => x.UserId == userId && x.IsDeleted == false).ToListAsync();
        }
    }
}
