using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ums.DTO;
using ums.Models;

namespace ums.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<UserDto> GetUsers(string faculty, string department, string role, string searchText);
        void AddUser(User user);
        User GetUserById(int userId);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        bool IsDepartmentValid(int departmentId);
        bool IsFacultyValid(int facultyId);
        bool IsRoleValid(int role);
        bool DepartmentIn(int department, int facultyId);
    }
}
