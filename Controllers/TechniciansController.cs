using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechniciansController : ControllerBase
    {
        private readonly HelpDeskContext _context;

        public TechniciansController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: api/Technicians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technician>>> GetTechnicians()
        {
          if (_context.Technicians == null)
          {
              return NotFound();
          }
            return await _context.Technicians.ToListAsync();
        }

        // GET: api/Technicians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Technician>> GetTechnician(int id)
        {
          if (_context.Technicians == null)
          {
              return NotFound();
          }
            var technician = await _context.Technicians.FindAsync(id);

            if (technician == null)
            {
                return NotFound();
            }

            return technician;
        }

        // PUT: api/Technicians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnician(int id, Technician technician)
        {
            if (id != technician.TechnicianId)
            {
                return BadRequest();
            }

            _context.Entry(technician).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicianExists(id))
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

        // POST: api/Technicians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Technician>> PostTechnician(Technician technician)
        {
          if (_context.Technicians == null)
          {
              return Problem("Entity set 'HelpDeskContext.Technicians'  is null.");
          }
            _context.Technicians.Add(technician);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TechnicianExists(technician.TechnicianId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTechnician", new { id = technician.TechnicianId }, technician);
        }

        // DELETE: api/Technicians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnician(int id)
        {
            if (_context.Technicians == null)
            {
                return NotFound();
            }
            var technician = await _context.Technicians.FindAsync(id);
            if (technician == null)
            {
                return NotFound();
            }

            _context.Technicians.Remove(technician);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnicianExists(int id)
        {
            return (_context.Technicians?.Any(e => e.TechnicianId == id)).GetValueOrDefault();
        }
    }
}
