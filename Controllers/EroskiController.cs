using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEroski.Models;

namespace ApiEroski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EroskiController : ControllerBase
    {
        private readonly EroskiContext _context;

        public EroskiController(EroskiContext context)
        {
            _context = context;
        }

        // GET: api/Eroski
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eroski>>> GetEroski()
        {
            return await _context.Eroski.ToListAsync();
        }

        // GET: api/Eroski/Pescaderia
        [HttpGet("{seccion}")]
        public async Task<ActionResult<Eroski>> GetEroski(string seccion)
        {
            var eroski = await _context.Eroski.FindAsync(seccion);

            if (eroski == null)
            {
                return NotFound();
            }

            return eroski;
        }

        // PUT: api/Eroski/Pescaderia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{seccion}")]
        public async Task<IActionResult> PutEroski(string seccion)
        {
           var eroski = await _context.Eroski.FindAsync(seccion);
           eroski.Ticket += 1;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EroskiExists(eroski.Seccion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Eroski/Resert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Resert")]
        public async Task<IActionResult> PutResertEroski()
        {
           foreach (var seccion in _context.Eroski)
           {
               seccion.Ticket = 0;
           }

            await _context.SaveChangesAsync();

            return NoContent();
        }
        // POST: api/Eroski
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Eroski>> PostEroski(Eroski eroski)
        {
            _context.Eroski.Add(eroski);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EroskiExists(eroski.Seccion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEroski", new { id = eroski.Seccion }, eroski);
        }

        // DELETE: api/Eroski/5
        [HttpDelete("{seccion}")]
        public async Task<IActionResult> DeleteEroski(string seccion)
        {
            var eroski = await _context.Eroski.FindAsync(seccion);
            if (eroski == null)
            {
                return NotFound();
            }

            _context.Eroski.Remove(eroski);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EroskiExists(string seccion)
        {
            return _context.Eroski.Any(e => e.Seccion == seccion);
        }
    }
}
