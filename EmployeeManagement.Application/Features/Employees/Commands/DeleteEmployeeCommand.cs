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
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int EmployeeId { get; set; }
        public DeleteEmployeeCommand(int employeeId)
        {
            EmployeeId = employeeId;
        }
        //handler
        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
        {
            private IEmployeeRepo _employeeRepo;
            public DeleteEmployeeCommandHandler(IEmployeeRepo employeeRepo)
            {
                _employeeRepo = employeeRepo;
            }
            public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                //get employee
                EmployeeDM employee = await _employeeRepo.GetEmployeeByIdAsync(request.EmployeeId);
                await _employeeRepo.DeleteEmployeeAsync(employee);

                return true;
            }



        }

    }
}
