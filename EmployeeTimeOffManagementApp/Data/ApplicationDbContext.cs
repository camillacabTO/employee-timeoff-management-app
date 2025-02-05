using EmployeeTimeOffManagementApp.Data.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimeOffManagementApp.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    // This class represents the DB. List all entities here.
    // Name of table is pluralized
    public DbSet<LeaveType> LeaveTypes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public ApplicationDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Seeding the database with roles - default values
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "29de083d-bfe5-4ad4-af3a-b5e9a055c9df",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "08e78b51-7355-4e8a-a60b-ede12f13989a",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            },
            new IdentityRole
            {
                Id = "fc428a4b-4f52-457e-bbbe-a169fe994663",
                Name = "Manager",
                NormalizedName = "MANAGER"
            }
        );
        var hasher = new PasswordHasher<User>();
        builder.Entity<User>().HasData(new User 
        {
            Id = "408aa945-3d84-4421-8342-7269ec64d949",
            Email = "admin@localhost.com",
            NormalizedEmail = "ADMIN@LOCALHOST.COM",
            NormalizedUserName = "ADMIN@LOCALHOST.COM",
            UserName = "admin@localhost.com",
            PasswordHash = hasher.HashPassword(null, "my@password"),
            EmailConfirmed = true,
            FirstName = "Default",
            LastName = "Admin",
            DateOfBirth = new DateOnly(1990,12,01)
        });

        builder.Entity<IdentityUserRole<string>>().HasData(
            // Many to Many - Bridge table
            new IdentityUserRole<string>
            {
                RoleId = "29de083d-bfe5-4ad4-af3a-b5e9a055c9df",
                UserId = "408aa945-3d84-4421-8342-7269ec64d949"
            });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("DataSource=app.db");
        }
    }
}
