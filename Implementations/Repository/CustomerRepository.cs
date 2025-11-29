using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Context;
using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Automated_Smart_Metering_System.Implementations.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AutomatedSmartMeteringSystemContext Context)
        {
            _Context = Context;
        }

        public async Task<IList<Customer>> GetAllCustomers()
        {
            return await _Context.Customers.Include(customers => customers.User).Include(x => x.User.Address).Include(x => x.User.UserRoles).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _Context.Customers.Include(customer => customer.User).Include(x => x.User.Address).Include(x => x.User.UserRoles).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Customer>> GetCustomerByName(string name)
        {
            return await _Context.Customers.Include(customer => customer.User).Include(x => x.User.Address).Include(x => x.User.UserRoles).Where(x => x.User.Name == name).ToListAsync();
        }

        public async Task<Customer> GetCustomerByUserId(int UserId)
        {
            return await _Context.Customers.Include(customer => customer.User).Include(x => x.User.Address).Include(x => x.User.UserRoles).FirstOrDefaultAsync(x => x.UserId == UserId);
        }
    }
}
