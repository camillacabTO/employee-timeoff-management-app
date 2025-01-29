using EmployeeTimeOffManagementApp.Models.LeaveTypes;

namespace EmployeeTimeOffManagementApp.Services;

public interface ILeaveTypesServices
{
    Task<List<LeaveTypesReadOnlyVM>> GetAllAsync();
    Task<T?> GetByIdAsync<T>(int? id);
    Task Remove(int id);
    Task CreateAsync(LeaveTypesCreateVM model);
    Task UpdateAsync(LeaveTypesEditVM model);
    bool LeaveTypeExists(int id);
    Task<bool> LeaveTypeExists(string name);
}