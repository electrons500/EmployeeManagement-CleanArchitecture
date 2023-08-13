using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Domain;
using EmployeeManagement.Infrastructure.DBContext.EmployeeDBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Repositories.Employees
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private EmployeeDbContext _context;
        public EmployeeRepo(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task AddEmployeeAsync(EmployeeDM employee)
        {
           
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(EmployeeDM employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeDM>> GetAllEmployeesAsync()
        {
            List<EmployeeDM> employees = await _context.Employees.ToListAsync();
           
            return employees;
        }

        public async Task<EmployeeDM> GetEmployeeByIdAsync(int id)
        {
            EmployeeDM employee = await _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefaultAsync();
            return employee;
        }

        public async Task UpdateEmployeeAsync(EmployeeDM employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
