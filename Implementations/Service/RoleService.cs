using Automated_Smart_Metering_System.Entities.Identity;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Interface.IService;

namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            
        }
        public async Task<BaseResponse> AddRoleAsync(CreateRoleDto role)
        {
            var newRole = new Role
            {
                Name = role.Name,
                Description = role.Description,
            };
            await _roleRepository.CreateAsync(newRole);
            return new BaseResponse
            {
                Message = "New Role Created",
                Success = true,
            };

        }

        public async Task<BaseResponse> DeleteRole(int Id)
        {
            var role = await _roleRepository.GetAsync(Id);
            if (role == null)
            {
                return new BaseResponse
                {
                    Message = "Role does not exist",
                    Success = false,
                };

            }
            role.IsDeleted = true;
            await _roleRepository.UpdateAsync(role);
            return new BaseResponse
            {
                Message = "Role Deleted",
                Success = true,
            };

        }

        public async Task<RoleResponse> GetAllRoleAsync()
        {
            var role = await _roleRepository.GetAllAsync();
            return new RoleResponse
            {
                Data = role.Select(x => new GetRoleDto
                {
                    Name = x.Name,
                    Description = x.Description
                }).ToList(),

                Success = true,

            };

        }

    }
}
