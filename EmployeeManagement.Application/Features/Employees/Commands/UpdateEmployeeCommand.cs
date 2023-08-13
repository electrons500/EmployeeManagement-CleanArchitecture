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
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public UpdateEmployeeDto UpdateEmployeeDtoRequest { get; set; }
        public UpdateEmployeeCommand(UpdateEmployeeDto updateEmployeeDtoRequest)
        {
            UpdateEmployeeDtoRequest = updateEmployeeDtoRequest;
        }

        //handler
        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
        {
            private IEmployeeRepo _employeeRepo;
            private IMapper _mapper;
            public UpdateEmployeeCommandHandler(IEmployeeRepo employeeRepo, IMapper mapper)
            {
                _employeeRepo = employeeRepo;
                _mapper = mapper;
            }
            public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                EmployeeDM employee = _mapper.Map<EmployeeDM>(request.UpdateEmployeeDtoRequest);
                await _employeeRepo.UpdateEmployeeAsync(employee);
                return true;
            }


        }

    }
}
