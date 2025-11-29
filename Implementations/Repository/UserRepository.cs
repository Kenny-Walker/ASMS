using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Entities.Identity;
using Automated_Smart_Metering_System.Interface.IRepository;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AutomatedSmartMeteringSystemContext Context)
        {
            _Context = Context;
        }
    }
}
