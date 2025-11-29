using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AutomatedSmartMeteringSystemContext Context)
        {
            _Context = Context;
        }

        public async Task<Admin> GetAdmin(int id)
        {
            return await _Context.Admins.Include(admin => admin.User).Include(x => x.User.Address).Include(x => x.User.UserRoles).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Admin>> GetAdminsByName(string name)
        {
            return await _Context.Admins.Include(admin => admin.User).Include(x => x.User.Address).Include(x => x.User.UserRoles).Where(x => x.User.Name == name).ToListAsync();
        }

        public async Task<IList<Admin>> GetAllAdmins()
        {
            return await _Context.Admins.Include(admin => admin.User).Include(x => x.User.Address).Include(x => x.User.UserRoles).Where(x => x.IsDeleted == false).ToListAsync();
        }
    }
}
