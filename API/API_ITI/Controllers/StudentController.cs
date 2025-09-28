using Demos.DTO;
using Demos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace Demos.Controllers
{
    // Token replacement: [Route("api/[controller]")] as at run-time
    // the [controller] token will be replaced with the name of the controller class
    // minus the "Controller" suffix, which in this case is "Student".
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ITIContext db;
        public StudentController(ITIContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> st = db.Students.ToList();
            List<StudentDTO> stDTOs = new List<StudentDTO>();
            foreach (var student in st)
            {
                stDTOs.Add(new StudentDTO
                {
                    Id = student.Id,
                    FullName = student.FullName.ToLower(),
                    Address = student.Address, // Assuming Department has an Address property
                    Age = student.Age + 1 ?? 0, // Assuming Age is nullable, default to 0 if null
                    DepartmentName = student.Department?.Name // Assuming Department has a Name property
                });
            }
            return Ok(stDTOs); // Returns 200 OK with the list of students
        }

        /// <summary>
        /// Here we can only control the HTTP method and the route.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet("{id}")]
        //public Student? GetById(int id)
        //{
        //    return db.Students.Find(id);
        //}

        /// <summary>
        /// Here we can control the HTTP method, the route, and the response status code.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound(); // Returns 404 Not Found
            }
            StudentDTO stDTO = new StudentDTO
            {
                Id = student.Id,
                FullName = student.FullName,
                Address = student.Address, // Assuming Department has an Address property
                Age = student.Age ?? 0, // Assuming Age is nullable, default to 0 if null
                DepartmentName = student.Department?.Name // Assuming Department has a Name property
            };
            return Ok(stDTO); // Returns 200 OK with the student data
        }

        //[HttpGet("/api/sts/{name}")]
        [HttpGet("{name:alpha}")] // Add constraints on the route parameter
        public IActionResult GetByName(string name)
        {
            var student = db.Students.FirstOrDefault(s => s.FullName == name);
            if (student == null)
            {
                return NotFound(); // Returns 404 Not Found
            }
            return Ok(student); // Returns 200 OK with the student data
        }

        [HttpPost]
        public IActionResult Add(Student? student)
        {
            if (student == null) return BadRequest("Student data is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            db.Students.Add(student);         // <--- Save to DbContext
            db.SaveChanges();                 // <--- Actually save to DB
            //return Created("Anything", student); // Returns 201 Created with the student data

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
        public IActionResult Update(Student student, int id)
        {
            if (student == null) return BadRequest("Student data is required.");
            if (student.Id != id) return BadRequest("Student ID mismatch.");
            db.Students.Update(student);
            //db.Entry(student).State = EntityState.Modified; // Mark the entity as modified
            db.SaveChanges(); // Save changes to the database
            return Content("student updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student == null) return NotFound("Student not found.");
            db.Students.Remove(student);
            db.SaveChanges();
            return Ok($"Student {student} deleted successfully.");
        }
    }
}