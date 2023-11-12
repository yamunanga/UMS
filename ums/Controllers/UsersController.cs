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
    [Route("api/users")]

    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers([FromQuery] string faculty, [FromQuery] string department, [FromQuery] string role, [FromQuery] string searchText)
        {
            var result = _userRepository.GetUsers(faculty, department, role, searchText);
            if(result.Count ==0)
            {
                return NotFound();
            }
           
            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest("User data is invalid");
            }

            if (!_userRepository.IsDepartmentValid(newUser.DepartmentId))
            {
                return BadRequest("Department does not exist");
            }

            if (!_userRepository.IsFacultyValid(newUser.FacultyId))
            {
                return BadRequest("Faculty does not exist");
            }

            if (!_userRepository.IsRoleValid(newUser.RoleId))
            {
                return BadRequest("Invalid role");
            }

            if (! _userRepository.DepartmentIn(newUser.DepartmentId,newUser.FacultyId))
            {
                return BadRequest("Department does not exist in faculty");
            }

            _userRepository.AddUser(newUser);

            return CreatedAtAction(nameof(GetUsers), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var existingUser = _userRepository.GetUserById(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            updatedUser.UserId = id;

            try
            {
                _userRepository.UpdateUser(updatedUser);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existingUser = _userRepository.GetUserById(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(id);
            return Ok();
        }
    }
}
