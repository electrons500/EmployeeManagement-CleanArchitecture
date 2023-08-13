using EmployeeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Repositories
{
    public interface IEmployeeRepo
    {
        Task<List<EmployeeDM>> GetAllEmployeesAsync();
        Task<EmployeeDM> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeDM employee);
        Task DeleteEmployeeAsync(EmployeeDM employee);
        Task UpdateEmployeeAsync(EmployeeDM employee);
        
    }
}
