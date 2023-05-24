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
    public class ActionCorrectivesController : ControllerBase
    {
        private readonly HelpDeskContext _context;

        public ActionCorrectivesController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: api/ActionCorrectives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActionCorrective>>> GetActionCorrectives()
        {
          if (_context.ActionCorrectives == null)
          {
              return NotFound();
          }
            return await _context.ActionCorrectives.ToListAsync();
        }

        // GET: api/ActionCorrectives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActionCorrective>> GetActionCorrective(int id)
        {
          if (_context.ActionCorrectives == null)
          {
              return NotFound();
          }
            var actionCorrective = await _context.ActionCorrectives.FindAsync(id);

            if (actionCorrective == null)
            {
                return NotFound();
            }

            return actionCorrective;
        }

        // PUT: api/ActionCorrectives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActionCorrective(int id, ActionCorrective actionCorrective)
        {
            if (id != actionCorrective.ActionId)
            {
                return BadRequest();
            }

            _context.Entry(actionCorrective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionCorrectiveExists(id))
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

        // POST: api/ActionCorrectives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActionCorrective>> PostActionCorrective(ActionCorrective actionCorrective)
        {
          if (_context.ActionCorrectives == null)
          {
              return Problem("Entity set 'HelpDeskContext.ActionCorrectives'  is null.");
          }
            _context.ActionCorrectives.Add(actionCorrective);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActionCorrectiveExists(actionCorrective.ActionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActionCorrective", new { id = actionCorrective.ActionId }, actionCorrective);
        }

        // DELETE: api/ActionCorrectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActionCorrective(int id)
        {
            if (_context.ActionCorrectives == null)
            {
                return NotFound();
            }
            var actionCorrective = await _context.ActionCorrectives.FindAsync(id);
            if (actionCorrective == null)
            {
                return NotFound();
            }

            _context.ActionCorrectives.Remove(actionCorrective);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActionCorrectiveExists(int id)
        {
            return (_context.ActionCorrectives?.Any(e => e.ActionId == id)).GetValueOrDefault();
        }
    }
}
