using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ums.Models;
using ums.Repository.Interfaces;

namespace ums.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleRepository.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = _roleRepository.GetRoleById(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public IActionResult AddRole([FromBody] Role newRole)
        {
            if (newRole == null)
            {
                return BadRequest("Role data is invalid");
            }

            _roleRepository.AddRole(newRole);
            return CreatedAtAction(nameof(GetRoles), new { id = newRole.RoleId }, newRole);
        }
    }
}
