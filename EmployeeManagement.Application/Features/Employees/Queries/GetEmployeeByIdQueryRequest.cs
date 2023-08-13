using AutoMapper;
using EmployeeManagement.Application.Dtos.Employees;
using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employees.Queries
{
    public class GetEmployeeByIdQueryRequest : IRequest<GetEmployeeByIdDto>
    {
        public int EmployeeId { get; set; }
        public GetEmployeeByIdQueryRequest(int employeeId)
        {
            EmployeeId = employeeId;
        }

        //handler
        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQueryRequest, GetEmployeeByIdDto>
        {
            private IEmployeeRepo _employeeRepo;
            private IMapper _mapper;
            public GetEmployeeByIdQueryHandler(IEmployeeRepo employeeRepo, IMapper mapper)
            {
                _employeeRepo = employeeRepo;
                _mapper = mapper;
            }

            public async Task<GetEmployeeByIdDto> Handle(GetEmployeeByIdQueryRequest request, CancellationToken cancellationToken)
            {
                EmployeeDM employee = await _employeeRepo.GetEmployeeByIdAsync(request.EmployeeId);
                var getemployee = _mapper.Map<GetEmployeeByIdDto>(employee);
               if(getemployee != null)
                {
                    return getemployee;
                }
                return null;
            }
        }

    }
}
