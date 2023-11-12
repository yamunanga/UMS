using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ums.Models;
using ums.Repository;
using ums.Repository.Interfaces;

namespace ums.Controllers
{
    [ApiController]
    [Route("api/faculties")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyController(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        [HttpGet]
        public IActionResult GetFaculties()
        {
            var faculties = _facultyRepository.GetAllFaculties();
            return Ok(faculties);
        }

        [HttpPost]
        public IActionResult AddFaculty([FromBody] Faculty newFaculty)
        {
            if (newFaculty == null)
            {
                return BadRequest("Faculty data is invalid");
            }

            _facultyRepository.AddFaculty(newFaculty);
            return CreatedAtAction(nameof(GetFaculties), new { id = newFaculty.FacultyId }, newFaculty);
        }
    }
}
