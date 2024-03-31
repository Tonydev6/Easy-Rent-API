using Easy_Rent_API.DTO.Locations;
using Easy_Rent_API.Entities.Locations;
using Easy_Rent_API.Services.Locations;
using Microsoft.AspNetCore.Mvc;

namespace Easy_Rent_API.Controllers.Locations
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationsServices _locationsServices;
        public LocationController(ILocationsServices services)
        {
            _locationsServices = services;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(InsertLocation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            try
            {
                bool res = await _locationsServices.Add(model);
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
        public async Task<IActionResult> Get(ulong id)
        {
            Location result;
            try
            {
                result = await _locationsServices.Get(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> List
            ()
        {
            return Ok(await _locationsServices.List());
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(ulong id, InsertLocation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            try
            {
                bool res = await _locationsServices.Update(id, model);
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

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(ulong id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            try
            {
                bool res = await _locationsServices.Remove(id);
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
