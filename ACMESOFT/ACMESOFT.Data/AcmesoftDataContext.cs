using ACMESOFT.Entity;
using Microsoft.EntityFrameworkCore;

namespace ACMESOFT.Data
{
    public class AcmesoftDataContext : DbContext
    {
        public AcmesoftDataContext(DbContextOptions<AcmesoftDataContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> User { get; set; }
    }
}
