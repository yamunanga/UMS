using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ums.Models;

namespace ums.Repository.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int roleId);
        void AddRole(Role role);
    }
}
