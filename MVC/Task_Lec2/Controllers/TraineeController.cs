using Task_Lec2.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Lec2.Models;
namespace Task_Lec2.Controllers
{
    public class TraineeController : Controller
    {
        ITI_Tanta dbContext = new ITI_Tanta();
        public IActionResult GetResult(int Tid, int Cid)
        {

            TraineeVM traineeResult = new();

            if (dbContext.CourseResults is not null)
            {
                var result = dbContext.CourseResults
                    .Where(r => r.ID == Tid && r.ID == Cid)
                    .Select(r => new TraineeVM
                    {
                        TraineeName = r.Trainees.Name,
                        CourseName = r.Courses.Name,
                        TraineeDegree = r.Degree,
                        State = r.Degree >= r.Courses.MinDegree ? "Passed" : "Failed",
                        Color = r.Degree >= r.Courses.MinDegree ? "green" : "red"
                    })
                    .FirstOrDefault();
                if (result != null)
                {
                    traineeResult = result;
                }

                return View("GetResult", traineeResult);
            }
            else
            {
                return NotFound("No results found for the specified trainee and course.");
            }
        }
    }
}

