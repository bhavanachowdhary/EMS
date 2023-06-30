using EMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmployeeData> Employees { get; set; }
        public DbSet<Designation> Designations{ get; set; }
        public DbSet<WorkHours> WorkHours { get; set; }
        public DbSet<PaymentRule> PaymentRules { get; set; }
    }
}