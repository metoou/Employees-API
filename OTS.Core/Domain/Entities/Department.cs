using System.Collections.Generic;

namespace OTS.Core.Domain.Entities
{
    public class Department
        : BaseEntity
    {
        public List<Employee> Employees { get; set; }
    }
}
