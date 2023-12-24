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

        [HttpPost]
        public IActionResult AddLocation(InsertLocation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            try
            {
                _locationsServices.AddLocation(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Location addesd with success");
        }

        [HttpGet("{id}")]
        public IActionResult GetLocationById(ulong id)
        {
            Location result;
            try
            {
                result = _locationsServices.GetLocationById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            return Ok(_locationsServices.GetAllLocations());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLocation(ulong id, InsertLocation model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            try
            {
                _locationsServices.UpdateLocation(id, model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Location updated with success");

        }

        [HttpDelete]
        public IActionResult DeleteLocation(ulong id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model not valid");
            }
            try
            {
                _locationsServices.RemoveLocation(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Location deleted with success");

        }


    }
}
