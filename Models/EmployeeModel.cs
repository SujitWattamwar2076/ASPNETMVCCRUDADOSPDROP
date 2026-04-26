using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETMVCCRUDADOSPDROP.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
    }
}