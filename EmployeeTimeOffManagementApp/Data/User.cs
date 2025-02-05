using Microsoft.AspNetCore.Identity;

namespace EmployeeTimeOffManagementApp.Data;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
}