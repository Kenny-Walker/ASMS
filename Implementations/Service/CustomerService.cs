using Automated_Smart_Metering_System.Entities.Identity;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Automated_Smart_Metering_System.Interface.IService;
using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;
using BCrypt.Net;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Automated_Smart_Metering_System.Implementations.Service
{
    public class CustomerService : ICustomerService
    {
        private IUserRepository _userRepository;
        private ICustomerRepository _customerRepository;
        private IRoleRepository _roleRepository;

        public CustomerService(IUserRepository userRepository, ICustomerRepository customerRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> CreateCustomer(CreateCustomerDto createCustomer)
        {
            var customer = await _customerRepository.GetAsync(a => a.User.Email == createCustomer.CreateUserDto.Email);
            if (customer != null)
            {
                return new BaseResponse()
                {
                    Message = "Customer Already Exists",
                    Success = false,
                };
            }

           
            var user = new User
            {
                Name = createCustomer.CreateUserDto.Name,
                Email = createCustomer.CreateUserDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(createCustomer.CreateUserDto.Password),
                Address = new Address()
                {
                    AddressInformation = "",
                },
            };
            var adduser = await _userRepository.CreateAsync(user);
            var role = await _roleRepository.GetAsync(x => x.Name.Equals("Customer"));
            if (role == null)
            {
                return new BaseResponse
                {
                    Message = "Role not found",
                    Success = false
                };
            }

            var userRole = new UserRole
            {
                UserId = adduser.Id,
                RoleId = role.Id,
            };
            adduser.UserRoles.Add(userRole);
            await _userRepository.UpdateAsync(adduser);

            var customers = new Customer()
            {
                UserId = adduser.Id,
                RoleId = role.Id,
            };
            await _customerRepository.CreateAsync(customers);
            return new BaseResponse
            {
                Message = "Customer Added Successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> DeleteCustomer(int Id)
        {
            var customer = await _customerRepository.GetAsync(customer=> customer.IsDeleted == false && customer.Id == Id);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Message = "Customer Not Found",
                    Success = false,
                };
            }
            customer.IsDeleted = true;
            await _customerRepository.UpdateAsync(customer);
            return new BaseResponse
            {
                Message = "Customer Deleted Successfully",
                Success = true,
            };
        }

        public async Task<CustomerResponse> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();
            if (customers != null)
            {
                var customerList = new List<GetCustomerDto>();
                foreach (var x in customers) customerList.Add(GetCustomerDetails(x));
                return new CustomerResponse
                {
                    Data = customerList,
                    Success = true,
                    Message = "Customers Retrieved"
                };
            }
            return new CustomerResponse
            {
                Data = null,
                Success = false,
                Message = "Customers not found"
            };
        }

        public async Task<BaseResponse> GetCustomer(int Id)
        {
            var customer = await _customerRepository.GetCustomer(Id);
            if (customer == null)
            {
                return new SingleCustomerResponse()
                {
                    Data = null,
                    Message = "Customer doesn't exist",
                    Success = false,
                };
            }
            return new SingleCustomerResponse
            {
                Data = GetCustomerDetails(customer),
                Success = true,
                Message = "Meter Retrieved"
            };
        }

        public async Task<CustomerResponse> GetCustomersByName(string Name)
        {
            var customers = await _customerRepository.GetCustomerByName(Name);
           if (customers != null)
            {
                var customerList = new List<GetCustomerDto>();
                foreach (var x in customers) customerList.Add(GetCustomerDetails(x));
                return new CustomerResponse
                {
                    Data = customerList,
                    Success = true,
                    Message = "Customers Retrieved"
                };
            }
            return new CustomerResponse
            {
                Data = null,
                Success = false,
                Message = "Customers not found"
            };
        }

        public async Task<BaseResponse> UpdateCustomer(UpdateCustomerDto updateCustomer)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == updateCustomer.Id);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Message = "Admin Not Found",
                    Success = false,
                };
            }
            var path = Path.Combine(Directory.GetCurrentDirectory() + "..\\Images\\Customer\\");
            if (!System.IO.Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var imagePath = "";
            if (updateCustomer.UpdateUserDto.Picture != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updateCustomer.UpdateUserDto.Picture.FileName);
                var filePath = Path.Combine(path, fileName);
                var extension = Path.GetExtension(updateCustomer.UpdateUserDto.Picture.FileName);
                if (!System.IO.Directory.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updateCustomer.UpdateUserDto.Picture.CopyToAsync(stream);
                    }
                    imagePath = fileName;
                }
            }
           
            customer.User.Name = updateCustomer.UpdateUserDto.Name;
            customer.User.Email = updateCustomer.UpdateUserDto.Email;
            customer.User.Password = BCrypt.Net.BCrypt.HashPassword(updateCustomer.UpdateUserDto.Password);
            customer.User.Picture = imagePath;
            customer.User.Address.AddressInformation = updateCustomer.UpdateUserDto.AddressData;


            await _customerRepository.UpdateAsync(customer);
            return new BaseResponse
            {
                Message = "Customer updated successfully",
                Success = true,
            };
        }
        public  GetCustomerDto GetCustomerDetails(Customer x)
        {  return new GetCustomerDto()
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
            };
        }
    }
}
