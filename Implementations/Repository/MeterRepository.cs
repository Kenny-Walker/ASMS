using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class MeterRepository : GenericRepository<Meter>, IMeterRepository
    {
        public MeterRepository(AutomatedSmartMeteringSystemContext Context) 
        {
            _Context= Context;
        }

        public async Task<IList<Meter>> GetAllMeters()
        {
            return await _Context.Meters.ToListAsync();
        }

        public async Task<Meter> GetMeter(int Id)
        {
            return await _Context.Meters.FirstOrDefaultAsync(x => x.Id == Id);
        }



        public async Task<IList<Meter>> GetMeterByIsActive(bool isActive)
        {
            return await _Context.Meters.Where(x => x.IsActive == isActive).ToListAsync();
        }

        public async Task<Meter> GetMeterByUniqueId(string UniqueId)
        {
            return await _Context.Meters.FirstOrDefaultAsync(x => x.UniqueMeterId == UniqueId);
        }

        public async Task<IList<Meter>> GetMetersByUserId(int Userid)
        {
            return await _Context.Meters.Where(x => x.UserId == Userid && x.IsDeleted == false).ToListAsync();  
        }
    }
}
