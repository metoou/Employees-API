using System;

namespace OTS.WebHost.Models
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public Guid? DepartmentId { get; set; }

    }
}
