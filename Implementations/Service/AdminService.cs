using Automated_Smart_Metering_System.Entities.Identity;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;
using BCrypt.Net;
namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class AdminService : IAdminService
    {
        IUserRepository _userRepository;
        IAdminRepository _adminRepository;
        IRoleRepository _roleRepository;
        IUserRoleRepository _userRoleRepository;

        public AdminService(IUserRepository userRepository, IAdminRepository adminRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _adminRepository = adminRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;

        }

        public async Task<BaseResponse> CreateAdmin(CreateAdminDto createAdmin)
        {
            var admin = await _adminRepository.GetAsync(a => a.User.Email == createAdmin.CreateUserDto.Email);
            if (admin != null)
            {
                return new BaseResponse()
                {
                    Message = "Admin Already Exists",
                    Success = false,
                };
            }


            var user = new User
            {
                Name = createAdmin.CreateUserDto.Name,
                Email = createAdmin.CreateUserDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(createAdmin.CreateUserDto.Password),
                Address = new Address() {
                    AddressInformation = "",
                },
                

            };
            var adduser = await _userRepository.CreateAsync(user);
            var role = (await _roleRepository.GetAllAsync(x => x.Name.Equals("Admin"))).FirstOrDefault();
            if (role == null)
            {
                return new BaseResponse
                {
                    Message = "Role not found",
                    Success = false
                };
            }

            var userRole = new UserRole()
            {
                UserId = adduser.Id,
                RoleId = role.Id,
            };
            adduser.UserRoles.Add(userRole);
            await _userRepository.UpdateAsync(adduser);
            

            var admins = new Admin()
            {
                UserId = adduser.Id,
                RoleId = role.Id,
            };
            await _adminRepository.CreateAsync(admins);
            return new BaseResponse
            {
                Message = "Admin Added Successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteAdmin(int Id)
        {
            var admin = await _adminRepository.GetAsync(admin => admin.IsDeleted == false && admin.Id == Id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin Not Found",
                    Success = false,
                };
            }
            admin.IsDeleted = true;
            await _adminRepository.UpdateAsync(admin);
            return new BaseResponse
            {
                Message = "Admin Deleted Successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> GetAdmin(int Id)
        {
            var admins = await _adminRepository.GetAdmin(Id);
            return new SingleAdminResponse
            {
                Data = new GetAdminDto()
                {
                    Id = admins.Id,
                    GetUserDto = new GetUserDto()
                    {
                        Id = admins.User.Id,
                        Name = admins.User.Name,
                        Email = admins.User.Email,
                        Picture = admins.User.Picture,
                    }
                }
            };
        }

        public async Task<AdminResponse> GetAdminByName(string name)
        {
            var admins = await _adminRepository.GetAdminsByName(name);
            if(admins == null)
            {
                return new AdminResponse
                {
                    Data = null,
                    Success = false,
                    Message = ""
                };
            }
            return new AdminResponse
            {
                Data = admins.Select(x => new GetAdminDto
                {
                    Id = x.Id,
                    GetUserDto = new GetUserDto()
                    {
                        Id = x.User.Id,
                        Name = x.User.Name,
                        Email = x.User.Email,
                        Picture = x.User.Picture,                    
                            AddressData = x.User.Address.AddressInformation,

                        
                    }
                }).ToList()
            };
        }

        public async Task<AdminResponse> GetAllAdmins()
        {
            var admins = await _adminRepository.GetAllAdmins();
            if (admins == null)
            {
                return new AdminResponse
                {
                    Data = null,
                    Success = false,
                    Message = ""
                };
            }
            return new AdminResponse
            {
                Data = admins.Select(x => new GetAdminDto
                {
                    Id = x.Id,
                    GetUserDto = new GetUserDto()
                    {
                        Id = x.User.Id,
                        Name = x.User.Name,
                        Email = x.User.Email,
                        Picture = x.User.Picture,
                        AddressData = x.User.Address.AddressInformation
                    }
                }).ToList(),
                Message = "Admins Retrieved",
                Success = true,
            };
        }

        public async Task<BaseResponse> UpdateAdmin(UpdateAdminDto updateAdmin)
        {
            var admin = await _adminRepository.GetAdmin(updateAdmin.Id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin Not Found",
                    Success = false,
                };
            }
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Admin\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (updateAdmin.UpdateUserDto.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updateAdmin.UpdateUserDto.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(updateAdmin.UpdateUserDto.Picture.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var ms = new MemoryStream())
                    {
                        await updateAdmin.UpdateUserDto.Picture.CopyToAsync(ms);
                        byte[] imageBytes = ms.ToArray();
                        string base64String = Convert.ToBase64String(imageBytes);
                        imagePath = base64String;
                    }
                }
            }
         
            admin.User.Name = updateAdmin.UpdateUserDto.Name;
            admin.User.Email = updateAdmin.UpdateUserDto.Email;
            admin.User.Password = BCrypt.Net.BCrypt.HashPassword(updateAdmin.UpdateUserDto.Password);
            admin.User.Picture = imagePath;


            await _adminRepository.UpdateAsync(admin);
            return new BaseResponse
            {
                Message = "Admin updated successfully",
                Success = true,
            };
        }
        public async Task<GetAdminDto> GetAdminDetails(Admin x)
        {
            var role = await _roleRepository.GetAsync(c => c.Id == x.RoleId);
            return new GetAdminDto()
            {
                Id = x.Id,
                GetUserDto = new GetUserDto()
                {
                    Name = x.User.Name,
                    Email = x.User.Email,
                    Picture = x.User.Picture,
                    AddressData = x.User.Address.AddressInformation,
                    Role = new GetRoleDto()
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description,
                    }

                }
            };
        }
    }
    
}
