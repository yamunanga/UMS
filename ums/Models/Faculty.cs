using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ums.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<Department> Departments { get; set; }
    }
}
