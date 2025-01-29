using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeOffManagementApp.Models.LeaveTypes;

public class LeaveTypesEditVM : BaseLeaveTypeVM
{
    [Required]
    [MaxLength(100, ErrorMessage = "Name must be less than 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, 365, ErrorMessage = "Days must be between 1 and 365")]
    [Display(Name = "Number of Days")]
    public int Days { get; set; }
}