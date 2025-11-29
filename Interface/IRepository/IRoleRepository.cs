using Automated_Smart_Metering_System.Entities.Identity;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;
using Automated_Smart_Metering_System.Models.DTOs;

namespace Automated_Smart_Metering_System.Interface.IRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<IList<Role>> GetAllRoleAsync();

    }
}
