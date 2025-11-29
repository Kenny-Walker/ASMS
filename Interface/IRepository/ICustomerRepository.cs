using Automated_Smart_Metering_System.Entities;

namespace Automated_Smart_Metering_System.Interface.IRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomer(int id);
        Task<Customer> GetCustomerByUserId(int UserId);
        Task<IList<Customer>> GetCustomerByName(string name);
        Task<IList<Customer>> GetAllCustomers();


    }
}
