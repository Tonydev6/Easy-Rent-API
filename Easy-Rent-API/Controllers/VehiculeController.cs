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
        public async Task <IActionResult> AddVehicule(InsertVehicule model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            string res = null;
            try
            {
                res = await _services.AddVehicule(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(res);
        }

        [HttpGet]
        public async Task <IActionResult> GetAllVehicules()
        {
            return Ok(await _services.GetAllVehicules());
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetVehicule(ulong id)
        {
            Vehicule result = new Vehicule();
            try
            {
                result = await _services.GetVehiculeById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateVehicule(ulong id, InsertVehicule model)
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
        public async Task <IActionResult> DeleteVehicule(ulong id)
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
