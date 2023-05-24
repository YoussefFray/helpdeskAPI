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
    public class TechniciansAuthController : ControllerBase
    {
        private readonly HelpDeskContext _context;

        public TechniciansAuthController(HelpDeskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Technician>> GetTechnician(String email, string password)
        {
            if (_context.Technicians == null)
            {
                return NotFound();
            }
            var technician = await _context.Technicians.FirstOrDefaultAsync(u => u.Email == email && u.Password == password); ;

            if (technician == null)
            {
                return NotFound();
            }

            return technician;
        }



    }
}
