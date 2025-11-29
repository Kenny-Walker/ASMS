using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Interface.IRepository
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin> GetAdmin(int id);
        Task<IList<Admin>> GetAdminsByName(string name);
        Task<IList<Admin>> GetAllAdmins();
    }
}
