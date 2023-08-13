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

namespace EmployeeManagement.Application.Features.Employees.Commands
{
    public class AddEmployeeCommand : IRequest<bool>
    {
        public AddEmployeeDto EmployeeRequest { get; set; }
        public AddEmployeeCommand(AddEmployeeDto employeeRequest)
        {
            EmployeeRequest = employeeRequest;
        }

        //handler
        public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, bool>
        {
            private IEmployeeRepo _employeeRepo;
            private IMapper _mapper;
            public AddEmployeeCommandHandler(IEmployeeRepo employeeRepo, IMapper mapper)
            {
                _employeeRepo = employeeRepo;
                _mapper = mapper;
            }
            public async Task<bool> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
            {
                EmployeeDM employee = _mapper.Map<EmployeeDM>(request.EmployeeRequest);
                if (employee != null)
                {
                   await _employeeRepo.AddEmployeeAsync(employee);
                    return true;
                }

                return false;
            }
        }

    } 
}
