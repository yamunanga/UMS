using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ums.Data;
using ums.Models;
using ums.Repository.Interfaces;

namespace ums.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly UniversityDbContext _context;

        public DepartmentRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
    }
}
