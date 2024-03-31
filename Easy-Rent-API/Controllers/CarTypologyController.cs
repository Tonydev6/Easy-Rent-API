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
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromQuery] string carTypology)
        {

            if (string.IsNullOrEmpty(carTypology))
            {
                return BadRequest("Typology required");
            }

            try
            {
                bool res = await this._services.Add(carTypology);
                if (res)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> List()
        {
            return Ok(await _services.List());
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool res = await _services.Delete((short)id);
                if (res)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(carTypology model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }


            try
            {
                bool res = await _services.Update(model);
                if (res)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }


}
