using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ums.Data;
using ums.DTO;
using ums.Models;
using ums.Repository.Interfaces;

namespace ums.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UniversityDbContext _context;

        public UserRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public List<UserDto> GetUsers(string faculty, string department, string role, string searchText)
        {
            IQueryable<User> query = _context.Users.Include(u => u.Department).ThenInclude(d => d.Faculty);

            if (!string.IsNullOrEmpty(faculty))
                query = query.Where(u => u.Department.Faculty.FacultyName == faculty);

            if (!string.IsNullOrEmpty(department))
                query = query.Where(u => u.Department.DepartmentName == department);

            if (!string.IsNullOrEmpty(role))
                query = query.Where(u => u.Role.Name == role);

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(u => u.UserName.Contains(searchText));

            
            var result = query.Select(u => new UserDto
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Role = u.Role.Name,
                DepartmentName = u.Department.DepartmentName,
                FacultyName = u.Department.Faculty.FacultyName
            }).ToList();

            return result;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Include(u => u.Department).ThenInclude(d => d.Faculty)
                .FirstOrDefault(u => u.UserId == userId);
        }

        public void AddUser(User user)
        {
            if (!IsDepartmentValid(user.DepartmentId))
            {
                throw new ArgumentException("Invalid department");
            }

            if (!IsFacultyValid(user.FacultyId))
            {
                throw new ArgumentException("Invalid faculty");
            }

            if (!IsRoleValid(user.RoleId))
            {
                throw new ArgumentException("Invalid role");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (!IsDepartmentValid(user.DepartmentId))
            {
                throw new ArgumentException("Invalid department");
            }

            if (!IsFacultyValid(user.FacultyId))
            {
                throw new ArgumentException("Invalid faculty");
            }

            if (!IsRoleValid(user.RoleId))
            {
                throw new ArgumentException("Invalid role");
            }
            var existingUser = _context.Users.Find(user.UserId);

            if (existingUser != null)
            {
                if (_context.Entry(existingUser).State == EntityState.Detached)
                {
                    _context.Users.Attach(existingUser);
                }

                existingUser.UserName = user.UserName;
                existingUser.RoleId = user.RoleId;
                existingUser.DepartmentId = user.DepartmentId;
                existingUser.FacultyId = user.FacultyId;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Invalid Id");
            }
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _context.Users.Find(userId);

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
        }

        public bool IsDepartmentValid(int departmentId)
        {
            return _context.Departments.Any(d => d.DepartmentId == departmentId);
        }

        public bool IsFacultyValid(int facultyId)
        {
            return _context.Faculties.Any(f => f.FacultyId == facultyId);
        }

        public bool IsRoleValid(int role)
        {
            return _context.Roles.Any(r => r.RoleId == role);
        }

        public bool DepartmentIn (int department,int facultyId)
        {
            return _context.Departments.Any(d => d.DepartmentId == department && d.FacultyId == facultyId);
        }
    }
}
