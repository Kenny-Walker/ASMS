using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(AutomatedSmartMeteringSystemContext Context)
        {
            _Context = Context;
        }
        public async Task<IList<Device>> GetAllDevices()
        {
            return await _Context.Devices.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<IList<Device>> GetAllDevicesByMeterId(int MeterId)
        {
            return await _Context.Devices.Where(x => x.MeterId == MeterId && x.IsDeleted == false).ToListAsync();
        }

        public async Task<Device> GetDeviceById(int Id)
        {
            return await _Context.Devices.FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
        }
    }
}
