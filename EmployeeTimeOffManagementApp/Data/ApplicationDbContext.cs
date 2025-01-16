using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimeOffManagementApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    // This class represents the DB. List all entities here.
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    // Name of table is pluralized
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public ApplicationDbContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("DataSource=app.db");
        }
    }
}