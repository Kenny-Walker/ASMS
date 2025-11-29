using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Interface.IRepository
{
    public interface ICardRepository: IGenericRepository<Card>
    {
        Task<Card> GetCardById(int id);
        Task<IList<Card>> GetAllCards();
        Task<IList<Card>> GetCardsByUserId(int userId);
    }
}
