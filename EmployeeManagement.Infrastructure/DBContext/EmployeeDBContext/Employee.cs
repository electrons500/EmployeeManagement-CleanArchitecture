using System;
using System.Collections.Generic;

namespace EmployeeManagement.Infrastructure.DBContext.EmployeeDBContext;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public string City { get; set; }
}
