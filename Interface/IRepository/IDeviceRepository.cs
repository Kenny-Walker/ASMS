using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Interface.IRepository
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        Task<Device> GetDeviceById(int Id);
        Task<IList<Device>> GetAllDevices();
        Task<IList<Device>> GetAllDevicesByMeterId(int MeterId);
    }
}
