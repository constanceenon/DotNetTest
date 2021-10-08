using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTest.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Address { get; set; }
        public string PhotoFileName { get; set; }
    }
}
