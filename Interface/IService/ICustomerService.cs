using Automated_Smart_Metering_System.Models.DTOs;
using Automated_Smart_Metering_System.Models.DTOs.ResponseModels;

namespace Automated_Smart_Metering_System.Interface.IService
{
    public interface ICustomerService
    {
        Task<BaseResponse> CreateCustomer(CreateCustomerDto createCustomer);
        Task<BaseResponse> UpdateCustomer(UpdateCustomerDto updateCustomer);
        Task<BaseResponse> DeleteCustomer(int userId);
        Task<BaseResponse> GetCustomer(int userId);
        Task<CustomerResponse> GetAllCustomers();
        Task<CustomerResponse> GetCustomersByName(string Name);
    }
}
