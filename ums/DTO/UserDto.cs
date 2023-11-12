using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ums.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string DepartmentName { get; set; }
        public string FacultyName { get; set; }
    }
}
