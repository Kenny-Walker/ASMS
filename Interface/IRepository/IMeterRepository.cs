using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Interface.IRepository
{
    public interface IMeterRepository : IGenericRepository<Meter>
    {
        Task<Meter> GetMeter(int Id);
        Task<Meter> GetMeterByUniqueId(string UniqueId);
        Task<IList<Meter>> GetAllMeters();
        Task<IList<Meter>> GetMeterByIsActive(bool isActive);
        Task<IList<Meter>> GetMetersByUserId(int Userid);

    }
}
