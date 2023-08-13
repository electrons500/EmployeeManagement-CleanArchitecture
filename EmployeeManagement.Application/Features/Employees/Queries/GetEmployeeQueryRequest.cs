using AutoMapper;
using EmployeeManagement.Application.Dtos.Employees;
using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Domain;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries
{
    public class GetEmployeeQueryRequest : IRequest<IEnumerable<GetEmployeesDto>>
    {
        public GetEmployeeQueryRequest() { }

        //handler
        public class GetEmployeeQueryRequestHandler : IRequestHandler<GetEmployeeQueryRequest, IEnumerable<GetEmployeesDto>>
        {
            private readonly IEmployeeRepo _employeeRepo;
            private IMapper _mapper;
            public GetEmployeeQueryRequestHandler(IEmployeeRepo employeeRepo, IMapper mapper)
            {
                _employeeRepo = employeeRepo;
                _mapper = mapper;
            }
            public async Task<IEnumerable<GetEmployeesDto>> Handle(GetEmployeeQueryRequest request, CancellationToken cancellationToken)
            {
                List<EmployeeDM> employees = await _employeeRepo.GetAllEmployeesAsync();
                //map
                List<GetEmployeesDto> getEmployees =  _mapper.Map<List<GetEmployeesDto>>(employees);
                if(getEmployees != null)
                {
                    return getEmployees;
                }
                return null;
            }
        }
    }
}
