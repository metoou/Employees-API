using System;

namespace OTS.Core.Domain.Entities
{
    public class Employee 
        : BaseEntity
    {
        public Guid? DepartmentId { get; set; }
    }
}
