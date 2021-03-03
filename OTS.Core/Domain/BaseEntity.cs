using System;

namespace OTS.Core.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
}
