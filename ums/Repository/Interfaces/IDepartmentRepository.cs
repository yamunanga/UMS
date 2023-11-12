using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ums.Models;

namespace ums.Repository.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        void AddDepartment(Department department);
    }
}
