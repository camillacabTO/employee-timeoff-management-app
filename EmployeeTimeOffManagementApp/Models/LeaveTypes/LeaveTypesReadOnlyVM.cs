using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeOffManagementApp.Models.LeaveTypes;

public class LeaveTypesReadOnlyVM : BaseLeaveTypeVM
{
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Number of Days")]
    public int Days { get; set; }
}