using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Lec2.Models;
namespace Task_Lec2.Controllers
{
    public class InstructorController : Controller
    {
        ITI_Tanta db = new ITI_Tanta();
        public IActionResult ShowAllInstructors()
        {
            List<Instructor> instructorsModel = db.Instructors
                .Include(i => i.Course)
                .Include(i => i.Department)
                .ToList();
            return View(instructorsModel);
        }
        public IActionResult ShowInstructorDetails(int id)
        {
            Instructor? instructorModel = db.Instructors
                .Include(i => i.Course)
                .Include(i => i.Department)
                .FirstOrDefault(i => i.ID == id);
            return View(instructorModel);

        }
    }
}
