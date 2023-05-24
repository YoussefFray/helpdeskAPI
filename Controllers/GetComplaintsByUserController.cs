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
    public class GetComplaintsByUserController : ControllerBase
    {
        private readonly HelpDeskContext _context;

        public GetComplaintsByUserController(HelpDeskContext context)
        {
            _context = context;
        }



        // GET: api/GetComplaintsByUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Complaint>>> GetComplaintsByUserId(int id)
        {
            var complaints = await _context.Complaints
                .Where(c => c.UserId == id)
                .ToListAsync();

            if (complaints == null || complaints.Count == 0)
            {
                return NotFound();
            }

            return complaints;
        }


        private bool ComplaintExists(int id)
        {
            return (_context.Complaints?.Any(e => e.ComplaintId == id)).GetValueOrDefault();
        }
    }
}
