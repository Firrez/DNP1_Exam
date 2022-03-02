using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;
using WebAPI.DataAccess;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToyController : ControllerBase
    {
        private KinderGardenContext _context;

        public ToyController(KinderGardenContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/Toy/owner/{childName}")]
        public async Task<ActionResult> AddToyAsync([FromRoute] string childName, [FromBody] Toy toy)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _context.AddToyAsync(childName, toy);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(400, e.Message);
            }
        }
    }
}