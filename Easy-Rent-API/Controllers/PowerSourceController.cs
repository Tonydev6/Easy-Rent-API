using Easy_Rent_API.Models.Vehicules;
using Easy_Rent_API.Services.Vehicules;
using Microsoft.AspNetCore.Mvc;

namespace Easy_Rent_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerSourceController : ControllerBase
    {
        private readonly IPowerSourcesServices _services;

        public PowerSourceController(IPowerSourcesServices services)
        {
            _services = services;
        }


        [HttpPost("[action]")]
        public async Task <IActionResult> Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest(string.Empty);
            }
            try
            {
                _services.Add(input);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Power Source created with success");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> List()
        {
            return Ok(await _services.List());
        }

        [HttpPut("[action]")]
        public async Task <IActionResult> Update(PowerSource model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            try
            {
                _services.Update(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Power Source Updated with success");
        }
        [HttpDelete("[action]")]
        public async Task <IActionResult> Update(int id)
        {
            try
            {
                _services.Remove(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Power Source Deleted with success");
        }


    }
}
