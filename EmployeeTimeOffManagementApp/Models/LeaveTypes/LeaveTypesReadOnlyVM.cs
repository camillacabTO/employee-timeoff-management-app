namespace EmployeeTimeOffManagementApp.Models.LeaveTypes;

public class LeaveTypesReadOnlyVM
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public int Days { get; set; }
}