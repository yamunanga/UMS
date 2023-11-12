using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ums.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }
        public Department Department { get; set; }
        public Role Role { get; set; }
    }
}
