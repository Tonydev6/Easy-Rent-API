using Easy_Rent_API.DTO.Vehicules;
using Easy_Rent_API.Models.Vehicules;
using Easy_Rent_API.Services.Vehicules;
using Microsoft.AspNetCore.Mvc;

namespace Easy_Rent_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculeController : ControllerBase
    {
        private readonly IVehiculesServices _services;

        public VehiculeController(IVehiculesServices services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult AddVehicule(InsertVehicule model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }

            try
            {
                _services.AddVehicule(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Vehicule inserted with success");
        }

        [HttpGet]
        public IActionResult GetAllVehicules()
        {
            return Ok(_services.GetAllVehicules());
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicule(ulong id)
        {
            Vehicule result = new Vehicule();
            try
            {
                result = _services.GetVehiculeById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicule(ulong id, InsertVehicule model)
        {
            try
            {
                _services.UpdateVehicule(id, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Vehicule updated with success");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicule(ulong id)
        {
            try
            {
                _services.RemoveVehicule(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Vehicule deleted with success");
        }
    }


}
