using AutoMapper;
using EmployeeManagement.Application.Dtos.Employees;
using EmployeeManagement.Domain;

namespace EmployeeManagement.Application.AutoMapperProfile
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeDM, GetEmployeesDto>();
            CreateMap<EmployeeDM, GetEmployeeByIdDto>();
            CreateMap<AddEmployeeDto, EmployeeDM>();
            CreateMap<UpdateEmployeeDto, EmployeeDM>();
        }
    }
}
