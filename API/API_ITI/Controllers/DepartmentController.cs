using Demos.DTO;
using Demos.Models;
using Demos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _unitOfWork.Departments.GetAllAsync();
            var departmentDTOs = departments.Select(d => new DepartmentDTO
            {
                Id = d.Id,
                Name = d.Name,
                Location = d.Location,
                StudentCount = d.Students.Count,
                StudentNames = d.Students.Select(s => s.FullName).ToList()
            });
            return Ok(departmentDTOs); // Returns 200 OK with the list of departments
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound(); // Returns 404 Not Found if the department does not exist
            }
            var departmentDTO = new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name,
                Location = department.Location,
                StudentCount = department.Students.Count,
                StudentNames = department.Students.Select(s => s.FullName).ToList()
            };

            return Ok(departmentDTO); // Returns 200 OK with the department details
        }
    }
}
