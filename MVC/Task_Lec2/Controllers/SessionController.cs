using Microsoft.AspNetCore.Mvc;

namespace Task_Lec2.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult SetSession(string name)
        {
            HttpContext.Session.SetString("Name", name);
            return Content("ok,Session is added Successful");
        }

        public IActionResult GetSession()
        {

            var name = HttpContext.Session.GetString("Name");
            if (name != null)
            {
                return Content($"Name of Client{name}");
            }
            else
            {
                return Content("No session found.");
            }
        }
    }
}

