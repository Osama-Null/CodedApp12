using CodedApp12.Models;
using Microsoft.EntityFrameworkCore;
namespace CodedApp12.Data
{//                      Other  :IdentityDbContext >> Security service: .Identity
    public class CodedDbContext : DbContext
    {
        // Inject Constructor
        public CodedDbContext(DbContextOptions<CodedDbContext> options) : base(options) { }

        // Entity
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
