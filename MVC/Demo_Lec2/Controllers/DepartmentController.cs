using Demo_Lec2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo_Lec2.Controllers
{
    public class DepartmentController : Controller
    {
        ITI_Entity context = new ITI_Entity();
        public IActionResult GetAllDepartments()
        {
            List<Department> departmentsModel = context.Departments.Include(d => d.Employees).ToList();
            //return View("GetAllDepartments", departmentsModel);
            return View(departmentsModel);
        }
    }
}
