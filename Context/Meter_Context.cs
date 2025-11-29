using Automated_Smart_Metering_System.Entities;
using Automated_Smart_Metering_System.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Automated_Smart_Metering_System.Context
{
        public class AutomatedSmartMeteringSystemContext : DbContext
        {
            public AutomatedSmartMeteringSystemContext(DbContextOptions<AutomatedSmartMeteringSystemContext> options) : base(options)
            { 
                
            }
            public DbSet<User> Users { get; set; }
            public DbSet<Admin> Admins { get; set; }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Address> Addresses { get; set; }
            public DbSet<Card> Cards { get; set; }
            public DbSet<Meter> Meters { get; set; }
            public DbSet<Transaction> Transactions { get; set; }
            public DbSet<Email> Emails { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<Device> Devices { get; set; }
            public DbSet<MeterData> MeterDatas { get; set; }

    }


}
