using OTS.Core.Domain.Entities;
using OTS.WebHost.Models;
using System;

namespace OTS.WebHost.Mappers
{
    public class EmployeeStaticMapper
    {
        public static Employee MapFromModel(CreateOrEditEmployeeRequest model,
            Employee employee = null)
        {
            if (employee == null)
            {
                employee = new Employee();
                employee.Id = Guid.NewGuid();
            }

            employee.Name = model.Name;
            employee.Salary = model.Salary;
            employee.DepartmentId = model.DepartmentId;

            return employee;
        }
    }
}
