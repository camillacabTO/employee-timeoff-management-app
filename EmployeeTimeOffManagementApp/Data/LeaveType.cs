using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeOffManagementApp.Data;

public class LeaveType
{
    // [Key] - optional
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    public int NumberOfDays { get; set; }
}