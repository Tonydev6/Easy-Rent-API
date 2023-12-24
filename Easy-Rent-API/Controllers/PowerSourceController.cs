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


        [HttpPost("{input}")]
        public ActionResult AddPowerSource(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest(string.Empty);
            }
            try
            {
                _services.AddPowerSource(input);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Power Source created with success");
        }

        [HttpGet]
        public ActionResult GetPowerSource()
        {
            return Ok(_services.GetAllPowerSources());
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePowerSource(PowerSource model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            try
            {
                _services.UpdatePowerSources(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Power Source Updated with success");
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePowerSource(int id)
        {
            try
            {
                _services.RemovePowerSource(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Power Source Deleted with success");
        }


    }
}
