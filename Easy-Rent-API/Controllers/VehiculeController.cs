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

        [HttpPost("[action]")]
        public async Task<IActionResult> Insert(InsertVehicule model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            try
            {
                bool res = await _services.Add(model);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> List()
        {
            return Ok(await _services.List());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(ulong id)
        {
            Vehicule result = new Vehicule();
            try
            {
                result = await _services.GetByID(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(ulong id, InsertVehicule model)
        {
            try
            {
                bool res = await _services.Update(id, model);
                if (res)
                {
                    return Ok(res);
                }
                else

                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(ulong id)
        {
            try
            {
                bool res = await _services.Delete(id);
                if (res)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }


}
