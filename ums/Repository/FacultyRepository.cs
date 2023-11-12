using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ums.Data;
using ums.Models;
using ums.Repository.Interfaces;

namespace ums.Repository
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly UniversityDbContext _context;

        public FacultyRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            return _context.Faculties.ToList();
        }

        public void AddFaculty(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }
    }
}
