using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Entities.Identity;
using Automated_Smart_Metering_System.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AutomatedSmartMeteringSystemContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Role>> GetAllRoleAsync()
        {
            return await _Context.Roles.Where(x => x.IsDeleted == false).ToListAsync();
        }
 
    }
}
