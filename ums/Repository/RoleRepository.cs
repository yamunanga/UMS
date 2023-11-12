using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ums.Data;
using ums.Models;
using ums.Repository.Interfaces;

namespace ums.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UniversityDbContext _context;

        public RoleRepository(UniversityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
        }

        public void AddRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            _context.Roles.Add(role);
            _context.SaveChanges();
        }
    }
}
