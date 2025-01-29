using AutoMapper;
using EmployeeTimeOffManagementApp.Data;
using EmployeeTimeOffManagementApp.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimeOffManagementApp.Services;

public class LeaveTypesServices(ApplicationDbContext context, IMapper mapper) : ILeaveTypesServices
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    
    public async Task<List<LeaveTypesReadOnlyVM>> GetAllAsync()
    {
        // var data = SELECT * FROM LeaveTypes;
        var data = await _context.LeaveTypes.ToListAsync();
        // convert the data model into view model and return to the view
        // var viewModel = data.Select(item => new IndexViewModel
        // {
        //     Id = item.Id,
        //     Name = item.Name,
        //     Days = item.NumberOfDays
        // });
        // use automapper to map the data model to the view model
        var viewModel = _mapper.Map<List<LeaveTypesReadOnlyVM>>(data);
        return viewModel;
    }
    
    public async Task<T?> GetByIdAsync<T>(int? id)
    {
        var leaveType = await _context.LeaveTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (leaveType == null)
        {
            return default;
        }
        var viewData = _mapper.Map<T>(leaveType);
        return viewData;
    }

    public async Task Remove(int id)
    {
        {
            var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
                await _context.SaveChangesAsync();
            }
        }
    }
    
    public async Task CreateAsync(LeaveTypesCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.LeaveTypes.Add(leaveType);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(LeaveTypesEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.LeaveTypes.Update(leaveType);
        await _context.SaveChangesAsync();
    }
    
    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
    public async Task<bool> LeaveTypeExists(string name)
    {
        return await _context.LeaveTypes.AnyAsync(e => e.Name.ToLower().Equals(name.ToLower()));
    }
    
}