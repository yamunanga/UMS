using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ums.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public List<User> Users { get; set; }
    }
}
