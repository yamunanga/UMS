using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ums.Models;

namespace ums.Repository.Interfaces
{
    public interface IFacultyRepository
    {
        IEnumerable<Faculty> GetAllFaculties(); 
        void AddFaculty(Faculty faculty);
    }
}
