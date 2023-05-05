using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTestApp.Controllers
{
    public class CheckBoxListController : Controller
    {
        public IActionResult Index()
        {
            List<string> Fruits = GetFruits();
            ViewData["Fruits"] = Fruits;
            return View();
        }

        public List<String> GetFruits()
        {
            var listOfFruits = new List<String> { "BANANA", "APPLE", "MANGO" };
            return listOfFruits;
           
        }
    }
}
