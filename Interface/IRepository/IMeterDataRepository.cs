using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Interface.IRepository
{
    public interface IMeterDataRepository : IGenericRepository<MeterData>
    {
        Task<MeterData> GetMeterData(int Id);
        Task<IList<MeterData>> GetAllMeterData();
        Task<IList<MeterData>> GetMeterDataByMeterId(int meterId);
    }
}
