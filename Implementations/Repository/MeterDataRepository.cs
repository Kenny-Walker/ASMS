using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class MeterDataRepository : GenericRepository<MeterData>, IMeterDataRepository
    {
        public MeterDataRepository(AutomatedSmartMeteringSystemContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<MeterData>> GetAllMeterData()
        {
            return await _Context.MeterDatas.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<MeterData> GetMeterData(int Id)
        {
            return await _Context.MeterDatas.FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
        }

        public async Task<IList<MeterData>> GetMeterDataByMeterId(int meterId)
        {
            return await _Context.MeterDatas.Where(x => x.MeterId == meterId && x.IsDeleted == false).ToListAsync();
        }
    }
}
