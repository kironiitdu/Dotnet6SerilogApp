using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTestApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            string authHeader = HttpContext.Request.Headers["Authorization"];
            if (authHeader == null)
            {
                ViewData["page"] = "_ErrorLayout";
            }
            return View();
        }
    }
}
