using Easy_Rent_API.Models.Vehicules;
using Easy_Rent_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Easy_Rent_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarTypologyController : ControllerBase
    {
        private readonly ICarTypologiesServices _services;
        public CarTypologyController(ICarTypologiesServices services)
        {
            this._services = services;

        }
        [HttpPost]
        public IActionResult AddCarTypology([FromQuery] string carTypology)
        {

            if (string.IsNullOrEmpty(carTypology))
            {
                return BadRequest("Typology required");
            }

            try
            {
                this._services.addCarTypology(carTypology);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Car typology created with success");
        }

        [HttpGet]
        public IActionResult GetCarTypology()
        {
            return Ok(_services.getCartypologies());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCarTypology(int id)
        {
            try
            {
                _services.deleteCarTypology(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Car typology deleted with success");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCarTypology(carTypology model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            try
            {
                _services.updateCarTypology(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Typology Car updated with success");
        }
    }


}
