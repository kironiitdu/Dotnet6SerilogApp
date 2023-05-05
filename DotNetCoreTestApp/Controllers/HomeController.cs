using DotNetCoreTestApp.Data;
using DotNetCoreTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace DotNetCoreTestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult AnotherWayToRenderLayout() 
        {
          return View();
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult HandleNullWarnings()
        {

            return View();
        }

        public IActionResult Privacy()
        {
        
            var addonsList = new List<Addon>()
            {
                new Addon() { Id=1,CheckboxName="10% off First service visit", IsChecked = false },
                new Addon() { Id=2,CheckboxName="10% off Waterwash", IsChecked = false },
                new Addon() { Id=3,CheckboxName="Free AC Inspection", IsChecked = false },


            };

            var model = new CarFormViewModel();
            model.Addons = addonsList;
            return View(model);
        }
        [HttpPost]
        public IActionResult SubmitCarAddonSelectedValue(CarFormViewModel carFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var selectedAddonsValueFromView = carFormViewModel.Addons?.Where(selectedAddons => selectedAddons.IsChecked == true).ToList();
            //Insert your addons in database

            return Ok(selectedAddonsValueFromView);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    
    
}