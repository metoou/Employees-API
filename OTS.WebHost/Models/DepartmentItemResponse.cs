using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTS.WebHost.Models
{
    public class DepartmentItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
}
