using Demo_Lec1.Models;
using Microsoft.AspNetCore.Mvc;
using Demo_Lec1.Models;
namespace Demo_Lec1.Controllers
{
    public class ProductController : Controller
    {
        /*
         Methods cannot be private or static
         Methods cannot be overloaded except (in some cases)
         Action Methods can return:-
         String => ContentResult
         View "Html" => ViewResult
         JSON => JSONResul
         JavaScript => JavascriptResult
         File => FileResult
         Notfound => NotfoundResult
        - 
         */
        public ContentResult ShowMessage()
        {
            ContentResult result = new ContentResult();
            result.Content = "Local Message";
            return result;
        }
        public ContentResult ShowMssage2()
        {
            return Content("Local Message2");
        }

        public ViewResult ShowView()
        {
            ViewResult result = new ViewResult();
            result.ViewName = "View";
            return result;
        }
        public ViewResult ShowView2()
        {
            return View("View");
        }
        public JsonResult ShowJson()
        {
            JsonResult result = new JsonResult(new { ID = 1, Name = "AK" });
            return result;
        }
        public JsonResult ShowJson2()
        {
            return Json(new { id = 1, name = "hossam" });
        }
        public IActionResult ShowMix(int id)
        {
            if (id % 2 == 0)
            {
                ViewResult result = new ViewResult();
                result.ViewName = "View";
                return result;
            }
            else
            {
                ViewResult result = new ViewResult();
                result.ViewName = "View";
                return result;
            }
        }
        /*
         To send parameters to the methods we can do the following:-
        /Product/ShowMix/1 >> with action parameter id only
        /Product/ShowMix?id=1 >> with any action parameter

        -- In case of more than one parameter
        /Product/ShowMix?id=1&age=44
        /Product/ShowMix/1&age=22
         */

        /*- Handle Product Operations */
        ProductRepo productRepo = new ProductRepo();
        public IActionResult ProductDetails (int id)
        {
            Product modal = productRepo.GetProductById(id);
            return View("ProductDetails", modal);
        }
        public IActionResult AllProductDetails()
        {
            List<Product> productsModel = productRepo.GetProducts();
            return View("ShowAllProducts", productsModel);
        }
    }
}
