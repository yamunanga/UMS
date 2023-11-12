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
    [Route("api/departments")]

    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _departmentRepository.GetAllDepartments();
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody] Department newDepartment)
        {
            if (newDepartment == null)
            {
                return BadRequest("Department data is invalid");
            }

            _departmentRepository.AddDepartment(newDepartment);
            return CreatedAtAction(nameof(GetDepartments), new { id = newDepartment.DepartmentId }, newDepartment);
        }
    }
}
