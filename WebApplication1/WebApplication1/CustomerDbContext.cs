using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers => Set<Customer>();
    }
}
