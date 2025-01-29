using AutoMapper;
using EmployeeTimeOffManagementApp.Data;
using EmployeeTimeOffManagementApp.Models.LeaveTypes;

namespace EmployeeTimeOffManagementApp.MappingProfiles;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        // Create a mapping from LeaveType to IndexViewModel, and map the NumberOfDays property to the Days property
        CreateMap<LeaveType, LeaveTypesReadOnlyVM>()
            .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));

        CreateMap<LeaveTypesCreateVM, LeaveType>()
            .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.Days));

        CreateMap<LeaveType, LeaveTypesEditVM>()
            .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
    }
}