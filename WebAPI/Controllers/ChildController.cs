using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;
using WebAPI.DataAccess;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChildController : ControllerBase
    {
        private KinderGardenContext _context;

        public ChildController(KinderGardenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> AddChildAsync([FromBody] Child child)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _context.AddChildAsync(child);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Child>>> GetAllChildrenAsync()
        {
            try
            {
                List<Child> list = await _context.GetAllChildrenAsync();
                return Ok(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("/Child/Toys/{toyId}")]
        public async Task<ActionResult> RemoveToyAsync([FromRoute] string toyId)
        {
            try
            {
                await _context.RemoveToyAsync(toyId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}