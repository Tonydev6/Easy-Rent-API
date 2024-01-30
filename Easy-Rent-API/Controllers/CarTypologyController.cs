using Easy_Rent_API.Models.Vehicules;
using Easy_Rent_API.Services.Vehicules;
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
        public async Task <IActionResult> AddCarTypology([FromQuery] string carTypology)
        {

            if (string.IsNullOrEmpty(carTypology))
            {
                return BadRequest("Typology required");
            }

            string res = null;
            try
            {
                 res = await this._services.addCarTypology(carTypology);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(res);
        }

        [HttpGet]
        public async Task <IActionResult> GetCarTypology()
        {
            return Ok(await _services.getCartypologies());
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteCarTypology(int id)
        {
            string res = null;
            try
            {
                res = await _services.deleteCarTypology(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateCarTypology(carTypology model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            string res = null;

            try
            {
                res = await _services.updateCarTypology(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(res);
        }
    }


}
