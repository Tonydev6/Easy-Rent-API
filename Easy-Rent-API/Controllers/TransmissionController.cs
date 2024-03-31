using Easy_Rent_API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Easy_Rent_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransmissionController : ControllerBase
    {
        private readonly EasyRentContext _context;

        public TransmissionController(EasyRentContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task <IActionResult>  List()
        {
            return Ok(await _context.transmitions.ToListAsync());
        }
    }
}
