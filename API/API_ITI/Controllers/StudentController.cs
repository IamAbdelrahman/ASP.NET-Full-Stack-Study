using Demos.DTO;
using Demos.Models;
using Demos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Demos.Controllers
{
    // Token replacement: [Route("api/[controller]")] as at run-time
    // the [controller] token will be replaced with the name of the controller class
    // minus the "Controller" suffix, which in this case is "Student".
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            var studentDTOs = students.Select(s => new StudentDTO
            {
                Id = s.Id,
                FullName = s.FullName.ToLower(),
                Address = s.Address, // Assuming Department has an Address property
                Age = s.Age + 1 ?? 0, // Assuming Age is nullable, default to 0 if null
                DepartmentName = s.Department?.Name // Assuming Department has a Name property
            });

            return Ok(studentDTOs); // Returns 200 OK with the list of students
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound(); // Returns 404 Not Found if the student does not exist
            }
            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                FullName = student.FullName,
                Address = student.Address, // Assuming Department has an Address property
                Age = student.Age ?? 0, // Assuming Age is nullable, default to 0 if null
                DepartmentName = student.Department?.Name // Assuming Department has a Name property
            };
            return Ok(studentDTO); // Returns 200 OK with the student details
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var student = await _unitOfWork.Students.GetStudentByName(name);
            if (student == null)
            {
                return NotFound(); // Returns 404 Not Found
            }
            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                FullName = student.FullName,
                Address = student.Address, // Assuming Department has an Address property
                Age = student.Age ?? 0, // Assuming Age is nullable, default to 0 if null
                DepartmentName = student.Department?.Name // Assuming Department has a Name property
            };
            return Ok(studentDTO); // Returns 200 OK with the student data
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student? student)
        {
            if (student == null) return BadRequest("Student data is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.CompleteAsync();
            /* 
             * The CreatedAtAction method generates a response with a 201 Created status code
              and includes a Location header pointing to the GetById action for the newly created student.
              The first parameter is the name of the action method to call to retrieve the created resource.
              The second parameter is an anonymous object that contains the route values for the action method
              in this case, the student ID. 
              This allows the client to easily retrieve the newly created student by its ID.
             */
            return CreatedAtAction("GetById", new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Student student, int id)
        {
            if (student == null) return BadRequest("Student data is required.");
            if (student.Id != id) return BadRequest("Student ID mismatch.");
            await _unitOfWork.Students.UpdateAsync(student);
            await _unitOfWork.CompleteAsync();
            return Content("student updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null) return NotFound("Student not found.");
            await _unitOfWork.Students.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return Ok($"Student {student} deleted successfully.");
        }
    }
}