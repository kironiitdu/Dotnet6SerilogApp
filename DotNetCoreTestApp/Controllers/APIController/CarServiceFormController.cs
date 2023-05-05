using DotNetCoreTestApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreTestApp.Controllers.APIController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarServiceFormController : ControllerBase
    {
        //private readonly CarDbContext _context;

        //public CarServiceFormController(CarDbContext context)
        //{
        //    _context = context;
        //}
        
        [HttpPost("SubmitForm")]
        public IActionResult SubmitForm([FromForm] CarFormViewModel carFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Get Car Details
            var carDetails = carFormViewModel.CarModel;

            //Get Addons Details
            var selectedAddonsValueFromView = carFormViewModel.Addons?.Where(selectedAddons => selectedAddons.IsChecked == true).ToList();
            
            //Do whatever you want to do in database

           

            return Ok(carFormViewModel);
  
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CarFormViewModel carFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Get Car Details
            var carDetails = carFormViewModel.CarModel;

            //Get Addons Details
            var selectedAddonsValueFromView = carFormViewModel.Addons;

            //Do whatever you want to do in database



            return Ok(carFormViewModel);

        }

        [HttpGet("get-form-data/{id}")]
        public async Task<IActionResult> GetFormData(int id)
        {
            //// Retrieve the CarForm from the database
            //var carForm = await _context.CarForms.Include(cf => cf.Selections).ThenInclude(s => s.Addons).FirstOrDefaultAsync(cf => cf.Id == id);
            //if (carForm == null)
            //{
            //    return NotFound();
            //}

            // Return the CarForm as JSON
            //return Ok(carForm);

            return Ok();
        }

    }
}
